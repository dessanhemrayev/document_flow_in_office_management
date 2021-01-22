using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESSAN-LAPTOP\SQLEXPRESS; Database=otdel_kadr; Integrated Security=true");
        }
        [Obsolete]
        private int auth_user(string login, string password)
       {
            int get_id = 0;
            try
            {
                using (SqlConnection cn = getConnection())
                {

                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT * FROM users where user_login = @login AND user_password=@password ",cn);
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
                    cn.Open();
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    var myData = table.Select();

                    if (table.Rows.Count == 1)
                    {

                        get_id = Convert.ToInt32(myData[0].ItemArray[0].ToString());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           
                return get_id;
        }

        [Obsolete]
        private bool Add_user_state(int Id_user)
        {
            try
            {
                String insertQuery = " INSERT INTO state_user(users_id) VALUES(@users_id)";

                using (SqlConnection cn = getConnection())
                {

                   
                    SqlCommand command = new SqlCommand(insertQuery,cn);

                    command.Parameters.Add("@users_id", SqlDbType.Int);

                    command.Parameters["@users_id"].Value = Id_user;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }
            return false;
        }

        [Obsolete]
        private bool addUser(string usn,string lstn, int id)
        {
            try
            {
                String insertQuery = " INSERT INTO info (user_name,surname,users_id) VALUES(@user_name, @surname,@users_id)";

                using (SqlConnection cn = getConnection())
                {

                    SqlCommand command = new SqlCommand(insertQuery, cn);
                    command.Parameters.Add("@user_name", SqlDbType.VarChar);
                    command.Parameters.Add("@surname", SqlDbType.VarChar);
                    command.Parameters.Add("@users_id", SqlDbType.Int);

                    command.Parameters["@user_name"].Value = usn;
                    command.Parameters["@surname"].Value = lstn;
                    command.Parameters["@users_id"].Value = id;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }
            return false;
        }

        [Obsolete]
        private void regbutton_Click(object sender, EventArgs e)
        {
            string user_name = name.Text;
            string user_last_name = sname.Text;
            string user_login = login.Text;
            string user_password = password.Text;
            if (user_login.Length > 0 && user_last_name.Length > 0 && user_password.Length > 0 && user_name.Length > 0)
            {
                try
                {
                    String insertQuery = " INSERT INTO users (user_login,user_password) VALUES(@user_login, @user_password)";

                    using (SqlConnection cn = getConnection())
                    {

                        SqlCommand command = new SqlCommand(insertQuery, cn);

                        command.Parameters.Add("@user_login", SqlDbType.VarChar);
                        command.Parameters.Add("@user_password", SqlDbType.VarChar);


                        command.Parameters["@user_login"].Value = user_login;
                        command.Parameters["@user_password"].Value = user_password;
                        cn.Open();
                        if (command.ExecuteNonQuery() == 1)
                        {
                            int tmp = auth_user(user_login, user_password);
                            if (addUser(user_name, user_last_name, tmp) && Add_user_state(tmp))
                            {
                                MessageBox.Show("Регистрация прошла успешно!!!");
                                auth DU = new auth();
                                DU.Show();


                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception err)
                {//"Заполните все поля!"
                    MessageBox.Show(err.ToString());
                    MessageBox.Show("Проверьте данные!");
                }
            }
            else
            {
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
