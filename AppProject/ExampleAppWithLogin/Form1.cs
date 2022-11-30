using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ExampleAppWithLogin
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        readonly private String ServerURL = "http://localhost:3000/";
        readonly private String CurrentVersion = "0.0.1";
        public Form1()
        {
            InitializeComponent();
            CheckUpdate();
        }

        private void htmlPanel1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            metroStyleManager1.Update();
        }
        
        void CheckUpdate()
        {
            WebClient webclient = new WebClient();
            String VersionCheckResponse = webclient.DownloadString(ServerURL + "updatecheck.php?v=" + CurrentVersion);
            if(VersionCheckResponse == "1")
            {
                MessageBox.Show("A New update is avaliable\nPlease update app to use it", "NEW UPADTE");
                Close();
            }
            if(VersionCheckResponse == "0")
            {
                Console.WriteLine("No update avaliable");
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
            using (MD5 md5Hash = MD5.Create())
            {
                string md5pass = GetMd5Hash(md5Hash, metroTextBox2.Text);
                WebClient webclient = new WebClient();
                String AuthResponse = webclient.DownloadString(ServerURL + "auth.php?user=" + metroTextBox1.Text + "&password=" + md5pass);
                if(AuthResponse == "1")
                {
                    Form2 f2 = new Form2(metroTextBox1.Text);
                    f2.Show();
                    this.Hide();
                } else
                {
                    MessageBox.Show("Wrong Password or account does not exists");
                }
            }
        }
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
