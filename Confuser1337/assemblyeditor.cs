using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confuser1337
{
    public partial class assemblyeditor : Form
    {
        public assemblyeditor()
        {
            InitializeComponent();
        }
        Random r = new Random(); public bool drag;
        public int mousex;
        public int mousey;
        private void firefoxButton1_Click(object sender, EventArgs e)
        {
           
            textBox1.Text = assemblyz.stubt(10);
            textBox2.Text = assemblyz.stubt(10);
            textBox3.Text = assemblyz.stubt(10);
            textBox4.Text = assemblyz.stubt(10);
            textBox5.Text = assemblyz.stubt(10);
            textBox6.Text = r.Next(0, 10).ToString() + "." + r.Next(0, 10) + "." + r.Next(0, 10) + "." + r.Next(0, 10);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - this.Left;
            mousey = Cursor.Position.Y - this.Top;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mousey;
                this.Left = Cursor.Position.X - mousex;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void firefoxButton2_Click(object sender, EventArgs e)
        {
            assemblyz.title = textBox1.Text;
            assemblyz.description = textBox2.Text;
            assemblyz.company = textBox3.Text;
            assemblyz.product = textBox4.Text;
            assemblyz.copyright = textBox5.Text;
            assemblyz.version = textBox6.Text;
            Hide();
        }
    }
    public class assemblyz
    {
        static Random random = new Random();
        public static string _stub_(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string stubt(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string k = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            return _stub_(1) + k + _stub_(1);
        }
        public static string title = "Launcher1337";
        public static string description = "Launcher1337";
        public static string company = "Launcher1337";
        public static string product = "Launcher1337";
        public static string copyright = "Launcher1337";
        public static string version = "1.0.0.0";
      
    }
}
