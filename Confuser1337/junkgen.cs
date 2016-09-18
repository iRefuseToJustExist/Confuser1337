using Confuser1337.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confuser1337
{
    public partial class junkgen : Form
    {
        public junkgen()
        {
            InitializeComponent();
        }
        static Random random = new Random();
        public static char charc()
        {
            // This method returns a random lowercase letter.
            // ... Between 'a' and 'z' inclusize.
            int num = random.Next(0, 26); // Zero to 25
            char let = (char)('a' + num);
            return let;
        }
        public static string randc(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string rands(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string k = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            return randc(1) + k + randc(1);
        }
        public string choose_type()
        {
           
            return "a";
        }
        public void dothings()
        {
           
        }Random rzz = new Random();
        public int get_int()
        {
            int id2 = rzz.Next(0, 5);
            int variable_value_i = 0;
            if (id2 == 0)
            {
                variable_value_i = rzz.Next(1, 99);
            }
            else if (id2 == 1)
            {
                variable_value_i = rzz.Next(1, 9999);
            }
            else if (id2 == 2)
            {
                variable_value_i = rzz.Next(1, 999999);
            }
            else if (id2 == 3)
            {
                variable_value_i = rzz.Next(1, 99999999);
            }
            else if (id2 == 4)
            {
                variable_value_i = rzz.Next(1, 999999999);
            }
            return variable_value_i;
        }
       
        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
        public string make_vars()
        {
            string data = "";

            Random r = new Random();
            string[] variables = new string[variable.Value];
            string[] variable_value_s = new string[variable.Value];
            int[] variable_value_i = new int[variable.Value];
            long[] variable_value_l = new long[variable.Value];
            float[] variable_value_f = new float[variable.Value];
            int[] fag = new int[variable.Value]; Random rz = new Random();
           
            foreach (int i in fag)
            {
                
                string local_string = "";
                int id = rz.Next(0, 11);
                if (id == 0)
                {
                    local_string = "string %rand% = \"%string%\"; \n";
                }
                else if(id == 1)
                {
                    local_string = "sbyte %rand% =  %sbyte%; \n";
                }
                else if (id == 2)
                {
                    local_string = "byte %rand% =  %byte%; \n";
                }
                else if (id == 3)
                {
                    local_string = "short %rand% = %short%; \n";
                }
                else if (id == 4)
                {
                    local_string = "ushort %rand% = %ushort%; \n";
                }
                else if (id == 5)
                {
                    local_string = "uint %rand% = %uint%; \n";
                }
                else if (id == 6)
                {
                    local_string = "int %rand% = %int%; \n";
                }
                else if (id == 7)
                {
                    local_string = "long %rand% = %long%; \n";
                }
                else if (id == 8)
                {
                    local_string = "ulong %rand% = %ulong%; \n";
                }
                else if (id == 9)
                {
                    local_string = "float %rand% = %float%*; \n";
                }
                else if (id == 10)
                {
                    local_string = "double %rand% = %double%; \n";
                }
               

                variables[i] = rands(r.Next(min.Value, max.Value));
                
               
                local_string = local_string.Replace("%rand%", variables[i]);
                if (local_string.Contains("%string%"))
                {
                  
                    variable_value_s[i] = rands(r.Next(min.Value, max.Value));
                    local_string = local_string.Replace("%string%", variable_value_s[i]);
                }else if (local_string.Contains("%sbyte%"))
                {
                    variable_value_i[i] = rz.Next(-128, 127);
                    local_string = local_string.Replace("%sbyte%", variable_value_i[i].ToString());
                }
                else if (local_string.Contains("%byte%"))
                {
                    variable_value_i[i] = rz.Next(0, 255);
                    local_string = local_string.Replace("%byte%", variable_value_i[i].ToString());
                }
                else if (local_string.Contains("%short%"))
                {
                    variable_value_i[i] = rz.Next(-32768, 32767);
                    local_string = local_string.Replace("%short%", variable_value_i[i].ToString());
                }
                else if (local_string.Contains("%ushort%"))
                {
                    variable_value_i[i] = rz.Next(0, 65535);
                    local_string = local_string.Replace("%ushort%", variable_value_i[i].ToString());
                }
                else if (local_string.Contains("%uint%"))
                {
                    variable_value_i[i] = get_int();
                    local_string = local_string.Replace("%uint%", variable_value_i[i].ToString());
                }
                else if (local_string.Contains("%int%"))
                {

                    variable_value_i[i] = get_int();
                    local_string = local_string.Replace("%int%", variable_value_i[i].ToString());
                }
                else if (local_string.Contains("%long%"))
                {

                    variable_value_l[i] = LongRandom(1, 90000000000000050, rz);
                    local_string = local_string.Replace("%long%", variable_value_l[i].ToString());
                }
                else if (local_string.Contains("%ulong%"))
                {
                    
                    variable_value_l[i] = LongRandom(1, 90000000000000050, rz);
                    local_string = local_string.Replace("%ulong%", variable_value_l[i].ToString());
                }
                else if (local_string.Contains("%float%"))
                {

                    variable_value_f[i] = NextFloat(rz);
                    local_string = local_string.Replace("%float%", variable_value_f[i].ToString());
                    local_string = local_string.Replace(",", ".");
                    local_string = local_string.Replace("*", "F");

                }
                else if (local_string.Contains("%double%"))
                {

                    variable_value_f[i] = NextFloat(rz);
                    local_string = local_string.Replace("%double%", variable_value_f[i].ToString());
                    local_string = local_string.Replace(",", ".");
                }
                else
                {
                    MessageBox.Show("Unknown type!");
                }
                data += local_string;
                
            }
            
          

            return data;
        }
        public string make_class()
        {
            string base_ = Resources.junk1;
            Random r = new Random();
            string classname = rands(r.Next(min.Value, max.Value));
            base_ = base_.Replace("%class%" , classname);
            for (int i = 0; i < functions.Value; i++)
            {
                base_ += make_void();
            }
            base_ += "\n} ";
            return base_;
        }
        public string make_void()
        {
            string base_ = Resources.junk2;
            Random r = new Random();
            string voidname = rands(r.Next(min.Value, max.Value));
            base_ = base_.Replace("%void%", voidname);
         //   base_ =  base_.Replace("//junk", make_vars());
            
            return base_;
        }
        public void construct()
        {
            string junk = "";

            for(int i = 0; i < classes.Value; i++)
            {
             junk += make_class();
            }
            curr_junk = junk;
            
        }
        public string curr_junk = "";
        private void firefoxButton1_Click(object sender, EventArgs e)
        {
            //     variables();
            construct();
        }
        bool drag;
        int mousex; int mousey;
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Top = Cursor.Position.Y - mousey;
                this.Left = Cursor.Position.X - mousex;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            mousex = Cursor.Position.X - this.Left;
            mousey = Cursor.Position.Y - this.Top;
        }

        private void firefoxButton3_Click(object sender, EventArgs e)
        {if(curr_junk == "")
            {
                MessageBox.Show("Current junk code in empty.");
            }
            else
            {
                MessageBox.Show(curr_junk);
            }
            
        }

        private void firefoxButton2_Click(object sender, EventArgs e)
        {
            if (curr_junk == "")
            {
                MessageBox.Show("Randomize some junk first.");
            }
            else
            {
                junkshit.junkcode = curr_junk;
                this.Hide();
            }
           
        }
    }
    
}
