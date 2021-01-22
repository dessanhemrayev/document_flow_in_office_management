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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
          
        }
        class_for_id_user id = new class_for_id_user();
        info Iinfo = new info();

        private SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESSAN-LAPTOP\SQLEXPRESS; Database=otdel_kadr; Integrated Security=true");
        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                using (SqlConnection cn = getConnection())
                {


                    SqlCommand command = new SqlCommand(" UPDATE info SET [user_name] = @user_name, [surname] =  @surname, [birthday] = @birthday, [phone] = @phone, [email] = @email  WHERE [users_id]= @id", cn);
                    command.Parameters.Add("@user_name", SqlDbType.VarChar).Value = name_user.Text;
                    command.Parameters.Add("@surname", SqlDbType.VarChar).Value = surname_user.Text;
                    command.Parameters.Add("@birthday", SqlDbType.Date).Value = dateTimePicker1.Value;
                    command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone.Text; ;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = email.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(id.get_idUser());

                    cn.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("Все данные успешно обновлены!!!");
                        this.Hide();
                        Iinfo.Show();

                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            this.Hide();
        }
    }

    }
  