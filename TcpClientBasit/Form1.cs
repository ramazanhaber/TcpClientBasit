using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace TcpClientBasit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpClient tcpClient;

        private void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient("127.0.0.1", 2015);
            }
            catch
            {
                Console.WriteLine("Baglanamadi");
                return;
            }

            var nStream = tcpClient.GetStream();
            var reader = new StreamReader(nStream, Encoding.Default, true);
            var writer = new StreamWriter(nStream);
            string readedStr;
            writer.WriteLine(txtMesaj.Text);
            writer.Flush();
            readedStr = reader.ReadLine();
            txtDonenMesaj.Text = readedStr;

            try
            {
                writer.Close();
                reader.Close();
                nStream.Close();
            }

            catch
            {
                Console.WriteLine("Düzgün kapatilamiyor");
            }
        }
    }
}
