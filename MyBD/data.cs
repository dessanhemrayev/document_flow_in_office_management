
using Aspose.Words;
using Aspose.Words.Replacing;
using Word = Microsoft.Office.Interop.Word;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;

namespace MyBD
{
    public partial class data : Form
    {
        class_for_id_user idlik = new class_for_id_user();
    
        List<int> improves = new List<int>();
        List<int> for_users_id = new List<int>();
        List<int> delete_users_id = new List<int>();
        int delete_user;
        List<int> prikazy_id = new List<int>();
        List<int> access_right_users = new List<int>();
        List<int> dep_id= new List<int>();
        List<int> pos_id = new List<int>();
        bool dg2 = false;
        bool dg3 = false;


        public data()
        {
            InitializeComponent();
            
            if (!tabControl1.TabPages.Contains(tabPage6)) return;
            tabControl1.TabPages.Remove(tabPage6);

            if (idlik.get_AR()=="3")
            {
                if (tabControl1.TabPages.Contains(tabPage6)) return;
                tabControl1.TabPages.Add(tabPage6);
            }

            get_info_users();
            get_docs();
            get_free_users();
            get_deparments();
            get_prikazs();
            get_users_for_access_right();
            
        }
        private SqlConnection getConnection()
        {
            return new SqlConnection(@"Data Source=DESSAN-LAPTOP\SQLEXPRESS; Database=otdel_kadr; Integrated Security=true");
        }

        private void get_info_users()
        {
            dataGridView1.Rows.Clear();
            try
            {
                delete_users_id.Clear();
                using (SqlConnection cn = getConnection())
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT DISTINCT [info].[users_id],user_name, surname, birthday, phone, email,dep_name, pos_name, state_user FROM info,positions,departments, state_user WHERE [info].[positions_id]=[positions].[id] AND [positions].[departments_id]=[departments].[id] AND [info].[users_id]=[state_user].[users_id]", cn);

                    //command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(idlik.get_idUser());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    var myData = table.Select();

                    for (int i = 0; i < myData.Length; i++)
                    {

                        string[] birthday = myData[i].ItemArray[3].ToString().Trim().Split(' ');
                        dataGridView1.Rows.Add(i + 1, myData[i].ItemArray[1].ToString().Trim(),
                                                      myData[i].ItemArray[2].ToString().Trim(),
                                                      birthday[0],
                                                      myData[i].ItemArray[4].ToString().Trim(),
                                                      myData[i].ItemArray[5].ToString().Trim(),
                                                      myData[i].ItemArray[6].ToString().Trim(),
                                                      myData[i].ItemArray[7].ToString().Trim(),
                                                      myData[i].ItemArray[8].ToString().Trim());
                        delete_users_id.Add(Convert.ToInt32(myData[i].ItemArray[0].ToString()));

                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                //           MessageBox.Show("Ошибка при загрузке данных!");
            }


        }
    
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
           
              
            
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            delete_user = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
           // textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void get_docs()
        {
            
            dataGridView2.Rows.Clear();
            improves.Clear();
            try
            {
                using (SqlConnection cn = getConnection())
                {
                    System.Data.DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT DISTINCT [document].[type_doc], (select concat([info].[user_name], ' ',[info].[surname])  from [info] where [info].[users_id]=[document].[id_to_whom]), [document].[date], [document].[id]  FROM document where [document].[id_to_whom]=@id", cn);

                    command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(idlik.get_idUser());
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    var myData = table.Select();

                    for (int i = 0; i < myData.Length; i++)
                    {
                        dataGridView2.Rows.Add(i + 1, myData[i].ItemArray[0].ToString().Trim(), myData[i].ItemArray[1].ToString().Trim(), myData[i].ItemArray[2].ToString().Trim());
                        improves.Add(Convert.ToInt32(myData[i].ItemArray[3].ToString()));

                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка при загрузке данных!");
            }

        }


        private void get_prikazs()
        {

            dataGridView3.Rows.Clear();
            prikazy_id.Clear();

            try
            {
                using (SqlConnection cn = getConnection())
                {

                    System.Data.DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand command = new SqlCommand("SELECT DISTINCT id, name_doc, (select concat([info].[user_name], ' ',[info].[surname])  from info where [info].[users_id]=[prikazy].[users_id]), date FROM [prikazy] ", cn);


                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    var myData = table.Select();

                    for (int i = 0; i < myData.Length; i++)
                    {
                        dataGridView3.Rows.Add(i + 1, myData[i].ItemArray[1].ToString().Trim(), myData[i].ItemArray[2].ToString().Trim(), myData[i].ItemArray[3].ToString().Trim());
                        prikazy_id.Add(Convert.ToInt32(myData[i].ItemArray[0].ToString()));

                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show("Ошибка при загрузке данных!");
            }

        }

        private void preparing_the_script(int id_user)
        {
            try
            {
                File.Copy(@"D://document_flow_in_office_management//MyBD//scripts//write.py", @"D://document_flow_in_office_management//MyBD//scripts//write2.py");
                string writePath = @"D://document_flow_in_office_management//MyBD//scripts//write2.py";

                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.UTF8))
                {

                    if (dg2) { sw.Write("        readBLOB({0})", id_user); }
                    else if (dg3) { sw.Write("        readBLOB2({0})", id_user); }
                    


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
           
               
           if (dg2) { id = improves[pos]; }
            else if(dg3) { id = prikazy_id[pos]; }

            try
            {


                preparing_the_script(id);

                string str1 = await Task.Run(() => {
                    return
                            this.getOutput("C://Users//dessa//AppData//Local//Programs//Python//Python38-32//python.exe",
                            "D://document_flow_in_office_management/MyBD/scripts/write2.py");
                                            });


                File.Delete(@"D://document_flow_in_office_management//MyBD//scripts//write2.py");

                MessageBox.Show(str1);







            }
            catch (Exception)
            {
                MessageBox.Show("Выберите имя файла");
            }


        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int k = dataGridView2.CurrentRow.Index;
            dg2 = true;
            dg3 = false;

            string message = "Вы хотите скачать этот файл?";
            const string caption = "Скачать документ";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            // If the no button was pressed ...
            if (result == DialogResult.Yes)
            {
                show_doc(k);
            }
           
            
        }

        private void data_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        [Obsolete]
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            using (SqlConnection cn = getConnection())
            {

                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT DISTINCT id,pos_name FROM positions WHERE [positions].[departments_id]=@id_pos", cn);
                command.Parameters.Add("@id_pos", SqlDbType.Int).Value = comboBox3.SelectedIndex + 1;


                adapter.SelectCommand = command;
                adapter.Fill(table);
                var myData = table.Select();

                for (int i = 0; i < myData.Length; i++)
                {

                    comboBox4.Items.Add(myData[i].ItemArray[1]);
                    pos_id.Add(Convert.ToInt32(myData[i].ItemArray[0]));

                }
            }
        }
        public static Word.Application app = new Word.Application();
        string path_to_doc = "D:\\document_flow_in_office_management\\MyBD\\forma_prikaza\\";
        static string path_to_doc2 = "D:\\document_flow_in_office_management\\MyBD\\forma_prikaza\\12.rtf";
        public static Object fileName = path_to_doc2;
        public static Object missing = Type.Missing;

        static bool fl1 = false;
        // Открываем файл test.doc (шаблон)
        public void OpenFile()
        {
            app.Documents.Open(ref fileName);
        }

        // Закрытие general и сохранение файла нового файла
        public void SaveCloseFile()
        {
            app.ActiveDocument.SaveAs(path_to_doc2);
            app.ActiveDocument.Close();
            app.Quit();
        }
        public void replace_all(string str_old, string str_new)
        {
            Word.Find find = app.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены

            find.Execute(FindText: Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: Word.WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: missing, Replace: Word.WdReplace.wdReplaceAll);
        }

        private void viewer()
        {
            path_to_doc = path_to_doc + (comboBox1.SelectedIndex + 1).ToString() + ".rtf";

            File.Copy(path_to_doc, path_to_doc2);

            richTextBox1.Clear();
            OpenFile();
            replace_all("@@@@", dateTimePicker1.Value.ToString("dd.MM.yyyy"));

            replace_all("###", comboBox2.SelectedItem.ToString());
            replace_all("$$$", comboBox3.SelectedItem.ToString());
            replace_all("%%%", comboBox4.SelectedItem.ToString());
            replace_all("!@", dateTimePicker1.Value.ToString("dd"));
            replace_all("#@!", dateTimePicker1.Value.ToString("MMMM"));
            replace_all("!!!!", dateTimePicker1.Value.ToString("yy"));
            SaveCloseFile();

            richTextBox1.LoadFile(path_to_doc2);

        }

        private void button5_Click(object sender, EventArgs e)
        {
             viewer();
            fl1= true;
        }

        private void get_free_users()
        {
            for_users_id.Clear();
            comboBox2.Items.Clear();
            using (SqlConnection cn = getConnection())
            {


                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT DISTINCT [info].[users_id],concat( [info].[user_name] ,' ',[info].[surname])  FROM [info],[state_user] WHERE [state_user].[state_user]='Гость' and  [info].[users_id]=[state_user].[users_id]", cn);



                adapter.SelectCommand = command;
                adapter.Fill(table);
                var myData = table.Select();

                for (int i = 0; i < myData.Length; i++)
                {

                    comboBox2.Items.Add(myData[i].ItemArray[1]);
                    for_users_id.Add(Convert.ToInt32(myData[i].ItemArray[0]));

                }
            }
        }
       
        private void get_deparments()
        {
            comboBox3.Items.Clear();
            comboBox6.Items.Clear();
            using (SqlConnection cn = getConnection())

            {
                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT * FROM departments ", cn);



                adapter.SelectCommand = command;
                adapter.Fill(table);
                var myData = table.Select();

                for (int i = 0; i < myData.Length; i++)
                {

                    comboBox3.Items.Add(myData[i].ItemArray[1]);
                    comboBox6.Items.Add(myData[i].ItemArray[1]);
                    dep_id.Add(Convert.ToInt32(myData[i].ItemArray[0]));
                }
            }
        }

        private void preparing_the_script(string name_doc, string doc_file, string date, int id_user)
        {
            
            string file = "";
            for (int i = 0; i < doc_file.Length; i++)
            {
                if (doc_file[i].ToString() == "\\")
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

                    sw.Write("    insertBLOB2(\"{0}\",\"{1}\",f\"{2}\",\"{3}\")", name_doc, date, file, id_user);

                    //sw.Write;
                }
                //MessageBox.Show("Запись выполнена");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

               private async void button4_Click(object sender, EventArgs e)
            {
            try
                 {
                if (fl1 == false)
                {
                    viewer();
                }

                string name_doc = comboBox1.SelectedItem.ToString();
                int for_user_id = for_users_id[Convert.ToInt32(comboBox2.SelectedIndex.ToString())];


                preparing_the_script(name_doc, path_to_doc2, dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"), for_user_id);

                string str1 = await Task.Run(() => { return this.getOutput("C://Users//dessa//AppData//Local//Programs//Python//Python38-32//python.exe", "D://document_flow_in_office_management/MyBD/scripts/read_doc2.py"); });
                

                if(Update_user_state(for_user_id)&& Update_user_pos(for_user_id))
                {
                    MessageBox.Show(str1);
                }

                File.Delete(@"D://document_flow_in_office_management//MyBD//scripts//read_doc2.py");
                File.Delete(path_to_doc2);
            }
            catch (Exception)
            {

                MessageBox.Show("Проверьте пожалуйста введеные данные!!!");
             }
           

        }

        [Obsolete]
        private bool Update_user_state(int Id_user)
        {
            try
            {
                String insertQuery = " UPDATE state_user SET state_user='Сотрудник'  WHERE users_id=@id_user";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);

                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = Id_user;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show("Заполните все поля!");
            }
            return false;
        }

        private bool Update_user_pos(int Id_user)
        {
            try
            {
                String insertQuery = " UPDATE info SET positions_id=@pos_id WHERE  users_id=@id_user";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);
                    command.Parameters.Add("@pos_id", SqlDbType.Int);
                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@pos_id"].Value = pos_id[comboBox4.SelectedIndex];
                    command.Parameters["@id_user"].Value = Id_user;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show("Заполните все поля!");
            }
            return false;
        }



        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int k = dataGridView3.CurrentRow.Index;
            dg3 = true;
            dg2 = false;
            string message = "Вы хотите скачать этот файл?";
            const string caption = "Скачать документ";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                show_doc(k);
            }
        }

        private bool Update_user_access_right(int Id_user)
        {
            try
            {
                String insertQuery = " UPDATE users SET [access right]=2 WHERE id=@id_user";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);

                    command.Parameters.Add("@id_user", SqlDbType.Int);

                    command.Parameters["@id_user"].Value = Id_user;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show("Заполните все поля!");
            }
            return false;
        }
        private void get_users_for_access_right()
        {
            access_right_users.Clear();
            comboBox5.Items.Clear();
            using (SqlConnection cn = getConnection())
            {
                DataTable table = new DataTable();

                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT DISTINCT [users].[id], concat([info].[user_name],' ',[info].[surname]) FROM info, users WHERE [users].[id]=[info].[users_id] AND [users].[access right]=1", cn);

                adapter.SelectCommand = command;
                adapter.Fill(table);
                var myData = table.Select();

                for (int i = 0; i < myData.Length; i++)
                {

                    comboBox5.Items.Add(myData[i].ItemArray[1]);
                    access_right_users.Add(Convert.ToInt32(myData[i].ItemArray[0]));

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Id_AC = access_right_users[comboBox5.SelectedIndex];
            if (Update_user_access_right(Id_AC)) {
                MessageBox.Show("Пользоваелью даны права СОК-а");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                String insertQuery = " INSERT INTO departments(dep_name) VALUES(@dep_name)";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);

                    command.Parameters.Add("@dep_name", SqlDbType.VarChar);

                    command.Parameters["@dep_name"].Value = textBox9.Text;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("Отдел успешно добавлен!");
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Заполните все поля!");
            }
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            get_info_users();
            get_docs();
            get_free_users();
            get_deparments();
            get_prikazs();
            get_users_for_access_right();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                String insertQuery = " INSERT INTO positions( pos_name, departments_id) VALUES(@pos_name,@d_id)";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);

                    command.Parameters.Add("@pos_name", SqlDbType.VarChar);
                    command.Parameters.Add("@d_id", SqlDbType.Int);

                    command.Parameters["@pos_name"].Value = textBox10.Text;
                    command.Parameters["@d_id"].Value = dep_id[comboBox6.SelectedIndex];
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("Должность успешно добавлен!");
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                MessageBox.Show("Заполните все поля!");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
           



            _delete_user_document(delete_users_id[delete_user - 1]);
            _delete_user_prikazs(delete_users_id[delete_user - 1]);
            _delete_user_info(delete_users_id[delete_user - 1]);
            _delete_user_state(delete_users_id[delete_user - 1]);
            _delete_user(delete_users_id[delete_user - 1]);


            get_info_users();
            get_docs();
            get_free_users();
            get_deparments();
            get_prikazs();
            get_users_for_access_right();
        }

        private bool _delete_user(int id) {
            try
            {
                String insertQuery = " DELETE FROM users WHERE id=@d_id";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);


                    command.Parameters.Add("@d_id", SqlDbType.Int);


                    command.Parameters["@d_id"].Value = id;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }



            return false; 
        }
        private bool _delete_user_state(int id) {

            try
            {
                String insertQuery = " DELETE FROM state_user WHERE users_id=@d_id";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);


                    command.Parameters.Add("@d_id", SqlDbType.Int);


                    command.Parameters["@d_id"].Value = id;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }



            return false;


        }
        private bool _delete_user_prikazs(int id) {
            try
            {
                String insertQuery = " DELETE FROM prikazy WHERE users_id=@d_id";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);


                    command.Parameters.Add("@d_id", SqlDbType.Int);


                    command.Parameters["@d_id"].Value = id;

                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }



            return false;
        }
        private bool _delete_user_info(int id) {

            try
            {
                String insertQuery = "DELETE FROM info WHERE users_id=@d_id";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);


                    command.Parameters.Add("@d_id", SqlDbType.Int);


                    command.Parameters["@d_id"].Value = id;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }



            return false;



        }


        private bool _delete_user_document(int id)
        {

            try
            {
                String insertQuery = " DELETE FROM document WHERE users_id=@d_id";

                using (SqlConnection cn = getConnection())
                {
                    SqlCommand command = new SqlCommand(insertQuery, cn);


                    command.Parameters.Add("@d_id", SqlDbType.Int);
                    command.Parameters["@d_id"].Value = id;
                    cn.Open();
                    if (command.ExecuteNonQuery() == 1)
                    {

                        return true;
                    }

                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());

            }

            return false;



        }

        [Obsolete]
        private void find_users(string find_user, string find_sname,string state)
        {
            dataGridView4.Rows.Clear();
            using (SqlConnection cn = getConnection())
            {
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    string query = "";
                    if (find_user.Length > 0 && find_sname.Length > 0 && state.Length > 0)
                    {
                        query = "SELECT DISTINCT user_name, surname, birthday, phone, email, pos_name as positions, dep_name AS departments,state_user AS state_user FROM info LEFT JOIN positions ON positions.id = info.positions_id LEFT JOIN departments ON departments.id = positions.departments_id LEFT JOIN state_user ON state_user.users_id = info.users_id where state_user.state_user=@state and info.user_name=@uname and info.surname=@fsname";

                    }
                    else if (find_user.Length > 0 && find_sname.Length > 0 || state.Length > 0)
                    {
                        query = "SELECT DISTINCT user_name, surname, birthday, phone, email, pos_name as positions, dep_name AS departments,state_user AS state_user FROM info LEFT JOIN positions ON positions.id = info.positions_id LEFT JOIN departments ON departments.id = positions.departments_id LEFT JOIN state_user ON state_user.users_id = info.users_id where state_user.state_user=@state and info.user_name=@uname or info.surname=@fsname";

                    }
                    else
                    if (find_user.Length > 0 || find_sname.Length > 0 && state.Length > 0)
                    {
                        query = "SELECT  DISTINCT user_name, surname, birthday, phone, email, pos_name as positions, dep_name AS departments,state_user AS state_user FROM info LEFT JOIN positions ON positions.id = info.positions_id LEFT JOIN departments ON departments.id = positions.departments_id LEFT JOIN state_user ON state_user.users_id = info.users_id where state_user.state_user=@state or info.user_name=@uname and info.surname=@fsname";

                    }
                    else
                    {
                        query = "SELECT DISTINCT user_name, surname, birthday, phone, email, pos_name as positions, dep_name AS departments,state_user AS state_user FROM info LEFT JOIN positions ON positions.id = info.positions_id LEFT JOIN departments ON departments.id = positions.departments_id LEFT JOIN state_user ON state_user.users_id = info.users_id where state_user.state_user=@state or info.user_name=@uname or info.surname=@fsname";

                    }


                    SqlCommand command = new SqlCommand(query, cn);
                    command.Parameters.Add("@state", SqlDbType.VarChar).Value = state;
                    command.Parameters.Add("@uname", SqlDbType.VarChar).Value = find_user;
                    command.Parameters.Add("@fsname", SqlDbType.VarChar).Value = find_sname;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);

                    var myData = table.Select();
                    if (myData.Length == 0)
                    {
                        MessageBox.Show("По вашему запросу ничего не найдено!!!");
                    }



                    for (int i = 0; i < myData.Length; i++)
                    {
                        string[] birthday = myData[i].ItemArray[3].ToString().Trim().Split(' ');
                        dataGridView4.Rows.Add(i + 1, myData[i].ItemArray[0].ToString().Trim(),
                                                      myData[i].ItemArray[1].ToString().Trim(),
                                                      birthday[0],
                                                      myData[i].ItemArray[3].ToString().Trim(),
                                                      myData[i].ItemArray[4].ToString().Trim(),
                                                      myData[i].ItemArray[5].ToString().Trim(),
                                                      myData[i].ItemArray[6].ToString().Trim(),
                                                      myData[i].ItemArray[7].ToString().Trim());


                    }
                }


                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                    //           MessageBox.Show("Ошибка при загрузке данных!");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            string fname = find_user_name.Text;
            string fsname = find_user_sname.Text;
            string u_state = states_box.SelectedItem.ToString();

            find_users(fname, fsname, u_state);


           

        }

        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {



                using (SqlConnection cn = getConnection())
                {

                    SqlCommand command = new SqlCommand(" UPDATE info SET user_name = @user_name, surname =@surname, birthday = @birthday, phone = @phone, email = @email  WHERE users_id = @id", cn);
                    command.Parameters.Add("@user_name", SqlDbType.VarChar).Value = textBox1.Text;
                    command.Parameters.Add("@surname", SqlDbType.VarChar).Value = textBox2.Text;

                    string date = textBox3.Text;
                    DateTime time = DateTime.Parse(date);
                    command.Parameters.Add("@birthday", SqlDbType.Date).Value = time;
                    command.Parameters.Add("@phone", SqlDbType.VarChar).Value = textBox4.Text; ;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = textBox5.Text;
                    command.Parameters.Add("@id", SqlDbType.Int).Value = Convert.ToInt32(delete_users_id[delete_user - 1]);

                    cn.Open();

                    if (command.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("Все данные успешно обновлены!!!");


                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }

            get_info_users();
            get_docs();
            get_free_users();
            get_deparments();
            get_prikazs();
            get_users_for_access_right();
        }
    }
}
