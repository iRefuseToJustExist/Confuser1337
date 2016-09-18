using Confuser1337.Properties;
using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Confuser1337
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public bool drag;
        public int mousex;
        public int mousey;
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
        public string assembly_file;
        private void firefoxButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = assembly.ShowDialog();
            if (result == DialogResult.OK) 
            {
                assembly_file = assembly.FileName;
                assemblypath.Text = assembly_file;
                output.SelectedPath = Path.GetDirectoryName(assembly_file);
                outputfolder.Text = Path.GetDirectoryName(assembly_file);
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#¤%&/()=?£@$€{[]}\";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string _stub_(int length)
        { 
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string stubt(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string k =  new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            return _stub_(1) + k + _stub_(1);
        }
        public string garbage_file;
        bool use_garbage = false;
        private void firefoxButton3_Click(object sender, EventArgs e)
        {
            DialogResult result = garbage.ShowDialog();
            if (result == DialogResult.OK) 
            {
                garbage_file = garbage.FileName;
                garbagefile.Text = garbage_file;
                use_garbage = true;
            }
        }
        public string output_path;
        private void firefoxButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = output.ShowDialog();
            if (result == DialogResult.OK)
            {
                output_path = output.SelectedPath;
                outputfolder.Text = output_path;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            encryptionkey.Text = RandomString(20);
            garbagekey.Text = RandomString(20);
            salt.Text = RandomString(20);
            iv.Text = RandomString(20);
        }

        private void firefoxButton4_Click(object sender, EventArgs e)
        {
            encryptionkey.Text = RandomString(20);
        }

        private void firefoxButton5_Click(object sender, EventArgs e)
        {
            garbagekey.Text = RandomString(20);
        }
      

        private void firefoxButton6_Click(object sender, EventArgs e)
        {
            
        }

       
        public void moro(byte[] bytes)
        {
          
            try {
                Assembly a = Assembly.Load(bytes);
                MethodInfo method = a.EntryPoint;
                if (method != null)
                {
                    object o = a.CreateInstance(method.Name);

                    method.Invoke(o, null);
                }
                else
                {
                    MessageBox.Show("Entrypoint is null...");
                }
                
                
            }
            catch
            {
                MessageBox.Show("This assembly is not supported...");
            }
            
        }
        public string getdir(string filename)
        {
            return Path.GetDirectoryName(filename);
        }
        public string getname(string filename)
        {
            return Path.GetFileName(filename);
        }
        string dir_lol;
        string dir;
        string suff;
        private void firefoxButton9_Click(object sender, EventArgs e)
        {
         
            
            
        }
        private byte[] Combine(params byte[][] arrays)
        {
            byte[] rv = new byte[arrays.Sum(a => a.Length)];
            int offset = 0;
            foreach (byte[] array in arrays)
            {
                System.Buffer.BlockCopy(array, 0, rv, offset, array.Length);
                offset += array.Length;
            }
            return rv;
        }
        string ofile = "";
        public void log(string t)
        {
            listBox1.Items.Add(t);
        }
        private void firefoxButton10_Click(object sender, EventArgs e)
        {
            try {
                
                dir_lol = getdir(assembly.FileName);
                log("Getting dir " + dir_lol);
                string path = getdir(assemblypath.Text) + "/" + datafolder.Text + "/";
                dir = path;
                suff = suffix.Text;
                log("Creating dir " + dir);
                Directory.CreateDirectory(dir);
                log("Encrypting file " + assembly.FileName);
                crypt.encrypt(encryptionkey.Text, assemblypath.Text, assemblypath.Text + ".crypted" , salt.Text , iv.Text);
                string crypted = assemblypath.Text + ".crypted";
                log("Reading crypted bytes " + crypted);
                byte[] memory = File.ReadAllBytes(assemblypath.Text + ".crypted");

                IEnumerable<byte[]> k = class2.Szplit(memory, memory.Length / blocksplit.Value);
                log("Splitting bytes ");
                int i = 0;
                log("Writing Splitted bytes to " + suff);
                foreach (byte[] bytes in k)
                {
                   
                    File.WriteAllBytes(dir + suff + i.ToString(), bytes);
                    i++;
                }
                if (use_garbage)
                {
                    log("Encrypting garbage " + garbagefile.Text);
                    crypt.encrypt(garbagekey.Text, garbagefile.Text, garbagefile.Text + ".crypted" , salt.Text, iv.Text);
                    string crypted2 = garbagefile.Text + ".crypted";
                    log("Reading crypted garbage bytes " + garbagefile.Text);
                    byte[] memory2 = File.ReadAllBytes(garbagefile.Text + ".crypted");
                    IEnumerable<byte[]> k2 = class2.Szplit(memory2, memory2.Length / garbagesplit.Value);
                    log("Splitting garbage bytes " + garbagefile.Text);
                    log("Writing Splitted garbage to " + suff );
                    foreach (byte[] bytes in k2)
                    {
                        byte[] garbagesuffix = { 0x2a, 0x31, 0x5a };
                        byte[] byt = Combine(garbagesuffix, bytes);
                      
                        File.WriteAllBytes(dir + suff + i.ToString(), byt);
                        i++;
                    }
                    log("Deleting file " + garbagefile.Text + ".crypted");
                    File.Delete(garbagefile.Text + ".crypted");
                    log("Deleting file " + garbagefile.Text);
                    File.Delete(garbagefile.Text);
                }
                log("Deleting file " + assembly.FileName + ".crypted");
                File.Delete(assembly.FileName + ".crypted");
                log("Deleting file " + assembly.FileName );
                File.Delete(assembly.FileName);

                int min = Convert.ToInt32(minz.Text);
                int max = Convert.ToInt32(maxz.Text);
                Random r = new Random();
                log("Getting stub src");
                string data = Resources.dastub;
                log("Replacing stub variables");
                data = data.Replace("%NAMESPACE%", stubt(r.Next(min, max)));
                data = data.Replace("%CLASS%", stubt(r.Next(min, max)));
                data = data.Replace("%ENTRYPOINT%", stubt(r.Next(min, max)));
                data = data.Replace("%ENTRYSTARTER%", stubt(r.Next(min, max)));
                data = data.Replace("%LOADFILE%", stubt(r.Next(min, max)));
                data = data.Replace("%COMBINE%", stubt(r.Next(min, max)));
                data = data.Replace("%CRYPTCLASS%", stubt(r.Next(min, max)));
                data = data.Replace("%DECRYPT%", stubt(r.Next(min, max)));
                data = data.Replace("%CRYPTING%", stubt(r.Next(min, max)));
                data = data.Replace("%STREAM%", stubt(r.Next(min, max)));
                data = data.Replace("%MAKE%", stubt(r.Next(min, max)));
                data = data.Replace("%PASS%", stubt(r.Next(min, max)));
                data = data.Replace("%KEY2%", stubt(r.Next(min, max)));
                data = data.Replace("%DIRL%", stubt(r.Next(min, max)));
                data = data.Replace("%DATA%", stubt(r.Next(min, max)));
                data = data.Replace("%EXEC%", stubt(r.Next(min, max)));
                data = data.Replace("%EXECNAME%", stubt(r.Next(min, max)));
                data = data.Replace("%TMP%", stubt(r.Next(min, max)));
                data = data.Replace("%TMP2%", stubt(r.Next(min, max)));
                data = data.Replace("%TMPB%", stubt(r.Next(min, max)));
                data = data.Replace("%INJ%", stubt(r.Next(min, max)));
                data = data.Replace("%BYT%", stubt(r.Next(min, max)));
                data = data.Replace("%FILES%", stubt(r.Next(min, max)));
                data = data.Replace("%FILE%", stubt(r.Next(min, max)));
                data = data.Replace("%DI%", stubt(r.Next(min, max)));
                data = data.Replace("%LB%", stubt(r.Next(min, max)));
                data = data.Replace("%A%", stubt(r.Next(min, max)));
                data = data.Replace("%ARG%", stubt(r.Next(min, max)));
                data = data.Replace("%EX%", stubt(r.Next(min, max)));
                data = data.Replace("%ARZ%", stubt(r.Next(min, max)));
                data = data.Replace("%RV%", stubt(r.Next(min, max)));
                data = data.Replace("%OFF%", stubt(r.Next(min, max)));
                data = data.Replace("%...%", stubt(r.Next(min, max)));
                data = data.Replace("%AES%", stubt(r.Next(min, max)));
                data = data.Replace("%keysize%", stubt(r.Next(min, max)));
                data = data.Replace("%i.%", stubt(r.Next(min, max)));
                data = data.Replace("%key.%", stubt(r.Next(min, max)));
                data = data.Replace("%i.v%", stubt(r.Next(min, max)));
                data = data.Replace("%sa.lt%", stubt(r.Next(min, max)));
                data = data.Replace("%blockz%", stubt(r.Next(min, max)));
                data = data.Replace("%crypto%", stubt(r.Next(min, max)));
                data = data.Replace("%cryptos%", stubt(r.Next(min, max)));
                data = data.Replace("%block2%", stubt(r.Next(min, max)));
                data = data.Replace("%outs%", stubt(r.Next(min, max)));
                data = data.Replace("%ins%", stubt(r.Next(min, max)));
                data = data.Replace("%buff..%", stubt(r.Next(min, max)));
                data = data.Replace("%asd%", stubt(r.Next(min, max)));
                data = data.Replace("%asd2%", stubt(r.Next(min, max)));
                data = data.Replace("%asd3%", stubt(r.Next(min, max)));
                data = data.Replace("%_B%", stubt(r.Next(min, max)));
                data = data.Replace("%key32%", stubt(r.Next(min, max)));
                data = data.Replace("%block32%", stubt(r.Next(min, max)));
                data = data.Replace("%b32%", stubt(r.Next(min, max)));
                data = data.Replace("%in23%", stubt(r.Next(min, max)));
                data = data.Replace("%out23%", stubt(r.Next(min, max)));
                data = data.Replace("%inX%", stubt(r.Next(min, max)));
                data = data.Replace("%outX%", stubt(r.Next(min, max)));
                data = data.Replace("%outXs%", stubt(r.Next(min, max)));
                data = data.Replace("%inXs%", stubt(r.Next(min, max)));
                data = data.Replace("%thrd%", stubt(r.Next(min, max)));
                data = data.Replace("%title%", assemblyz.title);
                data = data.Replace("%description%", assemblyz.description);
                data = data.Replace("%company%", assemblyz.company);
                data = data.Replace("%product%", assemblyz.product);
                data = data.Replace("%copyright%", assemblyz.copyright);
                data = data.Replace("%version%", assemblyz.version);
                data = data.Replace("%guid%", Guid.NewGuid().ToString());
                data = data.Replace("%SALT%", salt.Text);
                data = data.Replace("%IV%", iv.Text);
                data = data.Replace("%CRYPTING%", stubt(r.Next(min, max)));
                data = data.Replace("%STREAM%", stubt(r.Next(min, max)));
                data = data.Replace("%SUFFIX%", suffix.Text);
                data = data.Replace("%KEY%", encryptionkey.Text);
                data = data.Replace("%DATAFOLDER%", datafolder.Text);
                if (antidebug.Checked == true)
                {
                    log("Adding antidebug code...");
                    data = data.Replace("//ANTIDEBUG2", Resources.antidebug2);
                    data = data.Replace("//ANTIDEBUG3", Resources.antidebug3);
                    data = data.Replace("%timer%", stubt(r.Next(min, max)));
                    data = data.Replace("%timer2%", stubt(r.Next(min, max)));
                    data = data.Replace("%DEBUGCLASS%", stubt(r.Next(min, max)));
                }
                if(antivm.Checked == true)
                {
                    log("Adding antivm & sandbox...");
                    data = data.Replace("//ANTI_", Resources.antivm);
                    data = data.Replace("//ANTIVM2", Resources.antivm2);
                    data = data.Replace("%ANTICLASS%", stubt(r.Next(min, max)));
                    data = data.Replace("%__0%", stubt(r.Next(min, max)));
                    data = data.Replace("%__1%", stubt(r.Next(min, max)));
                    data = data.Replace("%__2%", stubt(r.Next(min, max)));
                    data = data.Replace("%__3%", stubt(r.Next(min, max)));
                    data = data.Replace("%__4%", stubt(r.Next(min, max)));
                    data = data.Replace("%__5%", stubt(r.Next(min, max)));
                    data = data.Replace("%__6%", stubt(r.Next(min, max)));
                    data = data.Replace("%__7%", stubt(r.Next(min, max)));
                    data = data.Replace("%__8%", stubt(r.Next(min, max)));
                    data = data.Replace("%__9%", stubt(r.Next(min, max)));
                    data = data.Replace("%__A%", stubt(r.Next(min, max)));
                    data = data.Replace("%__B%", stubt(r.Next(min, max)));
                    data = data.Replace("%__C%", stubt(r.Next(min, max)));
                    data = data.Replace("%sbox%", stubt(r.Next(min, max)));
                    data = data.Replace("%vm__%", stubt(r.Next(min, max)));
                }
                if(junkj.Checked == true)
                {
                    data = data.Replace("//JUNKZ", File.ReadAllText(Directory.GetCurrentDirectory() + "/junk.txt"));
                }
                log("Setting compile options");
                Dictionary<string, string> providerOptions = new Dictionary<string, string>
                {
                    {"CompilerVersion", "v4.0"}
                };


                CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

                CompilerParameters parameters2 = new CompilerParameters();
                log("Adding dlls to be compiled");
                parameters2.ReferencedAssemblies.Add("System.Windows.Forms.dll");
                parameters2.ReferencedAssemblies.Add("System.dll");
                parameters2.ReferencedAssemblies.Add("System.Core.dll");
                parameters2.ReferencedAssemblies.Add("System.Data.dll");
                parameters2.ReferencedAssemblies.Add("System.Management.dll");
                log("Opening save file dialog");
                outputfile.InitialDirectory = dir;
                outputfile.ShowDialog();
                parameters2.OutputAssembly = ofile;
                parameters2.GenerateInMemory = false;
                parameters2.GenerateExecutable = true;
                
           
                if(useicon.Checked == true)
                {
                    log("Choosing icon");
                    parameters2.CompilerOptions = @"/target:winexe /win32icon:" + iconpath;
                }
                else
                {
                    using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/tmp.ico", FileMode.Create))
                    {
                        Resources.leet.Save(fs);
                    }Thread.Sleep(100);
                    string ks = Directory.GetCurrentDirectory() + "\\tmp.ico";
                    parameters2.CompilerOptions = "/target:winexe /win32icon:\"" + ks + "\"";
                }
                log("Generating compiler results");
                CompilerResults results = provider.CompileAssemblyFromSource(parameters2, data);

                if (results.Errors.Count != 0)
                {
                    foreach (CompilerError CompErr in results.Errors)
                    {
                        MessageBox.Show("Error while compiling\n" + CompErr.ToString());
                    }
                }
                else
                {
                    
                    log("Confused successfully! -Thanks for using, amaa!");
                    MessageBox.Show("Launcher created successfully.\nFor your file to run you need to have the datafolder as sub directory on the directory where the executable is.\nI would suggest trying to run it to see if it works.\nThanks for using Confuser1337 by Amaa!\nLaunched saved to: " + ofile);
                    Thread.Sleep(100);
                    if (useicon.Checked == false)
                    {

                        File.Delete(Directory.GetCurrentDirectory() + "/tmp.ico");
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error occured while building\n" + ex.InnerException);
            }   
        }

        private void suffix_TextChanged(object sender, EventArgs e)
        {
            suff = suffix.Text;
        }

        private void blocksplit_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void blocksplit_Click(object sender, EventArgs e)
        {
            if(blocksplit.Value > 8)
            {
                blocksplit.Value = 8;
            }
        }

        private void blocksplit_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void firefoxTextbox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void firefoxButton12_Click(object sender, EventArgs e)
        {
        
            MessageBox.Show(Guid.NewGuid().ToString());
           
        }

        private void outputfile_FileOk(object sender, CancelEventArgs e)
        {
            ofile = outputfile.FileName;
        }

        private void firefoxButton6_Click_2(object sender, EventArgs e)
        {
       


            //           ZipFile.ExtractToDirectory(zipPath, extractPath)
        }

        private void firefoxButton7_Click(object sender, EventArgs e)
        {
            
        }

        private void firefoxButton8_Click(object sender, EventArgs e)
        {
            salt.Text = RandomString(20);
            
        }

        private void firefoxButton11_Click(object sender, EventArgs e)
        {
            iv.Text = RandomString(20);
        }
        string iconpath;
        private void firefoxButton7_Click_1(object sender, EventArgs e)
        {
            if(useicon.Checked == true)
            {
                DialogResult result = icondialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    iconpath = icondialog.FileName; 
                    

                }
            }
        }

        private void firefoxButton9_Click_1(object sender, EventArgs e)
        {
         
        }

        private void firefoxButton13_Click(object sender, EventArgs e)
        {
            assemblyeditor a = new assemblyeditor();
            a.Show();
        }

       

        private void firefoxButton14_Click_2(object sender, EventArgs e)
        {
            if(junkj.Checked == true)
            {
                junkgen ja = new junkgen();
                ja.Show();
            }
        }

        private void firefoxButton12_Click_1(object sender, EventArgs e)
        {
            junkgen j = new junkgen();
            j.Show();
        }
       
        private void firefoxButton15_Click(object sender, EventArgs e)
        { 
        }
    }
    public class junkshit
    {
        public static string junkcode = "";
    }
}
