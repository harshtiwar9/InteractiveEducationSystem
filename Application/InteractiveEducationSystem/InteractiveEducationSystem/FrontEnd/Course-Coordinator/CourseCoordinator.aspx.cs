﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InteractiveEducationSystem.FrontEnd.Course_Coordinator
{
    public partial class CourseCoordinator : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["IES"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("SELECT Quiz_id_FK FROM Student_quiz", con);

            try
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                CourseList.DataSource = ds;
                CourseList.DataTextField = "Quiz_id_FK";
                CourseList.DataBind();


            }
            catch
            {
                con.Close();
            }


        }


        protected void Page_Load(object sender, EventArgs e)
        {




        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            int crs = Convert.ToInt32(CourseList.SelectedValue);
            String connectionString = WebConfigurationManager.ConnectionStrings["IES"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand("Select * from Student_quiz where Quiz_id_FK=" + crs, con);

            try
            {
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch
            {
                con.Close();
            }

        }
    }
}
