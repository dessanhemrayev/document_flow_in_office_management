using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                dbmanager db = new dbmanager();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM users where user_login = @login AND user_password=@password ", db.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login.Text;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                var myData = table.Select();

                if (table.Rows.Count == 1)
                {
                    class_for_id_user id = new class_for_id_user();
                    id.set_Id(myData[0].ItemArray[0].ToString());
                    datau DU = new datau();

                    this.Hide();

                    //Показываем форму. В данном конкретном случае все равно как показывать: с помощью метода Show() либо ShowDialog()
                    DU.Show();



                }
                else
                {
                    MessageBox.Show("Повторите заново!");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Повторите заново!");
            }
         
        }

        private void label4_Click(object sender, EventArgs e)
        {
            registration register = new registration();
             this.Hide();
            register.Show();
        }
    }
}
