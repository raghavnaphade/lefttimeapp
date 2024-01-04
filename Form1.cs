using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace lefttimeapp
{
    public partial class Form1 : Form
    {
        private static int WM_QUERYENDSESSION = 0x11;
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
            this.Activated += new System.EventHandler(this.Form1_Activated);
           /* this.Hide();
            this.Visible = false;*/
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            /*this.Hide()*/;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.Visible = false;
            this.Opacity = 0;
            btnReadFile_Click();
          /*  this.ShowInTaskbar = false;*/
        }

        private void btnReadFile_Click()
        {
            // Get the path of the application's startup folder
            string appFolderPath = Application.StartupPath;
          
            // Specify the filename you want to read (change it accordingly)
            string filename = "userDetails.dat";

            // Combine the folder path and filename to get the full file path
            string filePath = Path.Combine(appFolderPath, filename);
            Console.WriteLine(filePath);

            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    // Read the contents of the file
                    string fileContent = File.ReadAllText(filePath);
                    JObject jsonObject = JObject.Parse(fileContent);

                    // Display the content in a MessageBox (you can use any other way to display it)
                    int userId = (int)jsonObject["userId"];
                    int tenantId = (int)jsonObject["tenantId"];

                    // Display the values (you can use any other way to display them)
                    MessageBox.Show($"User ID: {userId}\nTenant ID: {tenantId}", "JSON Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File not found.", "File Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_QUERYENDSESSION)
            {
                string message = "System is shutting down or user is logging off.1 WndProc";

                // Get the path to the Documents folder
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Specify the file path in the Documents folder
                string filePath = Path.Combine(documentsPath, "shutdown_log1.txt");

                // Write the message to a text file
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - {message}");
                }
              //  MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot");
           
            }

            base.WndProc(ref m);
        }

      /*  private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
            this.Hide();
        }*/
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)

        {
            Console.WriteLine("Hello Form1_FormClosed");

            string message = "System is shutting down or user is logging off.1 WndProc";

            // Get the path to the Documents folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Specify the file path in the Documents folder
            string filePath = Path.Combine(documentsPath, "shutdown_log1.txt");

            // Write the message to a text file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now} - {message}");
            }
           // MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot");

        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            //In case windows is trying to shut down, don't hold the process up
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Console.WriteLine("Hello Form1_FormClosing UserClosing");

                string message = "System is shutting down or user is logging off.1 WndProc";

                // Get the path to the Documents folder
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Specify the file path in the Documents folder
                string filePath = Path.Combine(documentsPath, "close_log1.txt");

                // Write the message to a text file
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - {message}");
                }
              /*  MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot UserClosing");*/
            }
                // Prompt user to save his data

                if (e.CloseReason == CloseReason.WindowsShutDown)
            {
                Console.WriteLine("Hello Form1_FormClosing WindowsShutDown");

                string message = "System is shutting down or user is logging off.1 WndProc";

                // Get the path to the Documents folder
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Specify the file path in the Documents folder
                string filePath = Path.Combine(documentsPath, "shutdown_log1.txt");

                // Write the message to a text file
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{DateTime.Now} - {message}");
                }
               /* MessageBox.Show("queryendsession: this is a logoff, shutdown, or reboot WindowsShutDown");*/
            }
        }


    }
}
