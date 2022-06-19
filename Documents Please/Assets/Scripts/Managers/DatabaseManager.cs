using Mono.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Database Manager", menuName = "Scriptable Objects/Database manager")]
public class DatabaseManager : ScriptableObject
{
    public void AddNewsArticles(List<NewsArticle> newsArticles, bool isFake)
    {
        try
        {
            // Insert hits into the table.
            IDbConnection dbConnection = CreateAndOpenDatabase();
            IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();

            StringBuilder sourcesBuilder = new("INSERT OR REPLACE INTO Source (source, isFake) VALUES ");
            foreach (NewsArticle newsArticle in newsArticles)
            {
                sourcesBuilder.Append("('" + newsArticle.source + "', " + !isFake + "),");
            }
            string sourcesQuery = sourcesBuilder.ToString();
            sourcesQuery = sourcesQuery.Remove(sourcesQuery.Length - 1);

            Debug.Log(sourcesQuery);
            dbCommandInsertValue.CommandText = sourcesQuery;
            dbCommandInsertValue.ExecuteNonQuery();

            StringBuilder authorsBuilder = new("INSERT OR REPLACE INTO Author (author, isFake) VALUES ");
            foreach (NewsArticle newsArticle in newsArticles)
            {
                authorsBuilder.Append("('" + newsArticle.author + "', " + !isFake + "),");
            }
            string authorsQuery = authorsBuilder.ToString();
            authorsQuery = authorsQuery.Remove(authorsQuery.Length - 1);

            dbCommandInsertValue.CommandText = authorsQuery;
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
