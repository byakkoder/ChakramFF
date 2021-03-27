namespace ChakramFF.Forms
{
    partial class FrmMerge
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
            this.BtnAddStreams = new System.Windows.Forms.Button();
            this.OfdAddStreams = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnSelectTarget = new System.Windows.Forms.Button();
            this.TxtTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnPlayTarget = new System.Windows.Forms.Button();
            this.BtnShowDetails = new System.Windows.Forms.Button();
            this.PbProgress = new System.Windows.Forms.ProgressBar();
            this.TxtConsole = new System.Windows.Forms.TextBox();
            this.BtnAbort = new System.Windows.Forms.Button();
            this.BtnMerge = new System.Windows.Forms.Button();
            this.SfdTargetFile = new System.Windows.Forms.SaveFileDialog();
            this.streamList1 = new ChakramFF.Controls.StreamList();
            this.BtnShowTargetInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnAddStreams
            // 
            this.BtnAddStreams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAddStreams.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnAddStreams.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddStreams.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BtnAddStreams.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnAddStreams.Location = new System.Drawing.Point(1019, 31);
            this.BtnAddStreams.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAddStreams.Name = "BtnAddStreams";
            this.BtnAddStreams.Size = new System.Drawing.Size(177, 42);
            this.BtnAddStreams.TabIndex = 1;
            this.BtnAddStreams.Text = "Add File Streams";
            this.BtnAddStreams.UseVisualStyleBackColor = false;
            this.BtnAddStreams.Click += new System.EventHandler(this.BtnAddStreams_Click);
            // 
            // OfdAddStreams
            // 
            this.OfdAddStreams.Multiselect = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(52, 404);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 1);
            this.panel2.TabIndex = 15;
            // 
            // BtnSelectTarget
            // 
            this.BtnSelectTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectTarget.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnSelectTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSelectTarget.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSelectTarget.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnSelectTarget.Location = new System.Drawing.Point(937, 366);
            this.BtnSelectTarget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSelectTarget.Name = "BtnSelectTarget";
            this.BtnSelectTarget.Size = new System.Drawing.Size(83, 39);
            this.BtnSelectTarget.TabIndex = 14;
            this.BtnSelectTarget.Text = "Save...";
            this.BtnSelectTarget.UseVisualStyleBackColor = false;
            this.BtnSelectTarget.Click += new System.EventHandler(this.BtnSelectTarget_Click);
            // 
            // TxtTarget
            // 
            this.TxtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.TxtTarget.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTarget.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.TxtTarget.Location = new System.Drawing.Point(147, 374);
            this.TxtTarget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtTarget.Name = "TxtTarget";
            this.TxtTarget.ReadOnly = true;
            this.TxtTarget.Size = new System.Drawing.Size(785, 23);
            this.TxtTarget.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label2.Location = new System.Drawing.Point(45, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Target File";
            // 
            // BtnPlayTarget
            // 
            this.BtnPlayTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPlayTarget.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnPlayTarget.Enabled = false;
            this.BtnPlayTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlayTarget.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayTarget.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnPlayTarget.Location = new System.Drawing.Point(1025, 366);
            this.BtnPlayTarget.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnPlayTarget.Name = "BtnPlayTarget";
            this.BtnPlayTarget.Size = new System.Drawing.Size(83, 39);
            this.BtnPlayTarget.TabIndex = 22;
            this.BtnPlayTarget.Text = "Play";
            this.BtnPlayTarget.UseVisualStyleBackColor = false;
            this.BtnPlayTarget.Click += new System.EventHandler(this.BtnPlayTarget_Click);
            // 
            // BtnShowDetails
            // 
            this.BtnShowDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnShowDetails.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnShowDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowDetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowDetails.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnShowDetails.Location = new System.Drawing.Point(984, 548);
            this.BtnShowDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnShowDetails.Name = "BtnShowDetails";
            this.BtnShowDetails.Size = new System.Drawing.Size(211, 39);
            this.BtnShowDetails.TabIndex = 25;
            this.BtnShowDetails.Text = "Show Details >>";
            this.BtnShowDetails.UseVisualStyleBackColor = false;
            this.BtnShowDetails.Click += new System.EventHandler(this.BtnShowDetails_Click);
            // 
            // PbProgress
            // 
            this.PbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PbProgress.Location = new System.Drawing.Point(45, 510);
            this.PbProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PbProgress.Name = "PbProgress";
            this.PbProgress.Size = new System.Drawing.Size(1149, 33);
            this.PbProgress.TabIndex = 24;
            // 
            // TxtConsole
            // 
            this.TxtConsole.AcceptsReturn = true;
            this.TxtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.TxtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtConsole.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConsole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.TxtConsole.Location = new System.Drawing.Point(45, 591);
            this.TxtConsole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxtConsole.Multiline = true;
            this.TxtConsole.Name = "TxtConsole";
            this.TxtConsole.ReadOnly = true;
            this.TxtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtConsole.Size = new System.Drawing.Size(1150, 155);
            this.TxtConsole.TabIndex = 23;
            this.TxtConsole.Visible = false;
            // 
            // BtnAbort
            // 
            this.BtnAbort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnAbort.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnAbort.Enabled = false;
            this.BtnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAbort.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAbort.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnAbort.Image = global::ChakramFF.Properties.Resources.stop_icon_16;
            this.BtnAbort.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAbort.Location = new System.Drawing.Point(627, 439);
            this.BtnAbort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAbort.Name = "BtnAbort";
            this.BtnAbort.Size = new System.Drawing.Size(169, 39);
            this.BtnAbort.TabIndex = 27;
            this.BtnAbort.Text = "Stop";
            this.BtnAbort.UseVisualStyleBackColor = false;
            this.BtnAbort.Click += new System.EventHandler(this.BtnAbort_Click);
            // 
            // BtnMerge
            // 
            this.BtnMerge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnMerge.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnMerge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMerge.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMerge.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnMerge.Image = global::ChakramFF.Properties.Resources.merge_icon_16;
            this.BtnMerge.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnMerge.Location = new System.Drawing.Point(452, 439);
            this.BtnMerge.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnMerge.Name = "BtnMerge";
            this.BtnMerge.Size = new System.Drawing.Size(169, 39);
            this.BtnMerge.TabIndex = 26;
            this.BtnMerge.Text = "Merge";
            this.BtnMerge.UseVisualStyleBackColor = false;
            this.BtnMerge.Click += new System.EventHandler(this.BtnMerge_Click);
            // 
            // SfdTargetFile
            // 
            this.SfdTargetFile.Filter = "Matroska Files (*.mkv)|*.mkv";
            this.SfdTargetFile.Title = "Save target as MVK...";
            // 
            // streamList1
            // 
            this.streamList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.streamList1.AutoScroll = true;
            this.streamList1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.streamList1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.streamList1.Location = new System.Drawing.Point(45, 80);
            this.streamList1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.streamList1.Name = "streamList1";
            this.streamList1.Padding = new System.Windows.Forms.Padding(9, 7, 9, 7);
            this.streamList1.Size = new System.Drawing.Size(1150, 276);
            this.streamList1.TabIndex = 0;
            // 
            // BtnShowTargetInfo
            // 
            this.BtnShowTargetInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnShowTargetInfo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnShowTargetInfo.Enabled = false;
            this.BtnShowTargetInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnShowTargetInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnShowTargetInfo.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnShowTargetInfo.Location = new System.Drawing.Point(1113, 366);
            this.BtnShowTargetInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnShowTargetInfo.Name = "BtnShowTargetInfo";
            this.BtnShowTargetInfo.Size = new System.Drawing.Size(83, 39);
            this.BtnShowTargetInfo.TabIndex = 28;
            this.BtnShowTargetInfo.Text = "Info.";
            this.BtnShowTargetInfo.UseVisualStyleBackColor = false;
            this.BtnShowTargetInfo.Click += new System.EventHandler(this.BtnShowTargetInfo_Click);
            // 
            // FrmMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.ClientSize = new System.Drawing.Size(1243, 778);
            this.ControlBox = false;
            this.Controls.Add(this.BtnShowTargetInfo);
            this.Controls.Add(this.BtnAbort);
            this.Controls.Add(this.BtnMerge);
            this.Controls.Add(this.BtnShowDetails);
            this.Controls.Add(this.PbProgress);
            this.Controls.Add(this.TxtConsole);
            this.Controls.Add(this.BtnPlayTarget);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.BtnSelectTarget);
            this.Controls.Add(this.TxtTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BtnAddStreams);
            this.Controls.Add(this.streamList1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMerge";
            this.Text = "FrmMerge";
            this.Load += new System.EventHandler(this.FrmMerge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.StreamList streamList1;
        private System.Windows.Forms.Button BtnAddStreams;
        private System.Windows.Forms.OpenFileDialog OfdAddStreams;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnSelectTarget;
        private System.Windows.Forms.TextBox TxtTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnPlayTarget;
        private System.Windows.Forms.Button BtnShowDetails;
        private System.Windows.Forms.ProgressBar PbProgress;
        private System.Windows.Forms.TextBox TxtConsole;
        private System.Windows.Forms.Button BtnAbort;
        private System.Windows.Forms.Button BtnMerge;
        private System.Windows.Forms.SaveFileDialog SfdTargetFile;
        private System.Windows.Forms.Button BtnShowTargetInfo;
    }
}