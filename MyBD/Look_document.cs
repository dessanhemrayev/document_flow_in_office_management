using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MyBD
{
    public partial class Look_document : Form
    {
        string document;
        string result = "";

        int counter = 0; // сквозной номер строки в массиве строк, которые выводятся
        int curPage; // текущая страница

        public Look_document(string doc)
        {
            InitializeComponent();
            document = doc;
        }

        private void Look_document_Load(object sender, EventArgs e)
        {
            try
            {
                Document_look.LoadFile(document);
                class_for_id_user buffer_doc = new class_for_id_user();
                buffer_doc.set_doc(Document_look.Text);

                result = Document_look.Text;
            }
            catch (Exception err)
            {

                MessageBox.Show(err.ToString());
            }

        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            printDialog1.ShowDialog();
            PrintDocument def = new PrintDocument();
            def.PrintPage += new PrintPageEventHandler(PRD);
            def.DocumentName = "Document1";
            def.PrinterSettings = printDialog1.PrinterSettings;
            def.Print();
        }


        // Начало печати
        

        void PRD(object sender, PrintPageEventArgs e)
        {
            Font myFont = new Font("Times New Roman", 14, FontStyle.Regular, GraphicsUnit.Pixel);
            string curLine="";
            // Отступы внутри страницы
            float leftMargin = e.MarginBounds.Left; // отступы слева в документе
            float topMargin = e.MarginBounds.Top; // отступы сверху в документе
           
            float yPos = 0; // текущая позиция Y для вывода строки

            int nPages; // количество страниц
            int nLines; // максимально-возможное количество строк на странице
            int i; // номер текущей строки для вывода на странице

            // Вычислить максимально возможное количество строк на странице
            nLines = (int)(e.MarginBounds.Height / myFont.GetHeight(e.Graphics));

            // Вычислить количество страниц для печати
            nPages = (Document_look.Lines.Length - 1) / nLines + 1;

            // Цикл печати/вывода одной страницы
            i = 0;
            while ((i < nLines) && (counter < Document_look.Lines.Length))
            {
                // Взять строку для вывода из richTextBox1
                curLine = Document_look.Lines[counter];

                // Вычислить текущую позицию по оси Y
                yPos =  i * myFont.GetHeight(e.Graphics);

                // Вывести строку в документ
                e.Graphics.DrawString(curLine, myFont, Brushes.Black,
                  leftMargin/2, yPos, new StringFormat());

                counter++;
                i++;
            }

            // Если весь текст не помещается на 1 страницу, то
            // нужно добавить дополнительную страницу для печати
            e.HasMorePages = false;

            if (curPage < nPages)
            {
                curPage++;
                e.HasMorePages = true;
            }
            //Graphics g = e.Graphics;

           // e.Graphics.DrawString(curLine, myFont, Brushes.Blue, leftMargin, yPos, new StringFormat());
            // g.DrawString(Document_look.Text, Font, new SolidBrush(Color.Black), 20, 10);


        }

            
     
    

}
}
