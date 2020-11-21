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
    public partial class send_doc : Form
    {
        class_for_id_user id = new class_for_id_user();
        

        List<int> to_whom_ids = new List<int>();

        public send_doc()
        {
            InitializeComponent();

            get_users();


        }

        private void get_users()
        {

            dbmanager db = new dbmanager();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `info`.`users_id`,   concat( `info`.`user_name` ,' ',  `info`.`surname`)FROM `otdel_kadr`.`info`,`otdel_kadr`.`users` where `info`.`users_id` =`users`.`id` and `users`.`access right`=2   ", db.getConnection());
           // command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(id.get_idUser());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            var myData = table.Select();

            for (int i = 0; i < myData.Length; i++)
            {

                comboBox2.Items.Add(myData[i].ItemArray[1]);
                to_whom_ids.Add(Convert.ToInt32(myData[i].ItemArray[0]));

            }

       }


      

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MS Word documents (*.docx)|*.docx|Rich text format (*.rtf)|*.rtf|Все файлы (*.)|*";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                id.set_doc(openFileDialog.FileName);
          
            }



        }

        private void preparing_the_script(string type_doc, string doc_file, string date, int id_whom, int id_user)
        {
            int pos_val = Convert.ToInt32(doc_file.LastIndexOf('.'))+1;
            int length = Convert.ToInt32(doc_file.Length) - pos_val;
            string format_doc = doc_file.Substring(pos_val,length);
            string file = "";
            for (int i = 0; i < doc_file.Length; i++)
            {
                if (doc_file[i].ToString()=="\\") 
                    {
                    file += "\\\\";
                    }
                else
                {
                    file += doc_file[i];
                }

            }
            File.Copy(@"D://document_flow_in_office_management//MyBD//scripts//read_doc.py", @"D://document_flow_in_office_management//MyBD//scripts//read_doc2.py");

            string writePath = @"D://document_flow_in_office_management//MyBD//scripts//read_doc2.py";
          
           
            try
            {
              
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
                {
                  
                    sw.Write("    insertBLOB(\"{0}\",\"{1}\",f\"{2}\",\"{3}\",{4},{5})", type_doc, format_doc, file, date,id_whom, id_user);

                    //sw.Write;
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
        private async void send_button_Click_1(object sender, EventArgs e)
        {


            string type_doc = comboBox1.SelectedItem.ToString();
            int to_whom_id = to_whom_ids[Convert.ToInt32(comboBox2.SelectedIndex.ToString())];
            int id_get =Convert.ToInt32(id.get_idUser());
          
            preparing_the_script(type_doc, id.get_buffer(), dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), to_whom_id,id_get);

           string str1 = await Task.Run(() => {return this.getOutput("C://Users//dessa//AppData//Local//Programs//Python//Python38-32//python.exe", "D://document_flow_in_office_management/MyBD/scripts/read_doc2.py");          });
           MessageBox.Show(str1);



            File.Delete(@"D://document_flow_in_office_management//MyBD//scripts//read_doc2.py");





        }


    }
}
