using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FormCallJava
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startsInfo  = new ProcessStartInfo();
            startsInfo.CreateNoWindow = true;
            startsInfo.UseShellExecute = false;
            startsInfo.FileName = "C:\\java\\bin\\java.exe";
            startsInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startsInfo.RedirectStandardOutput = true;
            startsInfo.WorkingDirectory = "C:\\Users\\Dkid_22\\Desktop\\New folder";
            startsInfo.Arguments = $"duycop {textBox1.Text} {textBox2.Text}";
            try
            {
                using (Process exe = Process.Start(startsInfo))
                {
                    exe.WaitForExit();
                    while (!exe.StandardOutput.EndOfStream)
                    {
                        string line = exe.StandardOutput.ReadLine();
                        textBox3.AppendText(line + "\n");

                    }
                }
            }
            catch (Exception ex){
                textBox3.AppendText(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.AppendText("hello\nxin chafo");
        }
    }
}
