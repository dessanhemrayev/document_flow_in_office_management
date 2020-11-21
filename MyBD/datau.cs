using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace MyBD
{

    public partial class datau : Form
    {
        class_for_id_user idlik = new class_for_id_user();


        List<int> sends = new List<int>();
        List<int> improves = new List<int>();
        bool fl1=false;
        bool fl2 = false;
        public datau()
        {
            InitializeComponent();
            get_send_docs();
            get_improve_docs();
            panel3.Visible = true;
            panel4.Visible = false;
        }
       

        private void get_send_docs()
        {
            dataGridView1.Rows.Clear();
            try
            {
                sends.Clear();
                dbmanager db = new dbmanager();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT `document`.`type_doc`, (select concat(`info`.`user_name`,' ',`info`.`surname`)  from `otdel_kadr`.`info` where `info`.`users_id`=`document`.`id_to_whom`), `document`.`date`,`document`.`id`,`document`.`id_to_whom`, `document`.`users_id` FROM `otdel_kadr`.`document` where `document`.`users_id`= @id", db.getConnection());

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(idlik.get_idUser());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView1.RowTemplate.Height = 25;
                //dataGridView1.AllowUserToAddRows = false;
                //dataGridView1.DataSource = table;
                var myData = table.Select();

                for (int i = 0; i < myData.Length; i++)
                {
                    dataGridView1.Rows.Add(i + 1, myData[i].ItemArray[0].ToString().Trim(), myData[i].ItemArray[1].ToString().Trim(), myData[i].ItemArray[2].ToString().Trim());
                    sends.Add(Convert.ToInt32(myData[i].ItemArray[3].ToString()));

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при загрузке данных!");
            }

        }

        private void get_improve_docs()
        {
            dataGridView2.Rows.Clear();
            improves.Clear();
            try
            {
                dbmanager db = new dbmanager();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT  `document`.`type_doc`, (select concat(`info`.`user_name`, ' ',`info`.`surname`)  from `otdel_kadr`.`info` where `info`.`users_id`=`document`.`id_to_whom`), `document`.`date`, `document`.`id`  FROM `otdel_kadr`.`document` where `document`.`id_to_whom`= @id", db.getConnection());

                command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(idlik.get_idUser());
                adapter.SelectCommand = command;
                adapter.Fill(table);
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView2.RowTemplate.Height = 25;
                //dataGridView2.AllowUserToAddRows = false;
                //dataGridView2.DataSource = table;
                var myData = table.Select();

                for (int i = 0; i < myData.Length; i++)
                {
                    dataGridView2.Rows.Add(i + 1, myData[i].ItemArray[0].ToString().Trim(), myData[i].ItemArray[1].ToString().Trim(), myData[i].ItemArray[2].ToString().Trim());
                    improves.Add(Convert.ToInt32(myData[i].ItemArray[3].ToString()));

                }

            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при загрузке данных!");
            }
           
        }
        private void выходВОкноРегистрацииToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
          
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void datau_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            panel4.Visible = true;
           
        }

        private void look_doc_Click(object sender, EventArgs e)
        {
            Look_document LD = new Look_document("");
            LD.Show();


        }

        private void send_doc_Click(object sender, EventArgs e)
        {
            send_doc SD = new send_doc();
            SD.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_send_docs();
            get_improve_docs();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_send_docs();
            get_improve_docs();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            info Iinfo = new info();
            Iinfo.Show();
            this.Hide();
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                fl1 = false;
                fl2 = true;
                int k = dataGridView2.CurrentRow.Index;
                show_doc(k);
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего нету");

            }
           
            //
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
          

            try
            {
                fl1 = true;
                fl2 = false;
                int k = dataGridView1.CurrentRow.Index;
                show_doc(k);
            }
            catch (Exception)
            {
                MessageBox.Show("Ничего нету");

            }

        }
        private void preparing_the_script( int id_user)
        {
           try
            {
                File.Copy(@"D://document_flow_in_office_management//MyBD//scripts//write.py", @"D://document_flow_in_office_management//MyBD//scripts//write2.py");
                string writePath = @"D://document_flow_in_office_management//MyBD//scripts//write2.py";

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
                {

                  
                    sw.Write("        readBLOB({0})", id_user);

                  
                }
                //MessageBox.Show("Запись выполнена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private string getOutput(string pathScript, string command)
        {
            ProcessStartInfo info = new ProcessStartInfo(pathScript, command);
            info.UseShellExecute = false;
            info.ErrorDialog = false;
            info.RedirectStandardError = true;
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.CreateNoWindow = true;


            Process p = new Process();
            p.StartInfo = info;

            bool pStarted = p.Start();

            StreamWriter input = p.StandardInput;
            StreamReader output = p.StandardOutput;
            StreamReader error = p.StandardError;


            return output.ReadToEnd();

        }
        private async void show_doc(int pos)
        {
            int id = 0;
            if (fl1)
            {
                id = sends[pos];
            }else
            if(fl2)
            {
                id = improves[pos];
            }
           

            try
            {
              

                preparing_the_script(id);

                string str1 = await Task.Run(() => { return 
                    this.getOutput("C://Users//dessa//AppData//Local//Programs//Python//Python38-32//python.exe", 
                    "D://document_flow_in_office_management/MyBD/scripts/write2.py"); });
               

                File.Delete(@"D://document_flow_in_office_management//MyBD//scripts//write2.py");

                MessageBox.Show(str1);






              
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите имя файла");
            }
          

        }


    }
}
