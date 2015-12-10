using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data.OracleClient;

namespace Rings
{
    class DBLayout
    {

        struct len
        {
            public string server;
            public string client;
            public bool ignore;
        }

        /// <summary>
        /// 抽取数据库结构，并生成sql.sqt文件可创建数据库表结构。
        /// </summary>
        /// <param name="conn">数据库连接</param>
        /// <param name="path">输出文件路径</param>
        /// <param name="type">"SQL"/"ORACLE"</param>
        public static int Extract(string conn, string path, string type)
        {
            if (type == "SQL")
            {
                return Extract_SQL(conn, path);
            }
            else if (type == "Oracle")
            {
                 Extract_Oracle(conn, path);
                 return 0;
            }
            return -1;
        }

        private static int Extract_SQL(string conn, string path)
        {
            SqlConnection sql_con = new SqlConnection(conn);
            try
            { sql_con.Open(); }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接失败！");
                return -1;
            }

            try
            {
                if (Directory.Exists(path)) Directory.Delete(path, true);
                Directory.CreateDirectory(path);

                DataTable table_n = sql_con.GetSchema(SqlClientMetaDataCollectionNames.Tables);
                DataTable table_f = sql_con.GetSchema(SqlClientMetaDataCollectionNames.Columns);
                DataTable table_i = sql_con.GetSchema(SqlClientMetaDataCollectionNames.Indexes);
                DataTable table_c = sql_con.GetSchema(SqlClientMetaDataCollectionNames.IndexColumns);
                DataTable[] tables = new DataTable[] { table_n, table_f, table_i, table_c };



                //第一步，抽表名

                DataTable table_name = tables[0];
                List<string> list_table = new List<string>();
                StreamWriter SQ = new StreamWriter(path + @"\sql.sqt", false, Encoding.UTF8);
                using (StreamWriter st = new StreamWriter(path + @"\table.txt", false, Encoding.UTF8))
                {
                    using (StreamWriter sf = new StreamWriter(path + @"\field.txt", false, Encoding.UTF8))
                    {
                        foreach (DataRow dr_t in table_name.Rows)
                        {
                            string table_s = dr_t["TABLE_NAME"].ToString();
                            if (!list_table.Contains(table_s))
                            {
                                list_table.Add(table_s);

                                st.WriteLine("TABLE\b" + table_s);
                                SQ.WriteLine("create table " + table_s + "(SGID VARCHAR(14) DEFAULT '')");


                                //第二步，对字段名处理////////////
                                DataTable field_name = tables[1];
                                foreach (DataRow dr_f in field_name.Rows)
                                {//按照表的顺序进行排列了。。。
                                    //**待改进**//应该是可以直接对字段表进行处理生成字段文件的，因为这里储存的是数据库里的字段信息
                                    if (dr_f["TABLE_NAME"].ToString() == table_s)
                                    {
                                        string field_s = dr_f["COLUMN_NAME"].ToString();
                                        string field_type = dr_f["DATA_TYPE"].ToString();
                                        string field_len = "";
                                        //这里对text和数字的验证需要确定数据库里的数据类型
                                        if (field_type.Contains("char") || field_type.Contains("varchar"))
                                        {
                                            field_len = dr_f["CHARACTER_MAXIMUM_LENGTH"].ToString() + ",0";
                                            if (field_s != "SGID") SQ.WriteLine("alter table " + table_s + " add " + field_s + " " + field_type + "(" + dr_f["CHARACTER_MAXIMUM_LENGTH"].ToString() + ") default ''");
                                            else SQ.WriteLine("alter table " + table_s + " alter column " + field_s + " " + field_type + "(" + dr_f["CHARACTER_MAXIMUM_LENGTH"].ToString() + ")");

                                        }
                                        else if (field_type.Contains("decimal") || field_type.Contains("numeric") || field_type.Contains("int") || field_type.Contains("float"))
                                        //else if (field_type == "NUMERIC")decimal
                                        {
                                            string pre = dr_f["NUMERIC_PRECISION"].ToString();
                                            string sca = dr_f["NUMERIC_SCALE"].ToString();
                                            if (sca == "")
                                            {
                                                sca = "0";
                                            }
                                            field_len = pre + "," + sca;
                                            if (field_s != "SGID") SQ.WriteLine("alter table " + table_s + " add " + field_s + " " + field_type + "(" + field_len + ") default 0");
                                        }
                                        else//有可能是图片之类
                                        {
                                            field_len = ",";
                                            if (field_s != "SGID") SQ.WriteLine("alter table " + table_s + " add " + field_name + " " + field_type);

                                        }
                                        sf.WriteLine("FIELD\b" + table_s + "\b" + field_s + "\b" + field_type + "\b" + field_len);

                                    }


                                }
                            }
                        }
                    }
                }
                //第三步 对index的处理//////////////////
                DataTable index_name = tables[2];
                DataTable indcol_name = tables[3];
                using (StreamWriter si = new StreamWriter(path + @"\index.txt", false, Encoding.UTF8))
                {
                    foreach (DataRow dr_i in index_name.Rows)
                    {
                        string thisTable = dr_i["TABLE_NAME"].ToString();
                        string thisIndex = dr_i["index_name"].ToString();

                        string isPrimaryKey = "N";
                        string Query = "SELECT * FROM sys.indexes where name = " + "'" + thisIndex + "'";
                        SqlConnection newconn = new SqlConnection(conn);
                        newconn.Open();
                        SqlCommand cmd = new SqlCommand(Query, newconn);
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        string unique = dt.Rows[0]["is_unique"].ToString().ToUpper();
                        if (unique.StartsWith("T"))
                        {
                            isPrimaryKey = "Y";

                        }
                        dr.Close();
                        newconn.Close();
                        dr = null;
                        cmd = null;

                        string colList = "";
                        foreach (DataRow indFld in indcol_name.Rows)
                        {
                            string tblName = indFld["TABLE_NAME"].ToString();
                            string columnName = indFld["column_name"].ToString();
                            string indexName = indFld["index_name"].ToString();
                            if (thisTable.Equals(tblName) && thisIndex.Equals(indexName))
                            {
                                if (!colList.Equals("")) { colList += ","; }
                                colList += columnName + "";
                            }
                        }

                        si.WriteLine("IND\b" + thisTable + "\b" + thisIndex + "\b" + colList + "\b" + isPrimaryKey);
                        if (isPrimaryKey == "Y")
                        {
                            SQ.WriteLine("create unique index " + thisIndex + "  on " + thisTable + "(" + colList + ")");

                        }
                        else
                        {
                            SQ.WriteLine("create index " + thisIndex + "  on " + thisTable + "(" + colList + ")");

                        }
                    }
                }
                SQ.Close();
                sql_con.Close();
                return 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接成功，但由于未知原因抽取失败，请排查后重新执行操作！");
                return -1;
            }
            
            //MessageBox.Show("ok");

        }

        private static void Extract_Oracle(string _DBConn, string path)
        {
            StreamWriter sw = new StreamWriter(path + @"\DBLayout_Ext.txt", false, Encoding.UTF8);
            StreamWriter sL = new StreamWriter(path + @"\DBLayout_Ext.log", false, Encoding.UTF8);

            string tblName = "";

            OracleConnection con = new OracleConnection(_DBConn);
            con.Open();

            string Query = "select * from user_tab_columns order by table_name, column_name";
            OracleCommand cmd = new OracleCommand(Query, con);
            OracleDataReader tdr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable tdt = new DataTable();
            tdt.Load(tdr);

            for (int i = 0; i < tdt.Rows.Count; i++)
            {
                DataRow fdr = tdt.Rows[i];
                tblName = fdr["TABLE_NAME"].ToString();
                if (!tblName.StartsWith("BIN$"))
                {
                    sw.WriteLine("FLD\b" + tblName + "\b" + fdr["COLUMN_NAME"].ToString()
                            + "\b" + fdr["DATA_TYPE"].ToString() + "\b" + fdr["DATA_LENGTH"].ToString()
                            + "\b" + fdr["DATA_PRECISION"].ToString() + "\b" + fdr["DATA_SCALE"].ToString());

                }
            }


            Query = "select table_name, index_name, uniqueness from user_indexes order by table_name, index_name";

            OracleCommand icmd = new OracleCommand(Query, con);
            OracleDataReader idr = icmd.ExecuteReader(CommandBehavior.Default);
            DataTable idt = new DataTable();
            idt.Load(idr);


            string indexName = "";

            for (int i = 0; i < idt.Rows.Count; i++)
            {
                DataRow fdr = idt.Rows[i];
                string isPrimaryKey = "";
                indexName = fdr["index_name"].ToString();
                tblName = fdr["table_name"].ToString();
                if (fdr["uniqueness"].ToString().StartsWith("U"))
                {
                    isPrimaryKey = "Y";
                }
                else
                {
                    isPrimaryKey = "N";

                }
                Query = "select column_name, descend from user_ind_columns ";
                Query += " where index_name=" + "'" + indexName + "'";
                OracleCommand icmd2 = new OracleCommand(Query, con);
                OracleDataReader idr2 = icmd2.ExecuteReader(CommandBehavior.Default);
                DataTable idt2 = new DataTable();
                idt2.Load(idr2);

                string colList = "";
                for (int j = 0; j < idt2.Rows.Count; j++)
                {
                    DataRow fdr2 = idt2.Rows[j];
                    if (!colList.Equals("")) { colList += ","; }
                    colList += fdr2["column_name"].ToString() + " " + fdr2["descend"].ToString();
                }
                sw.WriteLine("IND\b" + tblName + "\b" + indexName + "\b" + colList + "\b" + isPrimaryKey);


            }

            con.Close();
            sw.Close();
            sL.Close();
        }

        public static void Compare(string path1, string path2, string outpath, string type)
        {
            if (type == "SQL")
            {
                Compare_SQL(path1, path2, outpath);
            }
            else if (type == "Oracle")
            {
                Compare_Oracle(path1, path2, outpath);
            }
        }

        private static void Compare_SQL(string path1, string path2, string outpath)
        {
            try
            {
                if (Directory.Exists(outpath)) Directory.Delete(outpath, true);
                Directory.CreateDirectory(outpath);
                //比较两次，1->2,2->1
                //情况：////////////////表级别//////////////
                //-->1有2没有，2有1没有，
                if (File.Exists(outpath + @"\creatSQL.sqt")) File.Delete(outpath + @"\creatSQL.sqt");
                StreamWriter SQ = new StreamWriter(outpath + @"\creatSQL.sqt", true, Encoding.UTF8);
                List<string> file1 = File.ReadAllLines(path1 + @"\table.txt").ToList<string>();
                List<string> file2 = File.ReadAllLines(path2 + @"\table.txt").ToList<string>();

                //获取相同的
                List<string> data1and2 = file1.Intersect(file2).ToList<string>();
                //不同的表，这项直接输出就好
                //1有2没有
                List<string> data1not2 = file1.Except(file2).ToList<string>();
                //2有1没有
                List<string> data2not1 = file2.Except(file1).ToList<string>();

                if (data1not2.Count > 0) File.WriteAllLines(outpath + @"\源数据库有目标数据库没有的表.txt", data1not2.ToArray<string>());

                if (data2not1.Count > 0) File.WriteAllLines(outpath + @"\目标数据库有源数据库没有的表.txt", data2not1.ToArray<string>());
                //生成sql语句，创建源数据库有目标数据库没有的表

                //SQ.WriteLine("use DB2");
                foreach (string S in data1not2)
                {
                    SQ.WriteLine("create table " + S.Split('\b')[1] + "(SGID VARCHAR(14) DEFAULT '')");
                }


                #region  ////////////////////字段级别////////////////////-->两者不同
                //在相同的表中进行查询data1and2
                //对比字段
                List<string> field1_and = File.ReadAllLines(path1 + @"\field.txt").ToList<string>();
                List<string> field2_and = File.ReadAllLines(path2 + @"\field.txt").ToList<string>();
                //    //去除field中不是都有的表的字段，即把相同的单独拿出来
                //List<string> field1_and = new List<string>();
                //List<string> field2_and = new List<string>();
                #region 剔除两个文件中互相没有的表的字段   ------现在不用这一步，记录所有不同的为执行sql做基础
                //foreach (string f in field1)
                //{
                //    string[] fs = f.Split('\b');
                //    foreach(string t in data1and2)
                //    {
                //        if (fs[1] == t.Substring(t.IndexOf("\b")+1))
                //        {
                //            field1_and.Add(f);
                //        }
                //    }
                //}
                //foreach (string f in field2)
                //{
                //    string[] fs = f.Split('\b');
                //    foreach (string t in data1and2)
                //    {
                //        if (fs[1] == t.Substring(t.IndexOf("\b") + 1))
                //        {
                //            field2_and.Add(f);
                //        }
                //    }
                //}
                //now,field1_and,field2_and 两个数据库中都有的表中的字段
                #endregion

                List<string> jiaoji = field1_and.Intersect(field2_and).ToList<string>();
                foreach (string x in jiaoji)
                {
                    field1_and.Remove(x);
                }
                foreach (string x in jiaoji)
                {
                    field2_and.Remove(x);
                }
                //剩下的就是大家//***都有的表中**//具有差别的字段了，差别可能是类型长度、类型、字段名
                //从类型长度开始，比较出差别--->在之后的执行sql时，服务器端的长度小于目标数据库的话就忽略

                List<len> type = new List<len>();
                foreach (string f1 in field1_and)
                {//字段名相同但类型不同，可是不同的表中有相同的字段咋办@@截取的字段是表名加字段名的,要比较两词
                    //FIELDJQUEUEUSERCODEvarchar30,0
                    string fid1 = f1.Substring(0, f1.IndexOf('\b', f1.IndexOf('\b', 6) + 1));
                    foreach (string f2 in field2_and)
                    {
                        string fid2 = f2.Substring(0, f2.IndexOf('\b', f2.IndexOf('\b', 6) + 1));// FIELD\bTABLE\bCOLUMN
                        if (fid1 == fid2)
                        {   //说明数据格式不同
                            //需要加个判断varchar和demical相同的，不然比较varchar和demaical
                            len temp_len = new len();
                            //数据类型相同但精度不同//创建新表时用的是SGID 
                            if (f1.Split('\b')[3] == f2.Split('\b')[3])
                            {


                                //数据格式不同的话，需要记录下可不可以忽略
                                string l1 = f1.Substring(f1.LastIndexOf('\b') + 1);
                                string l2 = f2.Substring(f2.LastIndexOf('\b') + 1);
                                //发现还有image这种格式的，需要在比较的时候设置下
                                if (l1 == "," || l2 == ",") temp_len.ignore = true;
                                else
                                {
                                    if (int.Parse(l1.Split(',')[0]) <= int.Parse(l2.Split(',')[0]) && int.Parse(l1.Split(',')[1]) <= int.Parse(l2.Split(',')[1]))
                                    {
                                        temp_len.ignore = true;
                                    }
                                    else
                                        temp_len.ignore = false;
                                }
                            }
                            //数据类型直接就不同
                            else
                            {
                                temp_len.ignore = false;
                            }
                            temp_len.server = f1;
                            temp_len.client = f2;
                            type.Add(temp_len);
                        }


                    }
                }
                foreach (string f2 in field2_and)
                {//字段名相同但类型不同，可是不同的表中有相同的字段咋办@@截取的字段是表名加字段名的,要比较两词
                    //FIELDJQUEUEUSERCODEvarchar30,0
                    string fid2 = f2.Substring(0, f2.IndexOf('\b', f2.IndexOf('\b', 6) + 1));
                    foreach (string f1 in field1_and)
                    {
                        string fid1 = f1.Substring(0, f1.IndexOf('\b', f1.IndexOf('\b', 6) + 1));// FIELD\bTABLE\bCOLUMN
                        if (fid1 == fid2)
                        {   //说明数据格式不同
                            len temp_len = new len();
                            //数据类型相同但精度不同
                            if (f1.Split('\b')[3] == f2.Split('\b')[3])
                            {

                                //数据格式不同的话，需要记录下可不可以忽略
                                string l1 = f1.Substring(f1.LastIndexOf('\b') + 1);
                                string l2 = f2.Substring(f2.LastIndexOf('\b') + 1);
                                if (l1 == "," || l2 == ",") temp_len.ignore = true;
                                else
                                {
                                    if (int.Parse(l1.Split(',')[0]) <= int.Parse(l2.Split(',')[0]) && int.Parse(l1.Split(',')[1]) <= int.Parse(l2.Split(',')[1]))
                                    {
                                        temp_len.ignore = true;
                                    }
                                    else
                                        temp_len.ignore = false;
                                }
                            }
                            //数据类型直接就不同
                            else
                            {
                                temp_len.ignore = false;
                            }
                            temp_len.server = f1;
                            temp_len.client = f2;
                            if (type.Contains(temp_len)) { continue; }
                            else
                                type.Add(temp_len);
                        }


                    }
                }
                //if(type.Count>0) File.WriteAllLines(outpath + "字段类型不同.txt",type.ToArray<string>());
                List<string> length = new List<string>();
                //length.Add("数据类型不同的字段");
                foreach (len i in type)
                {
                    field1_and.Remove(i.server);
                    field2_and.Remove(i.client);
                    length.Add(i.server + "<->" + i.client + "<->" + i.ignore.ToString());
                    if (i.ignore == false)
                    {//以服务器为标准
                        string[] alter = i.server.Split('\b');
                        //alter table table_3 alter column SGID VARCHAR(10) 
                        if (alter[3] == "varchar" || alter[3] == "char")
                            SQ.WriteLine("alter table " + alter[1] + " alter column " + alter[2] + "  " + alter[3] + "(" + alter[4].Split(',')[0] + ")");
                        else if (alter[3] == "decimal" || alter[3] == "numeric")
                            SQ.WriteLine("alter table " + alter[1] + " alter column " + alter[2] + "  " + alter[3] + "(" + alter[4] + ")");
                        else
                            SQ.WriteLine("alter table " + alter[1] + " alter column " + alter[2] + "  " + alter[3]);

                    }
                }
                if (length.Count > 1) File.WriteAllLines(outpath + @"\字段类型不同.txt", length.ToArray<string>());
                //现在这里面是包含有没有的表中的不同的字段的
                if (field1_and.Count > 0) File.WriteAllLines(outpath + @"\源数据库有目标数据库没有字段.txt", field1_and.ToArray<string>());
                foreach (string S in field1_and)
                {
                    string[] alter = S.Split('\b');
                    if (alter[3] == "varchar" || alter[3] == "char")
                    {
                        if (alter[2] == "SGID") continue;
                        SQ.WriteLine("alter table " + alter[1] + " add " + alter[2] + "  " + alter[3] + "(" + alter[4].Split(',')[0] + ")  default ''");
                    }
                    else if (alter[3] == "decimal" || alter[3] == "numeric")
                        SQ.WriteLine("alter table " + alter[1] + " add " + alter[2] + "  " + alter[3] + "(" + alter[4] + ")  default 0");
                    else
                        SQ.WriteLine("alter table " + alter[1] + " add " + alter[2] + "  " + alter[3]);


                }
                if (field2_and.Count > 0) File.WriteAllLines(outpath + @"\目标数据库有源数据库没有字段.txt", field2_and.ToArray<string>());
                #endregion

                #region //比较索引咯~~~

                List<string> temp1 = File.ReadAllLines(path1 + @"\index.txt").ToList<string>();
                List<string> temp2 = File.ReadAllLines(path2 + @"\index.txt").ToList<string>();
                #region 剔除没有的表中的索引，只比较都有的表中的不同------现在不用这一步，为后续sql服务
                //List<string> temp1=new List<string>();//都有的表中的索引
                //List<string> temp2=new List<string> ();
                //foreach(string t in data1and2)
                //{
                //    foreach(string i1 in index1)
                //    {//INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY

                //        if(i1.Substring(4,i1.IndexOf('\b',4)-4)==t.Substring(t.IndexOf('\b')+1))
                //        {//表名
                //            temp1.Add(i1);
                //        }
                //    }
                //    foreach (string i2 in index2)
                //    {
                //        if (i2.Substring(4, i2.IndexOf('\b', 4)-4) == t.Substring(t.IndexOf('\b') + 1))
                //        {
                //            temp2.Add(i2);
                //        }
                //    }
                //}
                #endregion
                //找出两个表中索引相同的去掉
                //List<string> injiaoji = temp1.Intersect(temp2).ToList<string>();
                //foreach(string jj in injiaoji)
                //{
                //    temp1.Remove(jj);
                //    temp2.Remove(jj);
                //}
                //找出差集，代替去相同
                List<string> temp1_2_ex = temp1.Except(temp2).ToList<string>();
                List<string> temp2_1_ex = temp2.Except(temp1).ToList<string>();
                //剩下的要么就是你有他没有，要么就是字段类型不同，反正是差集
                //List<string> typei = new List<string>();
                #region 唯一性不同的
                Dictionary<string, string> dtype_unique = new Dictionary<string, string>();
                foreach (string t1 in temp1_2_ex)
                {//索引名名、列相同，但唯一性不同
                    string i1 = t1.Substring(0, t1.LastIndexOf('\b'));
                    // INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                    foreach (string t2 in temp2_1_ex)
                    {
                        string i2 = t2.Substring(0, t2.LastIndexOf('\b'));
                        if (i1 == i2)
                        {
                            dtype_unique.Add(t1, t2);
                        }
                    }
                }
                foreach (string t2 in temp2_1_ex)
                {//索引名名、列相同，但唯一性不同
                    string i2 = t2.Substring(0, t2.LastIndexOf('\b'));
                    // INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                    foreach (string t1 in temp1_2_ex)
                    {
                        string i1 = t1.Substring(0, t1.LastIndexOf('\b'));
                        if (i1 == i2)
                        {
                            if (dtype_unique.Keys.Contains(t1)) continue;
                            dtype_unique.Add(t1, t2);
                        }
                    }
                }
                //剔除所有仅仅唯一性不同的项
                foreach (var u in dtype_unique.Keys)
                {
                    temp1_2_ex.Remove(u);
                }
                foreach (var u in dtype_unique.Values)
                {
                    temp2_1_ex.Remove(u);
                }
                #endregion
                #region 索引列不同的
                //索引相同但列不同的
                Dictionary<string, string> dtype_col = new Dictionary<string, string>();
                foreach (string t1 in temp1_2_ex)
                {//索引名名相同但列不同，
                    string i1 = t1.Substring(0, t1.IndexOf('\b', t1.IndexOf('\b', 4) + 1));
                    // INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                    foreach (string t2 in temp2_1_ex)
                    {
                        string i2 = t2.Substring(0, t2.IndexOf('\b', t2.IndexOf('\b', 4) + 1));
                        if (i1 == i2)
                        {
                            dtype_col.Add(t1, t2);
                        }
                    }
                }
                foreach (string t2 in temp2_1_ex)
                {//取到列名
                    string i2 = t2.Substring(0, t2.IndexOf('\b', t2.IndexOf('\b', 4) + 1));
                    // INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                    foreach (string t1 in temp1_2_ex)
                    {
                        string i1 = t1.Substring(0, t1.IndexOf('\b', t1.IndexOf('\b', 4) + 1));
                        if (i1 == i2)
                        {
                            if (dtype_col.Keys.Contains(t1)) continue;
                            dtype_col.Add(t1, t2);
                        }
                    }
                }
                //剔除仅仅是咧不同的
                foreach (var c in dtype_col.Keys)
                {
                    temp1_2_ex.Remove(c);
                }
                foreach (var c in dtype_col.Values)
                {
                    temp2_1_ex.Remove(c);
                }
                #endregion
                #region 索引名不同  ---这个并不需要比较，索引名不同不就是你有我没有吗，真尼玛蠢啊
                ////////////////找出索引名不同的
                //Dictionary<string, string> dtype_name = new Dictionary<string, string>();
                //foreach (string t1 in temp1_2_ex)
                //{//索引名不同
                //    string i1 = t1.Substring(0,  t1.IndexOf('\b', 4) );
                //    // INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                //    foreach (string t2 in temp2_1_ex)
                //    {
                //        string i2 = t2.Substring(0, t2.IndexOf('\b', 4));
                //        if (i1 == i2)
                //        {
                //            dtype_name.Add(t1, t2);
                //        }
                //    }
                //}
                //foreach (string t2 in temp2_1_ex)
                //{//索引名名相同但类型不同，可是不同的表中有相同的字段咋办@@截取的字段是表名加字段名的
                //    string i2 = t2.Substring(0,  t2.IndexOf('\b', 4));
                //    // INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                //    foreach (string t1 in temp1_2_ex)
                //    {
                //        string i1 = t1.Substring(0, t1.IndexOf('\b', 4) );
                //        if (i1 == i2)
                //        {
                //            if (dtype_col.Keys.Contains(t1)) continue;
                //            dtype_name.Add(t1, t2);
                //        }
                //    }
                //}
                ////剔除索引名不同的
                //foreach (var n in dtype_name.Keys)
                //{
                //    temp1_2_ex.Remove(n);
                //}
                //foreach (var n in dtype_name.Values)
                //{
                //    temp2_1_ex.Remove(n);
                //}
                #endregion
                /////////////////////
                //既然都是相同的表，那剩下的就是互相没有的索引了
                //输出至文件
                if (File.Exists(outpath + @"\索引不同.txt")) File.Delete(outpath + @"\索引不同.txt");
                using (StreamWriter sw = new StreamWriter(outpath + @"\索引不同.txt", true, Encoding.UTF8))
                {
                    sw.WriteLine("源数据库有而目标数据库没有的索引");
                    foreach (string ex in temp1_2_ex)
                    {
                        sw.WriteLine(ex);
                        string[] ind = ex.Split('\b');
                        if (ind[4] == "N")
                            SQ.WriteLine("create index " + ind[2] + "  on " + ind[1] + "(" + ind[3] + ")");
                        else
                            SQ.WriteLine("create unique index " + ind[2] + "  on " + ind[1] + "(" + ind[3] + ")");

                    }
                    sw.WriteLine("目标数据库有而源数据库没有的索引");
                    foreach (string ex in temp2_1_ex)
                    {
                        sw.WriteLine(ex);
                    }
                    sw.WriteLine("索引键列不同：\n");
                    foreach (string k in dtype_col.Keys)
                    {//INDGSY_TREETMPGSY2050D_WYCCODE,DOCID,LX,PCODEY
                        sw.WriteLine(k + "\b<->\b" + dtype_col[k]);
                        string[] ind = k.Split('\b');
                        SQ.WriteLine("drop index " + ind[2] + " on " + ind[1]);
                        if (ind[4] == "N")
                            SQ.WriteLine("create index " + ind[2] + "  on " + ind[1] + "(" + ind[3] + ")");
                        else
                            SQ.WriteLine("create unique index " + ind[2] + "  on " + ind[1] + "(" + ind[3] + ")");

                    }
                    sw.WriteLine("索引唯一性不同的：\n");
                    foreach (string k in dtype_unique.Keys)
                    {
                        sw.WriteLine(k + "\b<->\b" + dtype_unique[k]);
                        string[] ind = k.Split('\b');
                        SQ.WriteLine("drop index " + ind[2] + " on " + ind[1]);
                        if (ind[4] == "N")
                            SQ.WriteLine("create index " + ind[2] + "  on " + ind[1] + "(" + ind[3] + ")");
                        else
                            SQ.WriteLine("create unique index " + ind[2] + "  on " + ind[1] + "(" + ind[3] + ")");

                    }
                }
                #endregion
                SQ.Close();
                MessageBox.Show("比较完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("比较遇到问题，请检查文件是否存在或其他未知原因！");
            }
        }
        private static void Compare_Oracle(string path1, string path2, string outpath)
        {

        }


        public static void runSQL(string sqlpath, string sqlcon)
        {
            //string sqlcon = "data source=" + dsrc + ";initial catalog=" + dbset + ";user id=" + user + "; pwd=" + pwd + "";
            //string sqlcon = "Data Source=WANJQ\\SQLEXPRESS;Initial Catalog=test;Integrated Security=True";
            //string sqlcon = "data source=127.0.0.1;initial catalog=DBName;user id=sa; pwd=xxx";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            conn.ConnectionString = sqlcon;
            //conn.Open();
            cmd.Connection = conn;
            string sqlfile = sqlpath + @"\creatSQL.sqt";
            StreamWriter sl = new StreamWriter(sqlpath + @"\sqllog.log", true, Encoding.UTF8);
            try
            {
                cmd.Connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据库连接错误," + ex.ToString());

            }

            // StreamReader sr=new StreamReader(sqlfile);
            using (StreamReader sr = new StreamReader(sqlfile))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {

                    try
                    {

                        cmd.CommandText = s;
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        sl.WriteLine(DateTime.Now.ToString() + "@" + ex.ToString());
                    }
                }
            }
            cmd.Connection.Close();
            sl.Close();
            // sr.Close();

        }
    }
}
