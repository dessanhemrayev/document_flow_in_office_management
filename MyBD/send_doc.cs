using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            MySqlCommand command = new MySqlCommand("SELECT `info`.`users_id`,   concat( `info`.`user_name` ,' ',  `info`.`surname`)FROM `otdel_kadr`.`info` where `info`.`users_id` <> @id", db.getConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = Convert.ToInt32(id.get_idUser());

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
            openFileDialog.Filter = "MS Word documents (*.docx)|*.docx|Rich text format (*.rtf)|*.rtf";
            
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FilterIndex == 1)//если формат документа Word 2007
                {
                    Word.Application app = new Microsoft.Office.Interop.Word.Application();//процесс ворда
                    Object docxFileName = openFileDialog.FileName;//имя файла
                    Object missing = Type.Missing;
                    //открыли дркумент
                    app.Documents.Open(ref docxFileName, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing, ref missing, ref missing,
                        ref missing, ref missing);
                    //путь к папке с временными файлами
                    string temp = System.IO.Path.GetTempPath();
                    //для передачи параметров при пересохранении
                    Object lookComments = false;
                    Object password = String.Empty;
                    Object AddToRecentFiles = true;
                    Object WritePassword = String.Empty;
                    Object ReadOnlyRecommended = false;
                    Object EmbedTrueTypeFonts = false;
                    Object SaveFormsData = false;
                    Object SaveAsAOCELetter = false;
                    //имя файла без расширения
                    Object rtfFileName = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - ".docx".Length);
                    //создали рандом
                    Random random = new Random();
                    //проверяем есть ли файл с таким именем
                    while (System.IO.File.Exists(rtfFileName + ".rtf"))
                        //генерируем случайное имя файла
                        rtfFileName += random.Next(0, 9).ToString();
                    //формат RTF
                    Object wdFormatRTF = Word.WdSaveFormat.wdFormatRTF;
                    //приписали расширение
                    rtfFileName += ".rtf";
                    //приписали путь к временным файлам
                    rtfFileName = temp + rtfFileName;
                    //пересохранили
                    app.ActiveDocument.SaveAs(ref rtfFileName,
                        ref wdFormatRTF, ref lookComments, ref password, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended,
                        ref EmbedTrueTypeFonts, ref missing, ref SaveFormsData, ref SaveAsAOCELetter, ref missing,
                        ref missing, ref missing, ref missing, ref missing);
                    //переменная
                    Object @false = false;
                    //закрыли текущий документ
                    app.ActiveDocument.Close(ref @false, ref missing, ref missing);
                    //вышли из ворда
                    app.Quit(ref @false, ref missing, ref missing);
                    //прочли файл
                    Look_document LK = new Look_document((String)rtfFileName);
                    LK.Show();
                }
                if (openFileDialog.FilterIndex == 2)
                {
                    Look_document LK = new Look_document(openFileDialog.FileName);
                    LK.Show();
                }
               
            }



        }

        private void send_button_Click_1(object sender, EventArgs e)
        {


            string type_doc = comboBox1.SelectedItem.ToString();
            int to_whom_id = to_whom_ids[Convert.ToInt32(comboBox2.SelectedIndex.ToString())];



            
           
            try
            {
                String insertQuery = "INSERT INTO `otdel_kadr`.`document` (`type_doc`,`document`,`date`,`id_to_whom`,`users_id`)VALUES(@type_doc, @document, @date, @id_to_whom, @users_id)";


                dbmanager db = new dbmanager();
                db.openConnect();
                MySqlCommand command = new MySqlCommand(insertQuery, db.getConnection());
                command.Parameters.Add("@type_doc", MySqlDbType.VarChar);
                command.Parameters.Add("@document", MySqlDbType.LongText);
        
                command.Parameters.Add("@date", MySqlDbType.Date);
                command.Parameters.Add("@id_to_whom", MySqlDbType.Int32);
                command.Parameters.Add("@users_id", MySqlDbType.Int32);
               

                command.Parameters["@type_doc"].Value = type_doc;
                command.Parameters["@document"].Value =id.get_buffer();
               

                string formatForMySql = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");

                command.Parameters["@date"].Value = formatForMySql;
                //ToShortDateString();
                command.Parameters["@id_to_whom"].Value = to_whom_id;
                command.Parameters["@users_id"].Value =Convert.ToInt32(id.get_idUser());
               
                if (command.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Документ успешно отправлен!!!");
                   db.closeConnect();
                   
                }
            }
            catch (Exception err)
            {//"Заполните все поля!"
                MessageBox.Show(err.ToString());
            }

        }

       
    }
}
