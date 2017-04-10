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
        int[] nums;
        private void btOpenFile_Click(object sender, EventArgs e)
        {
            var file = new OpenFileDialog();
            var sb = new StringBuilder();

            if (file.ShowDialog() == DialogResult.OK && file.FileName != null)
            {
                using (var Reader = new StreamReader(file.FileName))      //создает поток для записи данных
                                                                    // using (var Reader = new StreamReader("C:\\task.txt"))
                {
                    richTextBox1.Text = Reader.ReadToEnd();     //запись в поток

                    sb.Append(richTextBox1.Text).ToString();
                }

            }
            string newSb = sb.ToString().Trim();
            string[] str = newSb.ToString().Split(' ');
            nums = str
                    .Select(n => int.Parse(n.Trim()))
                    .ToArray();
        }

        private void btChangeFile_Click(object sender, EventArgs e)
        {
            string aaa = "";
            int[] nums1 = new int[nums.Length];
            for (int i = 0; i < nums.Length - 1; i++)
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
            nums1[10] = nums[10];
           for(int i = 0; i < nums1.Length; i++)
            {
                aaa += nums1[i];
                aaa += ' ';
            }
            richTextBox2.Text = aaa;
        }
    }
}
