using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConexionBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string constring = @"Data Source=* ;Initial Catalog=AdventureWorksLT2019 ;User id = sa ;password=* "; 
                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM SalesLT.Product", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                sda.Fill(ds);
                                dvgDisplay.DataSource = ds.Tables[0];
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("error, " + ex);
            }
        }
    }
}
