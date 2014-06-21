using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureTaker
{
    public partial class PictureTakerForm : Form
    {
        int counter = 0;
        public PictureTakerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;

                timer1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox1.Text) == false)
            {
                return;
            }

            if (Clipboard.ContainsImage())
            {
                Image img = Clipboard.GetImage();
                img.Save(string.Format(@"{0}\{1:00}.jpg", textBox1.Text, counter), ImageFormat.Jpeg);
                Clipboard.SetText("Saved");
                counter++;
            }
        }
    }
}
