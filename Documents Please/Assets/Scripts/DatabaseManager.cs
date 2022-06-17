using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DatabaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        
        GetAuthor("Test");
        // Remember to always close the connection at the end.
        dbConnection.Close();
    }

    public void AddAuthor(string author, bool isFake) 
    {
        try {
        // Insert hits into the table.
        IDbConnection dbConnection = CreateAndOpenDatabase(); // 2
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand(); // 9
        dbCommandInsertValue.CommandText = "INSERT INTO Author (author, isFake) VALUES ( '" + author + "', " + isFake + ")"; // 10
        dbCommandInsertValue.ExecuteNonQuery(); // 11

            // Remember to always close the connection at the end.
        dbConnection.Close(); // 12
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
    }
    public void AddSource(string source, bool isFake)
    {
        try
        {
            // Insert hits into the table.
            IDbConnection dbConnection = CreateAndOpenDatabase(); // 2
            IDbCommand dbCommandInsertValue = dbConnection.CreateCommand(); // 9
            dbCommandInsertValue.CommandText = "INSERT INTO Source (author, isFake) VALUES ( '" + source + "', " + isFake + ")"; // 10
            dbCommandInsertValue.ExecuteNonQuery(); // 11

            // Remember to always close the connection at the end.
            dbConnection.Close(); // 12
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }

    }
    public void GetAuthor(string author) {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand(); // 15
        dbCommandReadValues.CommandText = "SELECT * FROM Author WHERE author = '" + author + "'"; // 16
        IDataReader dataReader = dbCommandReadValues.ExecuteReader(); // 17

        while (dataReader.Read()) // 18
        {
            // The `id` has index 0, our `hits` have the index 1.
            Debug.Log(dataReader.GetBoolean(2)); // 19
        }
        dbConnection.Close(); // 20
    }
    public void GetSource(string source)
    {
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandReadValues = dbConnection.CreateCommand(); // 15
        dbCommandReadValues.CommandText = "SELECT * FROM Source WHERE source = '" + source + "'"; // 16
        IDataReader dataReader = dbCommandReadValues.ExecuteReader(); // 17

        while (dataReader.Read()) // 18
        {
            // The `id` has index 0, our `hits` have the index 1.
            Debug.Log(dataReader.GetBoolean(2)); // 19
        }
        dbConnection.Close(); // 20
    }
    private IDbConnection CreateAndOpenDatabase() // 3
    {
        // Open a connection to the database.
        string dbUri = "URI=file:MyDatabase.sqlite"; // 4
        IDbConnection dbConnection = new SqliteConnection(dbUri); // 5
        dbConnection.Open(); // 6

        // Create a table for the hit count in the database if it does not exist yet.
        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand(); // 6
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS Author (id INTEGER PRIMARY KEY, author STRING UNIQUE, isFake BOOLEAN )"; // 7
        dbCommandCreateTable.ExecuteReader(); // 8
        IDbCommand dbCommandCreateTable2 = dbConnection.CreateCommand(); // 6
        dbCommandCreateTable2.CommandText = "CREATE TABLE IF NOT EXISTS Source (id INTEGER PRIMARY KEY, source STRING UNIQUE, isFake BOOLEAN )"; // 7
        dbCommandCreateTable2.ExecuteReader(); // 8
        return dbConnection;
    }
}
