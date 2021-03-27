
namespace ChakramFF.Forms
{
    partial class FrmStreamSettings
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnPlayFile = new System.Windows.Forms.Button();
            this.TxtSourceFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnPlayStream = new System.Windows.Forms.Button();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.CboLanguage = new System.Windows.Forms.ComboBox();
            this.NudDelay = new System.Windows.Forms.NumericUpDown();
            this.ChkDefault = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.PanMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // PanMainContainer
            // 
            this.PanMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.PanMainContainer.Controls.Add(this.ChkDefault);
            this.PanMainContainer.Controls.Add(this.NudDelay);
            this.PanMainContainer.Controls.Add(this.CboLanguage);
            this.PanMainContainer.Controls.Add(this.BtnCancel);
            this.PanMainContainer.Controls.Add(this.BtnOk);
            this.PanMainContainer.Controls.Add(this.BtnPlayStream);
            this.PanMainContainer.Controls.Add(this.panel5);
            this.PanMainContainer.Controls.Add(this.label5);
            this.PanMainContainer.Controls.Add(this.panel4);
            this.PanMainContainer.Controls.Add(this.label4);
            this.PanMainContainer.Controls.Add(this.panel3);
            this.PanMainContainer.Controls.Add(this.label3);
            this.PanMainContainer.Controls.Add(this.panel1);
            this.PanMainContainer.Controls.Add(this.panel2);
            this.PanMainContainer.Controls.Add(this.TxtTitle);
            this.PanMainContainer.Controls.Add(this.label1);
            this.PanMainContainer.Controls.Add(this.BtnPlayFile);
            this.PanMainContainer.Controls.Add(this.TxtSourceFile);
            this.PanMainContainer.Controls.Add(this.label2);
            this.PanMainContainer.Size = new System.Drawing.Size(618, 390);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Gray;
            this.panel2.Location = new System.Drawing.Point(30, 62);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(492, 1);
            this.panel2.TabIndex = 19;
            // 
            // BtnPlayFile
            // 
            this.BtnPlayFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPlayFile.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnPlayFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlayFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayFile.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnPlayFile.Location = new System.Drawing.Point(526, 31);
            this.BtnPlayFile.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPlayFile.Name = "BtnPlayFile";
            this.BtnPlayFile.Size = new System.Drawing.Size(62, 32);
            this.BtnPlayFile.TabIndex = 2;
            this.BtnPlayFile.Text = "Play";
            this.BtnPlayFile.UseVisualStyleBackColor = false;
            this.BtnPlayFile.Click += new System.EventHandler(this.BtnPlayFile_Click);
            // 
            // TxtSourceFile
            // 
            this.TxtSourceFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSourceFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.TxtSourceFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSourceFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSourceFile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.TxtSourceFile.Location = new System.Drawing.Point(101, 38);
            this.TxtSourceFile.Margin = new System.Windows.Forms.Padding(2);
            this.TxtSourceFile.Name = "TxtSourceFile";
            this.TxtSourceFile.ReadOnly = true;
            this.TxtSourceFile.Size = new System.Drawing.Size(421, 18);
            this.TxtSourceFile.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label2.Location = new System.Drawing.Point(25, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source File";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Location = new System.Drawing.Point(30, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 1);
            this.panel1.TabIndex = 22;
            // 
            // TxtTitle
            // 
            this.TxtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.TxtTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.TxtTitle.Location = new System.Drawing.Point(101, 87);
            this.TxtTitle.Margin = new System.Windows.Forms.Padding(2);
            this.TxtTitle.Name = "TxtTitle";
            this.TxtTitle.Size = new System.Drawing.Size(483, 18);
            this.TxtTitle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label1.Location = new System.Drawing.Point(25, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Location = new System.Drawing.Point(30, 164);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(558, 1);
            this.panel3.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label3.Location = new System.Drawing.Point(25, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Language";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Gray;
            this.panel4.Location = new System.Drawing.Point(30, 216);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(558, 1);
            this.panel4.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label4.Location = new System.Drawing.Point(25, 191);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Delay (s)";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.Gray;
            this.panel5.Location = new System.Drawing.Point(30, 271);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(558, 1);
            this.panel5.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.label5.Location = new System.Drawing.Point(25, 246);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Default";
            // 
            // BtnPlayStream
            // 
            this.BtnPlayStream.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BtnPlayStream.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnPlayStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlayStream.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPlayStream.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnPlayStream.Location = new System.Drawing.Point(29, 334);
            this.BtnPlayStream.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPlayStream.Name = "BtnPlayStream";
            this.BtnPlayStream.Size = new System.Drawing.Size(152, 32);
            this.BtnPlayStream.TabIndex = 11;
            this.BtnPlayStream.Text = "Play Stream";
            this.BtnPlayStream.UseVisualStyleBackColor = false;
            this.BtnPlayStream.Click += new System.EventHandler(this.BtnPlayStream_Click);
            // 
            // BtnOk
            // 
            this.BtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOk.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnOk.Location = new System.Drawing.Point(395, 334);
            this.BtnOk.Margin = new System.Windows.Forms.Padding(2);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(93, 32);
            this.BtnOk.TabIndex = 12;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancel.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnCancel.Location = new System.Drawing.Point(495, 334);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(93, 32);
            this.BtnCancel.TabIndex = 13;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            // 
            // CboLanguage
            // 
            this.CboLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CboLanguage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.CboLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CboLanguage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboLanguage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.CboLanguage.FormattingEnabled = true;
            this.CboLanguage.Location = new System.Drawing.Point(100, 138);
            this.CboLanguage.Name = "CboLanguage";
            this.CboLanguage.Size = new System.Drawing.Size(488, 23);
            this.CboLanguage.TabIndex = 6;
            // 
            // NudDelay
            // 
            this.NudDelay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NudDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.NudDelay.DecimalPlaces = 4;
            this.NudDelay.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NudDelay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.NudDelay.Increment = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.NudDelay.Location = new System.Drawing.Point(100, 190);
            this.NudDelay.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NudDelay.Minimum = new decimal(new int[] {
            1000000,
            0,
            0,
            -2147483648});
            this.NudDelay.Name = "NudDelay";
            this.NudDelay.Size = new System.Drawing.Size(488, 23);
            this.NudDelay.TabIndex = 8;
            this.toolTip1.SetToolTip(this.NudDelay, "Stream delay in seconds");
            // 
            // ChkDefault
            // 
            this.ChkDefault.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkDefault.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ChkDefault.FlatAppearance.CheckedBackColor = System.Drawing.Color.Navy;
            this.ChkDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkDefault.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDefault.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.ChkDefault.Location = new System.Drawing.Point(100, 244);
            this.ChkDefault.Name = "ChkDefault";
            this.ChkDefault.Size = new System.Drawing.Size(81, 24);
            this.ChkDefault.TabIndex = 10;
            this.ChkDefault.Text = "No";
            this.ChkDefault.UseVisualStyleBackColor = false;
            this.ChkDefault.CheckedChanged += new System.EventHandler(this.ChkDefault_CheckedChanged);
            // 
            // FrmStreamSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 438);
            this.FormTitle = "Stream Settings";
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "FrmStreamSettings";
            this.Text = "FrmStreamSettings";
            this.Load += new System.EventHandler(this.FrmStreamSettings_Load);
            this.PanMainContainer.ResumeLayout(false);
            this.PanMainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudDelay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnPlayFile;
        private System.Windows.Forms.TextBox TxtSourceFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnPlayStream;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown NudDelay;
        private System.Windows.Forms.ComboBox CboLanguage;
        private System.Windows.Forms.CheckBox ChkDefault;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}