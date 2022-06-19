using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Manager", menuName = "Scriptable Objects/Database Manager")]
public class DatabaseManager : ScriptableObject
{
    //public DatabaseManager()
    //{
    //    IDbConnection dbConnection = CreateAndOpenDatabase();
        
    //    // Remember to always close the connection at the end.
    //    dbConnection.Close();
    //}

    //void Start()
    //{
    //    IDbConnection dbConnection = CreateAndOpenDatabase();
        
    //    // Remember to always close the connection at the end.
    //    dbConnection.Close();
    //}

    public void AddAuthor(NewsArticle newsArticle, bool isFake) 
    {
        try {
            Debug.Log("Adding author: " + newsArticle.author);
            // Insert hits into the table.
            IDbConnection dbConnection = CreateAndOpenDatabase();
            IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();
            dbCommandInsertValue.CommandText = "INSERT OR REPLACE INTO Author (author, isFake) VALUES ( '" + newsArticle.author + "', " + !isFake + ")";
            dbCommandInsertValue.ExecuteNonQuery(); 

            // Remember to always close the connection at the end.
            dbConnection.Close(); 
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }
    public void AddSource(NewsArticle newsArticle, bool isFake)
    {
        try
        {
            Debug.Log("Adding source: " + newsArticle.source);
            // Insert hits into the table.
            IDbConnection dbConnection = CreateAndOpenDatabase(); 
            IDbCommand dbCommandInsertValue = dbConnection.CreateCommand(); 
            dbCommandInsertValue.CommandText = "INSERT OR REPLACE INTO Source (source, isFake) VALUES ( '" + newsArticle.source + "', " + !isFake + ")"; 
            dbCommandInsertValue.ExecuteNonQuery(); 

            // Remember to always close the connection at the end.
            dbConnection.Close(); 
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }
    public bool? GetAuthor(string author) {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand();
        dbCommandReadValues.CommandText = "SELECT * FROM Author WHERE author = '" + author + "'";
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();
        bool isFake;
        while (dataReader.Read()) 
        {
            isFake = dataReader.GetBoolean(2);
            return isFake;
            //Debug.Log(dataReader.GetBoolean(2));
        }
        dbConnection.Close(); 
        return null;
    }
    public bool? GetSource(string source)
    {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand(); 
        dbCommandReadValues.CommandText = "SELECT * FROM Source WHERE source = '" + source + "'"; 
        IDataReader dataReader = dbCommandReadValues.ExecuteReader();
        bool isFake;
        while (dataReader.Read()) 
        {
            isFake = dataReader.GetBoolean(2);
            return isFake;
            //Debug.Log(dataReader.GetBoolean(2));
        }
        dbConnection.Close();
        return null;
    }
    private IDbConnection CreateAndOpenDatabase() 
    {
        // Open a connection to the database.
        string dbUri = "URI=file:MyDatabase.sqlite"; 
        IDbConnection dbConnection = new SqliteConnection(dbUri); 
        dbConnection.Open(); 

        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); 
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Author (id INTEGER PRIMARY KEY, author STRING UNIQUE, isFake BOOLEAN )"; 
        dbCommandCreateTable.ExecuteReader(); 
        IDbCommand dbCommandCreateTable2 = dbConnection.CreateCommand(); 
        dbCommandCreateTable2.CommandText = "CREATE TABLE IF NOT EXISTS Source (id INTEGER PRIMARY KEY, source STRING UNIQUE, isFake BOOLEAN )";
        dbCommandCreateTable2.ExecuteReader();
        return dbConnection;
    }
}
