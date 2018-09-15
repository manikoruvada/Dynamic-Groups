using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace qunatumkey
{
    
    public class Database
    {
        string constr = "server=.;uid=sa;pwd=;database=quantumkey;";
                
        //Insert into database
        public void insert(string qry)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry,con);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            string ss=ex.Message;            
        }
        con.Close();
        }

        //view 
        public string[] view(string qry)
        {
            string[] a = new string[100];
            int i = 1;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    a[i] = dr[0].ToString();
                    i++;
                }
                a[0] = i.ToString();
            }
            catch (Exception ex)
            {
                string ss=ex.Message;

            }
            return a;
        }


    }
     
}
