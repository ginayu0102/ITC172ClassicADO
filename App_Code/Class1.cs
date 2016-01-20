using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BookAndAuthor
{
    SqlConnection connect;
    public BookAndAuthor()
	{
        connect = new SqlConnection(ConfigurationManager.ConnectionStrings["BookReviewDbConnectionString"].ToString());
	}

    public DataTable GetAuthor()
    {
        string sql = "Select AuthorKey, AuthorName from Author";
        DataTable tbl;
        SqlCommand cmd = new SqlCommand(sql, connect);

        try
        {
            tbl = ProcessQuery(cmd);
        }
        catch(Exception ex)
        {
            throw ex;
        }
        return tbl;
    }

    public DataTable GetBooks(int AuthorKey)
    {
        string sql = "Select * from Book inner join AuthorBook on Book.BookKey=AuthorBook.BookKey where AuthorKey =@AuthorKey";
        SqlCommand cmd = new SqlCommand(sql, connect);
        cmd.Parameters.Add("@AuthorKey", AuthorKey);

        DataTable tbl;
        try
        {
            tbl = ProcessQuery(cmd);

        }
        catch (Exception ex)
        {
            throw ex;
        }

        return tbl;

    }

    private DataTable ProcessQuery(SqlCommand cmd) 
    {
        DataTable table = new DataTable();
        SqlDataReader reader;
        try 
        {
            connect.Open();
            reader = cmd.ExecuteReader();
            table.Load(reader);
            connect.Close();

        }
        catch(Exception ex)
        {
            throw ex;

        }
        return table;
    }


}