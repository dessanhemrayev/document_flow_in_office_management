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
    public partial class registration : Form
    {
        public registration()
        {
            InitializeComponent();
        }
        private int auth_user(string login, string password)
       {
            int get_id = 0;
            try
            {
                dbmanager db = new dbmanager();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM users where user_login = @login AND user_password=@password ", db.getConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                var myData = table.Select();

                if (table.Rows.Count == 1)
                {

                  get_id=Convert.ToInt32(myData[0].ItemArray[0].ToString());
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           
                return get_id;
        }
        private bool addUser(string usn,string lstn, int id)
        {
            try
            {
                String insertQuery = " INSERT INTO `otdel_kadr`.`info` (`user_name`,`surname`,`users_id`) VALUES(@user_name, @surname,@users_id)";

                dbmanager db = new dbmanager();
                db.openConnect();
                MySqlCommand command = new MySqlCommand(insertQuery, db.getConnection());
                command.Parameters.Add("@user_name", MySqlDbType.VarChar);
                command.Parameters.Add("@surname", MySqlDbType.VarChar);
                command.Parameters.Add("@users_id", MySqlDbType.Int32);

                command.Parameters["@user_name"].Value = usn;
                command.Parameters["@surname"].Value = lstn;
                command.Parameters["@users_id"].Value = id;

                if (command.ExecuteNonQuery() == 1)
                {

                    return true;
                }
               
            }
            catch(Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }
            return false;
        }
        private void regbutton_Click(object sender, EventArgs e)
        {
            string user_name = name.Text;
            string user_last_name = sname.Text;
            string user_login = login.Text;
            string user_password = password.Text;
            try
            {
                String insertQuery = " INSERT INTO `otdel_kadr`.`users` (`user_login`,`user_password`) VALUES(@user_login, @user_password)";
                
                dbmanager db = new dbmanager();
                db.openConnect();
                MySqlCommand command = new MySqlCommand(insertQuery, db.getConnection());
               
                command.Parameters.Add("@user_login", MySqlDbType.VarChar);
                command.Parameters.Add("@user_password", MySqlDbType.VarChar);

                
                command.Parameters["@user_login"].Value = user_login;
                command.Parameters["@user_password"].Value = user_password;
                if (command.ExecuteNonQuery() == 1)
                {
                    if (addUser(user_name, user_last_name,auth_user(user_login,user_password)))
                    {
                        MessageBox.Show("Регистрация прошла успешно!!!");
                        auth DU = new auth();
                        DU.Show();

                        db.closeConnect();
                        this.Hide();
                    }
                }
            }
            catch (Exception )
            {//"Заполните все поля!"
                MessageBox.Show("Заполните все поля!");
            }

        }

        private void registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            auth DU = new auth();
            DU.Show();
            this.Hide();
        }
    }
}
