using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace spz_lb1_v6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] nums;//инициализируем массив в который будем потом записывать наши данные
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog(); //создаем обьект для открытия файла.
            var sb = new StringBuilder();

            if (file.ShowDialog() == DialogResult.OK && file.FileName != null)//если файл открылся и имя файла указано
            {
                using (var Reader = new StreamReader(file.FileName))      //создает поток для записи данных
               // using (var Reader = new StreamReader("C:\\task.txt"))
                {
                    richTextBox1.Text = Reader.ReadToEnd();     //запись в поток

                    sb.Append(richTextBox1.Text).ToString();//записываем данные в строку для последующего его разбеения
                }

            }
            string newSb = sb.ToString().Trim();//обрезаем пробелы по бокам строки
            string[] str = newSb.ToString().Split(' ');//нарезаем строку в массив строк
            nums = str
                    .Select(n => int.Parse(n.Trim()))
                    .ToArray();//получаем значения каждого отдельного элемента
        }

        private void btChangeFile_Click(object sender, EventArgs e)
        {
            string aaa = "";
            int[] nums1 = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || i == nums.Length - 1)
                {
                    nums1[i] = nums[i];
                }
                else
                {
                    nums1[i] = (nums[i - 1] + nums[i] + nums[i + 1]) / 3;
                }
            }
           for(int i = 0; i < nums1.Length; i++)
            {
                richTextBox2.Text += nums1[i];//выводим данные на экран
                richTextBox2.Text += ' ';
            }
        }
    }
}
