using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowFocus
{
    public partial class Form1 : Form
    {
        ProcessInfo processInfo;
        ProcessInfo[] savedProcess;
        StoredData sd = new StoredData("Data");
        private IntPtr thisWindow;
        private Hotkey hotkey;
        bool max = true;
        ProcessInfo NULL = new ProcessInfo("NULL", IntPtr.Zero);


        public Form1()
        {
            InitializeComponent();
            savedProcess = new ProcessInfo[3];
            button_processRescan_Click(0, new EventArgs());
            listBox_processes.SelectedIndex = 0;

            for (int i = 0; i < 3; i++)
            {
                try
                {
                    var index = i.ToString();
                    var str = sd.Read(index, "str");
                    var hWnd = new IntPtr(Convert.ToInt32(sd.Read(index, "hWnd"), 10));
                    ProcessInfo p = new ProcessInfo(str, hWnd);
                    savedProcess[i] = p;
                }
                catch
                {

                }

            }
            comboBox_rememberedProcesses.SelectedIndex = 0;
            RefreshCombo();


            this.Visible = true;
            thisWindow = this.Handle; 
            hotkey = new Hotkey(thisWindow);
            hotkey.RegisterHotKeys();
            max = false;
            GetWindow(this.Handle);

        }


        private void button_processRescan_Click(object sender, EventArgs e)
        {
            listBox_processes.Items.Clear();
            listBox_processes.Items.AddRange(ListOfOpenProcesses().ToArray());
            //RefreshCombo();

        }

        public List<ProcessInfo> ListOfOpenProcesses()
        {
            List<ProcessInfo> @return = new List<ProcessInfo>();
            EnumWindows((hWnd, lParam) =>
            {
                if (IsWindowVisible(hWnd))
                {
                    StringBuilder windowText = new StringBuilder(256);
                    GetWindowText(hWnd, windowText, windowText.Capacity);

                    string str = windowText.ToString();
                    if (str.Length > 0)
                    {
                        ProcessInfo processInfo = new ProcessInfo(str, hWnd);
                        @return.Add(processInfo);
                    }
                }
                return true; // Continue enumeration
            }, IntPtr.Zero);

            return @return;
        }

        private void button_selectAndBring_Click(object sender, EventArgs e)
        {
            IntPtr hWnd = processInfo.hWnd;
            GetWindow(hWnd);
        }


        private void GetWindow(IntPtr hWnd)
        {
            if (!checkBox_changeWindow.Checked)
                return;
            try
            {
                RestoreWindow(hWnd);
                SetForegroundWindow(hWnd);
                if (max)
                    MaximizeWindow(hWnd);
                button_processRescan_Click(0, new EventArgs());
            }
            catch { }
            max = true;
        }

        private void timer_refreshProcesses_Tick(object sender, EventArgs e)
        {
            //button_processRescan_Click(0, new EventArgs());
            for (int i = 0; i < 3; i++)
            {
                var curr = savedProcess[i];
                bool found = false;
                for (int j = 0; j < listBox_processes.Items.Count; j++)
                {
                    var proc = (ProcessInfo)listBox_processes.Items[j];
                    if (curr.hWnd == proc.hWnd)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    string key = $"{i} - Default";
                    string val = sd.Read("Defaults", key);
                    for (int j = 0; j < listBox_processes.Items.Count; j++)
                    {
                        var pr = (ProcessInfo)listBox_processes.Items[j];
                        if (pr.str.Contains(val))
                        {
                            savedProcess[i] = pr;
                            RefreshCombo();
                        }
                    }


                }
            }

        }


        private void listBox_processes_SelectedIndexChanged(object sender, EventArgs e)
        {
            processInfo = (ProcessInfo)listBox_processes.SelectedItem;
            textBox_hWndTitle.Text = processInfo.str;
        }

        private void button_setProcess_Click(object sender, EventArgs e)
        {
            var str = processInfo.str;
            var hWnd = processInfo.hWnd;
            var index = comboBox_rememberedProcesses.SelectedIndex.ToString();
            sd.Write(index, "str", str);
            sd.Write(index, "hWnd", hWnd.ToString());
            sd.SaveRbs();
            savedProcess[comboBox_rememberedProcesses.SelectedIndex] = new ProcessInfo(str, hWnd);
            comboBox_rememberedProcesses_SelectedIndexChanged(0, new EventArgs());
            RefreshCombo();

        }

        private void RefreshCombo()
        {
            try
            {
                int index = comboBox_rememberedProcesses.SelectedIndex;
                comboBox_rememberedProcesses.Items.Clear();
                comboBox_rememberedProcesses.Items.AddRange(savedProcess.ToArray());
                comboBox_rememberedProcesses.SelectedIndex = index;
            }
            catch (Exception)
            {
                comboBox_rememberedProcesses.Items.Clear();
                //comboBox_rememberedProcesses.Items.AddRange();
            }
        }

        private void button_selected_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_rememberedProcesses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                button_processRescan_Click(0, new EventArgs());

                var savedHWnd = savedProcess[comboBox_rememberedProcesses.SelectedIndex].hWnd;
                for (int i = 0; i < listBox_processes.Items.Count; i++)
                {
                    var curr = (ProcessInfo)listBox_processes.Items[i];
                    if (savedHWnd == curr.hWnd)
                    {
                        listBox_processes.SelectedIndex = i;
                        break;
                    }
                }
                button_selectAndBring_Click(0, new EventArgs());
            }
            catch { }
            string key = $"{comboBox_rememberedProcesses.SelectedIndex} - Default";
            textBox_default.Text = sd.Read("Defaults", key);

        }
        protected override void WndProc(ref Message keyPressed)
        {
            // WParam is index of hotkey
            // 1
            if (keyPressed.Msg == WM_HOTKEY && keyPressed.WParam == (IntPtr)1)
            {
                checkBox_changeWindow.Checked = true;
                comboBox_rememberedProcesses.SelectedIndex = 0;
                comboBox_rememberedProcesses_SelectedIndexChanged(0, new EventArgs());
            }
            // WParam is index of hotkey
            // 2
            if (keyPressed.Msg == WM_HOTKEY && keyPressed.WParam == (IntPtr)2)
            {
                checkBox_changeWindow.Checked = true;
                comboBox_rememberedProcesses.SelectedIndex = 1;
                comboBox_rememberedProcesses_SelectedIndexChanged(0, new EventArgs());
            }
            // WParam is index of hotkey
            // 3
            if (keyPressed.Msg == WM_HOTKEY && keyPressed.WParam == (IntPtr)3)
            {
                checkBox_changeWindow.Checked = true;
                comboBox_rememberedProcesses.SelectedIndex = 2;
                comboBox_rememberedProcesses_SelectedIndexChanged(0, new EventArgs());
            }
            // WParam is index of hotkey
            // 4
            if (keyPressed.Msg == WM_HOTKEY && keyPressed.WParam == (IntPtr)4)
            {
                checkBox_changeWindow.Checked = true;
                //checkBox_changeWindow.Checked = true;
                max = false;
                GetWindow(this.Handle);
                button_processRescan_Click(0, new EventArgs());
                checkBox_changeWindow.Checked = false;

            }
            // WParam is index of hotkey
            // 10
            if (keyPressed.Msg == WM_HOTKEY && keyPressed.WParam == (IntPtr)10)
            {

                try
                {
                    MinimizeWindow(savedProcess[comboBox_rememberedProcesses.SelectedIndex].hWnd);
                    button_processRescan_Click(0, new EventArgs());
                }
                catch (Exception)
                {
                }
            }

            // Do whatever windows was going to do
            base.WndProc(ref keyPressed);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotkey.UnRegisterHotKeys();
        }

        private void button_selectAndBringPrivate_Click(object sender, EventArgs e)
        {
            checkBox_changeWindow.Checked = true;
            button_selectAndBring_Click(0, new EventArgs());
        }

        private void button_setDefault_Click(object sender, EventArgs e)
        {
            string val = textBox_default.Text;
            string key = $"{comboBox_rememberedProcesses.SelectedIndex} - Default";
            sd.Write("Defaults", key, val);
            sd.SaveRbs();
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            int index = comboBox_rememberedProcesses.SelectedIndex;
            savedProcess[index] = new ProcessInfo("NULL", IntPtr.Zero);
            RefreshCombo();
            string str = "NULL";
            string hWnd = "0";
            sd.Write(index.ToString(), "str", str);
            sd.Write(index.ToString(), "hWnd", hWnd);
            sd.SaveRbs();
        }
    }
    public class ProcessInfo
    {
        public string str;
        public IntPtr hWnd;
        public ProcessInfo (string str, IntPtr hWnd)
        {
            this.str = str;
            this.hWnd = hWnd;
        }
        public override string ToString()
        {
            return str;
        }
    }
}
