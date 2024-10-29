using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;
using System.Data;
using System.IO;
using Unity.VisualScripting;

public class AccessPoint : MonoBehaviour
{
    static SqliteConnection dbconect;
    private SqliteCommand command = new SqliteCommand();
    static string pathsql;
    static string fn1 = "db.bytes";
    void Start()
    {
        pathsql = Application.dataPath + "/StreamingAssets/" + fn1;
        pathsql = "Data Source=" + pathsql;
        dbconect = new SqliteConnection(pathsql);
        ReadTable();
        /* string filepath = "C:\\pro" + fn1;
         pathsql = "URI=file:" + filepath;
         dbconect = new SqliteConnection(pathsql);
         ReadTable();*/
    }

    public void ReadTable()
    {
        using (dbconect = new SqliteConnection(pathsql))
        {
            dbconect.Open();
            if (dbconect.State == ConnectionState.Open)
            {
                command.Connection = dbconect;
                string scoreboard = ("SELECT * FROM global");

                command.CommandText = scoreboard;
                SqliteDataReader r= command.ExecuteReader();
                List<string> str = new List<string>();
                while(r.Read())
                {
                    str.Add(String.Format("{1},{2},{3},{4};", r[0], r[1], r[2], r[3], r[4])) ;
                }
                foreach (string str2 in str)
                {
                    Debug.Log(str2);
                }
            }
            else { Debug.Log("Error"); }
        }
    }

    static void CopyStart()
    {

        pathsql = Application.dataPath + "/StreamingAssets/" + fn1;
        pathsql = "Data Source=" + pathsql;
        dbconect = new SqliteConnection(pathsql);
    }
    

    internal static int chekingNull() //—четчик человек в списке
    {
        SqliteCommand command0 = new SqliteCommand();
        CopyStart();
        int zn = -1;
        using (SqliteConnection dbconect0 = new SqliteConnection(pathsql))
        {
            dbconect0.Open();
            if (dbconect0.State == ConnectionState.Open)
            {
                command0.Connection = dbconect0;
             
                string scoreboard = ("SELECT COUNT(*) FROM global;");
                command0.CommandText = scoreboard;
                object r = command0.ExecuteScalar();
                int f = Convert.ToInt32(r);
                if (f>=0)
                {
                    zn = f;
                }
            }
            else { Debug.Log("Error"); }
        }
        return zn;
    }
    internal static string[] UserSearch2(int idBC) //ListUsers !!!!!
    {
        string[] fil = new string[5];
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT surname,name,groupm,level,data FROM global WHERE id LIKE '" + idBC + "';");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    fil[0] = r[0].ToString();
                    fil[1] = r[1].ToString();
                    fil[2] = r[2].ToString();
                    fil[3] = r[3].ToString();
                    fil[4] = r[4].ToString();
                }
                else { Debug.Log("Error"); }

            }
            else { Debug.Log("Error"); }
        }
        return fil;
    }

    internal static void AUbd2(string[] catalog) //ListUser2 !!!
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();

        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {

                command2.Connection = dbconect2;
                string scoreboard = ("DELETE FROM global WHERE surname = '"+ catalog[0] + "' AND name = '" + catalog[1] + "' AND groupm = '" + catalog[2] + "';");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }

        }
    }
    internal static void UpdateId(int count, string[] catalog) //ListUser2 !!!
    {
        SqliteCommand command2 = new SqliteCommand();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                
                    command2.Connection = dbconect2;
                    string scoreboard = ("UPDATE global SET id='" + count + "' WHERE surname = '" + catalog[0] + "' AND name = '" + catalog[1] + "' AND groupm = '" + catalog[2] + "';");
                    command2.CommandText = scoreboard;
                    command2.ExecuteNonQuery();
                
            }
            else { Debug.Log("Error"); }

        }
    }




    internal static int UserSearch2(string famBC, string nameBC, string groupBC) //AddUsers!!!
    {
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        int zn=0;
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT id FROM global WHERE name= '" + nameBC + "' AND surname= '" + famBC + "' AND groupm= '" + groupBC + "';");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    zn = 1;
                }
                else {  zn = 0; }

            }
            else { Debug.Log("Error"); }
        }
        return zn;
    }
    internal static void addUser(string[] fil) //AddUsers !!!!
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        int idbr=chekingNull();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                string scoreboard = ("INSERT INTO global (id,surname,name,groupm,level,data) VALUES (" + (idbr+1)+",'" + fil[0] + "','" + fil[1] + "','" + fil[2] + "',0,'0');");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }

    internal static void DeleteBD() //formatData
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        int idbr = chekingNull();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                string scoreboard = ("DELETE FROM global WHERE id!=0;");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }
    internal static string[] UserSearch(string nameBC, string famBC, string groupBC) //MainEntrance
    {
        string[] fil = new string[3];
        SqliteCommand command1 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect1 = new SqliteConnection(pathsql))
        {
            dbconect1.Open();
            if (dbconect1.State == ConnectionState.Open)
            {
                command1.Connection = dbconect1;
                string scoreboard = ("SELECT id,level,data FROM global WHERE name = '" + nameBC + "' AND surname = '" + famBC + "' AND groupm = '" + groupBC + "'");
                command1.CommandText = scoreboard;
                SqliteDataReader r = command1.ExecuteReader();
                if (r.HasRows)
                {
                    fil[0] = r[0].ToString();
                    fil[1] = r[1].ToString();
                    fil[2] = r[2].ToString();
                }
                else
                {
                    fil[0] = "";
                    fil[1] = "";
                    fil[2] = "";
                }

            }
            else { Debug.Log("Error"); }
        }
        return fil;
    }

    internal static void UpdateBD(string[] catalog) //MainEntrance 
    {
        SqliteCommand command2 = new SqliteCommand();
        CopyStart();
        using (SqliteConnection dbconect2 = new SqliteConnection(pathsql))
        {
            dbconect2.Open();
            if (dbconect2.State == ConnectionState.Open)
            {
                command2.Connection = dbconect2;
                string scoreboard = ("UPDATE global SET level='" + catalog[1] + "', data='" + catalog[2] + "' WHERE id = " + catalog[0] + ";");
                command2.CommandText = scoreboard;
                command2.ExecuteNonQuery();
            }
            else { Debug.Log("Error"); }
        }
    }


}
