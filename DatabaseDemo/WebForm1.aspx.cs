using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;

namespace DatabaseDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
                FillDDL();
            }
        }

        private void FillDDL()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LabWork\NET\DatabaseDemo\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT EMPID FROM EMPTABLE";

            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            ddlEmpId.Items.Clear();
            while (dr.Read())
            {
                ddlEmpId.Items.Add(dr[0].ToString());
            }
                  


            con.Close();
        
        }

        private void FillGrid()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LabWork\NET\DatabaseDemo\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from EmpTable";

            con.Open();
            SqlDataReader dr= cmd.ExecuteReader();
            gvEmp.DataSource = dr;
            gvEmp.DataBind();
            dr.Close();
            con.Close();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LabWork\NET\DatabaseDemo\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Insert into EmpTable values(@eid,@ename,@ecity,@esal)";
                cmd.Parameters.AddWithValue("@eid", txtEmpid.Text);
                cmd.Parameters.AddWithValue("@ename", txtEmpName.Text);
                cmd.Parameters.AddWithValue("@ecity", txtEmpCity.Text);
                cmd.Parameters.AddWithValue("@esal", txtEmpSalary.Text);

                con.Open();
                int i = cmd.ExecuteNonQuery();


                if (i > 0)
                {
                    Response.Write("Record Inserted");
                    FillGrid();
                    FillDDL();
                    txtEmpid.Text = "";
                    txtEmpName.Text = "";
                    txtEmpCity.Text = "";
                    txtEmpSalary.Text = "";

                }
                else
                {
                    Response.Write("Something went wrong");
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex.Message);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\LabWork\NET\DatabaseDemo\EmployeeDB.mdf;Integrated Security=True;Connect Timeout=30";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from EmpTable where EmpID=@eid";
                cmd.Parameters.AddWithValue("@eid", txtEmpid.Text);
              

                con.Open();
                int i = cmd.ExecuteNonQuery();


                if (i > 0)
                {
                    Response.Write("Record Deleted");
                    FillGrid();
                    FillDDL();
                    txtEmpid.Text = "";
                    txtEmpName.Text = "";
                    txtEmpCity.Text = "";
                    txtEmpSalary.Text = "";

                }
                else
                {
                    Response.Write("Something went wrong");
                }
            }
            catch (SqlException sqlex)
            {
                Response.Write(sqlex.Message);
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}