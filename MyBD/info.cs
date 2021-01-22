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
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
            update_d();
        }
        class_for_id_user id = new class_for_id_user();
        private void info_Load(object sender, EventArgs e)
        {
            update_d();
        }
        private SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESSAN-LAPTOP\SQLEXPRESS; Database=otdel_kadr; Integrated Security=true");
        }
        [Obsolete]
        private void update_d()
        {
            try
            {
                using (SqlConnection cn = getConnection())
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT [user_name],  [info].[surname],   [info].[birthday],   [info].[phone],   [info].[email] FROM info where [info].[users_id]=@id", cn);

                    command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(id.get_idUser());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    var myData = table.Select();

                    label10.Text = myData[0].ItemArray[0].ToString().Trim();
                    label9.Text = myData[0].ItemArray[1].ToString().Trim();
                    label8.Text = myData[0].ItemArray[2].ToString().Trim();
                    label7.Text = myData[0].ItemArray[3].ToString().Trim();
                    label6.Text = myData[0].ItemArray[4].ToString().Trim();




                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при загрузке данных!");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            datau DU = new datau();
            DU.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit ED = new Edit();
            ED.Show();
            this.Hide();
        }
    }
}
