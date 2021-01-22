using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBD
{
    public partial class auth : Form
    {
        public auth()
        {
            InitializeComponent();
        }
        private SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESSAN-LAPTOP\SQLEXPRESS; Database=otdel_kadr; Integrated Security=true");
        }

        [Obsolete]
        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = getConnection())
                {

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT * FROM users where user_login = @login AND user_password=@password ", cn);
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
                    command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password.Text;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    var myData = table.Select();

                    if (table.Rows.Count == 1)
                    {
                        class_for_id_user id = new class_for_id_user();
                        id.set_Id(myData[0].ItemArray[0].ToString());
                        id.set_AR((myData[0].ItemArray[3]).ToString());
                        if (Convert.ToInt32(myData[0].ItemArray[3]) == 2 || Convert.ToInt32(myData[0].ItemArray[3]) == 3)
                        {
                            data DU1 = new data();
                            DU1.Show();
                        }
                        else
                        {
                            datau DU = new datau();
                            DU.Show();
                        }


                        this.Hide();

                        //Показываем форму. В данном конкретном случае все равно как показывать: с помощью метода Show() либо ShowDialog()




                    }
                    else
                    {
                        MessageBox.Show("Повторите заново!");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                //MessageBox.Show("Повторите заново!");
            }
         
        }

        private void label4_Click(object sender, EventArgs e)
        {
            registration register = new registration();
             this.Hide();
            register.Show();
        }
    
       

        private void auth_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
