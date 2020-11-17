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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
          
        }
        class_for_id_user id = new class_for_id_user();
        info Iinfo = new info();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                

                dbmanager db = new dbmanager();
                

                MySqlCommand command = new MySqlCommand(" UPDATE `otdel_kadr`.`info` SET `user_name` = @user_name, `surname` =  @surname, `birthday` = @birthday, `phone` = @phone, `email` = @email  WHERE `users_id` = @id", db.getConnection());
                command.Parameters.Add("@user_name", MySqlDbType.VarChar).Value =  name_user.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname_user.Text;
                command.Parameters.Add("@birthday", MySqlDbType.Date).Value = dateTimePicker1.Value;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone.Text;;
                command.Parameters.Add("@email", MySqlDbType.VarChar).Value = email.Text;
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(id.get_idUser());
                db.openConnect();
              

                if (command.ExecuteNonQuery()==1)
                {

                    MessageBox.Show("Все данные успешно обновлены!!!");
                    this.Hide();
                    Iinfo.Show();
                    db.closeConnect();
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
  