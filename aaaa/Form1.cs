using System;
using System.Windows.Forms;
using System.IO;

namespace aaaa
{
    public partial class Form1 : Form
    {
        private string WebhookURL = "";
        private string PictureURL = "";
        private string Username = "";
        private dWebHook WebHook;
        private string GetFilePath()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\webhook.txt"; // so you dont have to type it each and every time
            if (!File.Exists(path))
                File.Create(path).Close();
            return path;
        }
        private void SaveInfo()
        {
            string path = GetFilePath();
            File.WriteAllText(path, WebhookURL + "\n" + PictureURL + "\n" + Username);
        }
        private void LoadInfo()
        {
            string path = GetFilePath();
            string info = File.ReadAllText(path);
            if (info.Length == 0)
                return;
            string[] array = info.Split('\n');
            WebhookURL = array[0];
            PictureURL = array[1];
            Username = array[2];
            textBox1.Text = WebhookURL;
            textBox2.Text = PictureURL;
            textBox3.Text = Username;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                WebHook.WebHook = WebhookURL;
                WebHook.UserName = Username;
                WebHook.ProfilePicture = PictureURL;
                WebHook.SendMessage(textBox4.Text);
                listBox1.Items.Add(textBox4.Text);
                textBox4.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();
            WebHook = new dWebHook();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Username = textBox3.Text;
            SaveInfo();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            PictureURL = textBox2.Text;
            SaveInfo();
            pictureBox1.ImageLocation = PictureURL;
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            WebhookURL = textBox1.Text;
            SaveInfo();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}