using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

public class DBSingleton
{

    private static DBSingleton dbinstance;
    private static IDbConnection conn = null;
    private static IDbCommand cmd = null;
    private string connString = "URI=file:" + Application.dataPath + "/Code/Data/JourneyToEnlightenment.db";
    private static StateSingleton ss;
    public enum BellType {Awareness, Air, Fire, Water, Earth, Enlightenment};

    public static DBSingleton get()
    {
        if (dbinstance == null)
        {
            dbinstance = new DBSingleton();
        }
        Debug.Log("Connected to DBSingleton...");
        return dbinstance;
    }

    public IDbConnection getConn()
    {
        if (conn == null)
        {
            Debug.Log("Creating Connection...");
            conn = (IDbConnection)new SqliteConnection(connString);
            conn.Open();
            if (conn == null)
            {
                Debug.LogError("ERROR: Database not found.");
            }
            return conn;
        }
        else if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
        {
            Debug.Log("Recreating Connection...");
            conn = (IDbConnection)new SqliteConnection(connString);
            conn.Open();
            if (conn == null)
            {
                Debug.LogError("ERROR: Database not found.");
            }
            return conn;
        }
        else if (conn.State == ConnectionState.Open)
        {
            return conn;
        }
        else
        {
            Debug.LogError("Trying to execute new query before one has finished");
            return null;
        }
    }
    public void closeConn()
    {
        if (conn.State == ConnectionState.Open)
        {
            Debug.Log("Closing Connection...");
            conn.Close();
            conn = null;
        }
    }

    public IDbCommand getCmd()
    {
        if (conn == null)
        {
            Debug.LogError("ERROR: No Connection Esdtablished");
            return null;
        }
        else if (cmd == null)
        {
            cmd = conn.CreateCommand();
        }
        else if (cmd.CommandText != null)
        {
            cmd.Dispose();
            cmd = conn.CreateCommand();
        }
        return cmd;
    }

    public void closeCommand()
    {
        if (cmd != null)
        {
            cmd.Dispose();
            cmd = null;
        }
    }

    public int createNewPlayer(string name)
    {
        conn = getConn();
        cmd = getCmd();
        Debug.Log("Creating User...");
        cmd.CommandText = "INSERT INTO Player (Name) Values (\"" + name + "\");";
        cmd.ExecuteNonQuery();
        cmd.CommandText = "SELECT UID FROM Player ORDER BY UID DESC";
        IDataReader reader = cmd.ExecuteReader();
        reader.Read();
        int id = reader.GetInt32(0);
        reader.Close();
        Debug.Log("User " + name + " has been created with user id: " + id);
        return id;
    }

    public int deletePlayer(int uid)
    {
        conn = getConn();
        cmd = getCmd();
        Debug.Log("Deleting User...");
        cmd.CommandText = "Delete FROM Player Where UID = " + uid;
        int result = cmd.ExecuteNonQuery();
        if (result > 0)
            return result;
        else
        {
            Debug.LogError("User could not be deleted");
            return -1;
        }
    }

    public List<int> loadPlayers()
    {
        conn = getConn();
        cmd = getCmd();
        Debug.Log("Fetching Users...");
        cmd.CommandText = "SELECT UID FROM Player";
        IDataReader reader = cmd.ExecuteReader();
        List<int> players = new List<int>();
        while (reader.Read())
        {
            players.Add(reader.GetInt32(0));
        }
        return players;
    }

    public void setBells()
    {
        ss = StateSingleton.get();
        conn = getConn();
        cmd = getCmd();
        cmd.CommandText = "SELECT Awareness,Air,Fire,Water,Earth,Enlightenment from Player where UID = " + ss.uid;
        Debug.Log(cmd.CommandText);
        IDataReader reader = cmd.ExecuteReader();
        reader.Read();
        int[] bells = new int[6];
        for (int i = 0; i < bells.Length; i++)
        {
            bells[i] = reader.GetInt32(i);
        }
        reader.Close();
        ss.setBells(bells);
        Debug.Log("Loaded Bells to Player " + ss.uid);
    }

    public int updateBell(BellType bellNum)
    {
        ss = StateSingleton.get();
        conn = getConn();
        cmd = getCmd();
        cmd.CommandText = "UPDATE Player SET " + bellNum + "  =  1 WHERE UID = " + ss.uid;
        if (cmd.ExecuteNonQuery() > 0)
        {
            Debug.Log("Updated Bell...");
            return 1;
        }else
        {
            Debug.LogError("Failed to Update Bell");
            return 0;
        }  
    }


}

