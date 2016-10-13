using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System;
using System.Data;
//Copy from http://bbs.9ria.com/thread-216915-1-1.html
public class SqliteDbHelper
{

    private SqliteConnection dbConnection;

    private SqliteCommand dbCommand;

    private SqliteDataReader reader;
    /// <summary>
    /// Connection String of database, used for creating a connection to specific database
    /// </summary>
    /// <param name="connectionString">Connection String of database, used for creating a connection to specific database</param>
    public SqliteDbHelper(string connectionString)
    {
        OpenDB(connectionString);
        Debug.Log(connectionString);
    }
    public void OpenDB(string connectionString)
    {
        try
        {
            dbConnection = new SqliteConnection(connectionString);
            dbConnection.Open();
            Debug.Log("Connected to db");
        }
        catch (Exception e)
        {
            string temp1 = e.ToString();
            Debug.Log(temp1);
        }
    }
    /// <summary>
    /// Close connection
    /// </summary>
    public void CloseSqlConnection()
    {
        if (dbCommand != null)
        {
            dbCommand.Dispose();
        }
        dbCommand = null;
        if (reader != null)
        {
            reader.Dispose();
        }
        reader = null;
        if (dbConnection != null)
        {
            dbConnection.Close();
        }
        dbConnection = null;
        Debug.Log("Disconnected from db.");
    }
    /// <summary>
    /// run sqlite command
    /// </summary>
    /// <param name="sqlQuery"></param>
    /// <returns></returns>
    public SqliteDataReader ExecuteQuery(string sqlQuery)
    {
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = sqlQuery;
        reader = dbCommand.ExecuteReader();
        return reader;
    }
    /// <summary>
    /// select all data from table
    /// </summary>
    /// <param name="tableName">table name</param>
    /// <returns></returns>
    public SqliteDataReader ReadFullTable(string tableName)
    {
        string query = "SELECT * FROM " + tableName;
        return ExecuteQuery(query);
    }
    /// <summary>
    /// Insert values into specfic table
    /// </summary>
    /// <param name="tableName">table name</param>
    /// <param name="values">values</param>
    /// <returns></returns>
    public SqliteDataReader InsertInto(string tableName, string[] values)
    {
        string query = "INSERT INTO " + tableName + " VALUES (" + values[0];
        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + values[i];
        }
        query += ")";
        Debug.Log(query);
        return ExecuteQuery(query);
    }
    /// <summary>
    /// Update data in table
    /// </summary>
    /// <param name="tableName">table name</param>
    /// <param name="cols">col name</param>
    /// <param name="colsvalues">col value</param>
    /// <param name="selectkey">the key that be selected</param>
    /// <param name="selectvalue">the value that be selected</param>
    /// <returns></returns>
    public SqliteDataReader UpdateInto(string tableName, string[] cols,
      string[] colsvalues, string selectkey, string selectvalue)
    {
        string query = "UPDATE " + tableName + " SET " + cols[0] + " = " + colsvalues[0];
        for (int i = 1; i < colsvalues.Length; ++i)
        {
            query += ", " + cols[i] + " =" + colsvalues[i];
        }
        query += " WHERE " + selectkey + " = " + selectvalue + " ";
        return ExecuteQuery(query);
    }
    /// <summary>
    /// delete data in table
    /// </summary>
    /// <param name="tableName">table name</param>
    /// <param name="cols">col name</param>
    /// <param name="colsvalues">col value</param>
    /// <returns></returns>
    public SqliteDataReader Delete(string tableName, string[] cols, string[] colsvalues)
    {
        string query = "DELETE FROM " + tableName + " WHERE " + cols[0] + " = " + colsvalues[0];
        for (int i = 1; i < colsvalues.Length; ++i)
        {
            query += " or " + cols[i] + " = " + colsvalues[i];
            Debug.Log(cols[i]);
        }
        Debug.Log(query);
        return ExecuteQuery(query);
    }
    /// <summary>
    /// Insert values into specfic col in table
    /// </summary>
    /// <param name="tableName">table name</param>
    /// <param name="cols">col name</param>
    /// <param name="values">col value</param>
    /// <returns></returns>
    public SqliteDataReader InsertIntoSpecific(string tableName, string[] cols,
     string[] values)
    {
        if (cols.Length != values.Length)
        {
            throw new SqliteException("columns.Length != values.Length");
        }
        string query = "INSERT INTO " + tableName + "(" + cols[0];
        for (int i = 1; i < cols.Length; ++i)
        {
            query += ", " + cols[i];
        }
        query += ") VALUES (" + values[0];
        for (int i = 1; i < values.Length; ++i)
        {
            query += ", " + values[i];
        }
        query += ")";
        Debug.Log(query);
        return ExecuteQuery(query);
    }
    /// <summary>
    /// delete table
    /// </summary>
    /// <param name="tableName">table name</param>
    /// <returns></returns>
    public SqliteDataReader DeleteContents(string tableName)
    {
        string query = "DELETE FROM " + tableName;
        return ExecuteQuery(query);
    }
    /// <summary>
    /// create table
    /// </summary>
    /// <param name="name">table name</param>
    /// <param name="col">col name</param>
    /// <param name="colType">col type</param>
    /// <returns></returns>
    public SqliteDataReader CreateTable(string name, string[] col, string[] colType)
    {
        if (col.Length != colType.Length)
        {
            throw new SqliteException("columns.Length != colType.Length");
        }
        string query = "CREATE TABLE " + name + " (" + col[0] + " " + colType[0];
        for (int i = 1; i < col.Length; ++i)
        {
            query += ", " + col[i] + " " + colType[i];
        }
        query += ")";
        Debug.Log(query);
        return ExecuteQuery(query);
    }
    /// <summary>
    /// check if table existed
    /// </summary>
    /// <param name="name">table name</param>
    /// <returns>true if table existed</returns>
    public Boolean CheckTable(string name)
    {
        string query = "select * from sqlite_master where name=" + "'" + name + "'";
        Debug.Log(query);
        SqliteDataReader data=ExecuteQuery(query);
        if (data.Read())
        {
            data.Close();
            return true;
        }
        else {
            data.Close();
            return false;
        }
    }
    /// <summary>
    /// select data from table
    /// </summary>
    /// <param name="tableName">table name<</param>
    /// <param name="items">data collection</param>
    /// <param name="col">col name</param>
    /// <param name="operation">operation</param>
    /// <param name="values">value</param>
    /// <returns></returns>
    public SqliteDataReader SelectWhere(string tableName, string[] items, string[] col, string[] operation, string[] values)
    {
        if (col.Length != operation.Length || operation.Length != values.Length)
        {
            throw new SqliteException("col.Length != operation.Length != values.Length");
        }
        string query = "SELECT " + items[0];
        for (int i = 1; i < items.Length; ++i)
        {
            query += ", " + items[i];
        }
        query += " FROM " + tableName + " WHERE " + col[0] + operation[0] + "'" + values[0] + "' ";
        for (int i = 1; i < col.Length; ++i)
        {
            query += " AND " + col[i] + operation[i] + "'" + values[0] + "' ";
        }
        return ExecuteQuery(query);
    }
}