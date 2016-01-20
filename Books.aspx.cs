using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Books : System.Web.UI.Page
{
    BookAndAuthor ba = new BookAndAuthor();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            FillDropDownList();
    }
    protected void authorDropDownList_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGridView();
    }

    protected void FillDropDownList()
    {
        DataTable table = null;

        try
        {
            table = ba.GetAuthor();
        }

        catch (Exception ex)
        {
            ErrorLabel.Text=ex.Message;
        }
        authorDropDownList.DataSource = table;
        authorDropDownList.DataTextField = "AuthorName";
        authorDropDownList.DataValueField = "AuthorKey";
        authorDropDownList.DataBind();


    }

    protected void FillGridView()
    {
        int BookKey = int.Parse(authorDropDownList.SelectedValue.ToString());
        DataTable tbl = null;
        
        try
        {
            tbl = ba.GetBooks(BookKey);
        }
        catch(Exception ex)
        {
            ErrorLabel.Text = ex.Message;
        }

        authorGridView.DataSource = tbl;
        authorGridView.DataBind();
    }
}