namespace WindowFocus
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox_processes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_processRescan = new System.Windows.Forms.Button();
            this.comboBox_rememberedProcesses = new System.Windows.Forms.ComboBox();
            this.textBox_hWndTitle = new System.Windows.Forms.TextBox();
            this.button_setProcess = new System.Windows.Forms.Button();
            this.button_selectAndBring = new System.Windows.Forms.Button();
            this.timer_refreshProcesses = new System.Windows.Forms.Timer(this.components);
            this.checkBox_changeWindow = new System.Windows.Forms.CheckBox();
            this.textBox_default = new System.Windows.Forms.TextBox();
            this.button_setDefault = new System.Windows.Forms.Button();
            this.button_clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_processes
            // 
            this.listBox_processes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_processes.FormattingEnabled = true;
            this.listBox_processes.ItemHeight = 24;
            this.listBox_processes.Location = new System.Drawing.Point(-1, 36);
            this.listBox_processes.Name = "listBox_processes";
            this.listBox_processes.Size = new System.Drawing.Size(629, 316);
            this.listBox_processes.TabIndex = 0;
            this.listBox_processes.SelectedIndexChanged += new System.EventHandler(this.listBox_processes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Processes";
            // 
            // button_processRescan
            // 
            this.button_processRescan.Location = new System.Drawing.Point(634, 45);
            this.button_processRescan.Name = "button_processRescan";
            this.button_processRescan.Size = new System.Drawing.Size(116, 23);
            this.button_processRescan.TabIndex = 2;
            this.button_processRescan.Text = "Process Rescan";
            this.button_processRescan.UseVisualStyleBackColor = true;
            this.button_processRescan.Click += new System.EventHandler(this.button_processRescan_Click);
            // 
            // comboBox_rememberedProcesses
            // 
            this.comboBox_rememberedProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_rememberedProcesses.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_rememberedProcesses.FormattingEnabled = true;
            this.comboBox_rememberedProcesses.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.comboBox_rememberedProcesses.Location = new System.Drawing.Point(634, 74);
            this.comboBox_rememberedProcesses.Name = "comboBox_rememberedProcesses";
            this.comboBox_rememberedProcesses.Size = new System.Drawing.Size(116, 32);
            this.comboBox_rememberedProcesses.TabIndex = 3;
            this.comboBox_rememberedProcesses.SelectedIndexChanged += new System.EventHandler(this.comboBox_rememberedProcesses_SelectedIndexChanged);
            // 
            // textBox_hWndTitle
            // 
            this.textBox_hWndTitle.Location = new System.Drawing.Point(637, 112);
            this.textBox_hWndTitle.Name = "textBox_hWndTitle";
            this.textBox_hWndTitle.Size = new System.Drawing.Size(113, 20);
            this.textBox_hWndTitle.TabIndex = 4;
            // 
            // button_setProcess
            // 
            this.button_setProcess.Location = new System.Drawing.Point(634, 138);
            this.button_setProcess.Name = "button_setProcess";
            this.button_setProcess.Size = new System.Drawing.Size(116, 23);
            this.button_setProcess.TabIndex = 5;
            this.button_setProcess.Text = "Set saved process";
            this.button_setProcess.UseVisualStyleBackColor = true;
            this.button_setProcess.Click += new System.EventHandler(this.button_setProcess_Click);
            // 
            // button_selectAndBring
            // 
            this.button_selectAndBring.Location = new System.Drawing.Point(637, 303);
            this.button_selectAndBring.Name = "button_selectAndBring";
            this.button_selectAndBring.Size = new System.Drawing.Size(113, 44);
            this.button_selectAndBring.TabIndex = 6;
            this.button_selectAndBring.Text = "Select And Bring to Front";
            this.button_selectAndBring.UseVisualStyleBackColor = true;
            this.button_selectAndBring.Click += new System.EventHandler(this.button_selectAndBringPrivate_Click);
            // 
            // timer_refreshProcesses
            // 
            this.timer_refreshProcesses.Enabled = true;
            this.timer_refreshProcesses.Interval = 1000;
            this.timer_refreshProcesses.Tick += new System.EventHandler(this.timer_refreshProcesses_Tick);
            // 
            // checkBox_changeWindow
            // 
            this.checkBox_changeWindow.AutoSize = true;
            this.checkBox_changeWindow.Location = new System.Drawing.Point(637, 176);
            this.checkBox_changeWindow.Name = "checkBox_changeWindow";
            this.checkBox_changeWindow.Size = new System.Drawing.Size(105, 17);
            this.checkBox_changeWindow.TabIndex = 7;
            this.checkBox_changeWindow.Text = "Change Window";
            this.checkBox_changeWindow.UseVisualStyleBackColor = true;
            // 
            // textBox_default
            // 
            this.textBox_default.Location = new System.Drawing.Point(637, 199);
            this.textBox_default.Name = "textBox_default";
            this.textBox_default.Size = new System.Drawing.Size(113, 20);
            this.textBox_default.TabIndex = 8;
            // 
            // button_setDefault
            // 
            this.button_setDefault.Location = new System.Drawing.Point(637, 226);
            this.button_setDefault.Name = "button_setDefault";
            this.button_setDefault.Size = new System.Drawing.Size(113, 23);
            this.button_setDefault.TabIndex = 9;
            this.button_setDefault.Text = "Set Default Name";
            this.button_setDefault.UseVisualStyleBackColor = true;
            this.button_setDefault.Click += new System.EventHandler(this.button_setDefault_Click);
            // 
            // button_clear
            // 
            this.button_clear.Location = new System.Drawing.Point(637, 264);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(113, 23);
            this.button_clear.TabIndex = 10;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 359);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.button_setDefault);
            this.Controls.Add(this.textBox_default);
            this.Controls.Add(this.checkBox_changeWindow);
            this.Controls.Add(this.button_selectAndBring);
            this.Controls.Add(this.button_setProcess);
            this.Controls.Add(this.textBox_hWndTitle);
            this.Controls.Add(this.comboBox_rememberedProcesses);
            this.Controls.Add(this.button_processRescan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox_processes);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Hotkey Window Focus";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_processes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_processRescan;
        private System.Windows.Forms.ComboBox comboBox_rememberedProcesses;
        private System.Windows.Forms.TextBox textBox_hWndTitle;
        private System.Windows.Forms.Button button_setProcess;
        private System.Windows.Forms.Button button_selectAndBring;
        private System.Windows.Forms.Timer timer_refreshProcesses;
        private System.Windows.Forms.CheckBox checkBox_changeWindow;
        private System.Windows.Forms.TextBox textBox_default;
        private System.Windows.Forms.Button button_setDefault;
        private System.Windows.Forms.Button button_clear;
    }
}

