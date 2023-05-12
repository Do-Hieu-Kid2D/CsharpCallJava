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
            // Setup cho đối tượng ProcessStartInfo -> thằng này để truyền vào Process 
            // và thằng process sẽ chạy thằng startinfo này
            ProcessStartInfo startsInfo = new ProcessStartInfo(); // new ra
            startsInfo.CreateNoWindow = true;  // không tạo cửa sổ trực quan = true;
            startsInfo.UseShellExecute = false; // k sử dụng (cmd.exe) để chạy chương trình.
            startsInfo.FileName = Application.StartupPath + "\\Resources\\java.exe";  // file name muốn chạy là java.exe
            startsInfo.WindowStyle = ProcessWindowStyle.Hidden;   // không hiện cửa sổ đối tượng j đó...
            startsInfo.RedirectStandardOutput = true;   // Đầu ra của trương trinh java.exe sẽ thông qua luồng đầu ra chuẩn -> mày có thể đọc        
            startsInfo.WorkingDirectory = Application.StartupPath + "\\Resources";  // nơi làm việc của chương trình java.exe (CT phụ mk đang gọi)
            startsInfo.Arguments = $" duycop.java {textBox1.Text} {textBox2.Text}"; // Tham số đc truyền vào chương trình đó.
            try
            {
                // oke đấy -> đoạn này là tạo 1 process vói 1 ttham số ProcessStartInfo!
                // và gọi phương thức start để chạy luôn
                using (Process exe = Process.Start(startsInfo))
                {
                    // Chương trình chính đợi thằng process chạy! 
                    exe.WaitForExit();
                    // cái này là để đọc từng dòng đầu ra -> đọc đến khi k đọc đc nữa
                    while (!exe.StandardOutput.EndOfStream)
                    {
                        string line = exe.StandardOutput.ReadLine();
                        textBox3.AppendText(line + "\n");

                    }
                }
            }
            catch (Exception ex)
            {
                textBox3.AppendText(ex.Message);
            }

        }
    }
}
