namespace ChakramFF.Controls
{
    partial class StreamItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ChkSelectStream = new System.Windows.Forms.CheckBox();
            this.LblFileName = new System.Windows.Forms.Label();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.BtnUp = new System.Windows.Forms.Button();
            this.BtnDown = new System.Windows.Forms.Button();
            this.BtnStreamInfo = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.PanItemContainer = new System.Windows.Forms.Panel();
            this.PanItemContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChkSelectStream
            // 
            this.ChkSelectStream.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkSelectStream.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ChkSelectStream.FlatAppearance.CheckedBackColor = System.Drawing.Color.Navy;
            this.ChkSelectStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChkSelectStream.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkSelectStream.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.ChkSelectStream.Location = new System.Drawing.Point(10, 12);
            this.ChkSelectStream.Name = "ChkSelectStream";
            this.ChkSelectStream.Size = new System.Drawing.Size(104, 24);
            this.ChkSelectStream.TabIndex = 0;
            this.ChkSelectStream.Text = "Video";
            this.ChkSelectStream.UseVisualStyleBackColor = false;
            this.ChkSelectStream.CheckedChanged += new System.EventHandler(this.ChkSelectStream_CheckedChanged);
            // 
            // LblFileName
            // 
            this.LblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblFileName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(171)))), ((int)(((byte)(184)))));
            this.LblFileName.Location = new System.Drawing.Point(120, 12);
            this.LblFileName.Name = "LblFileName";
            this.LblFileName.Size = new System.Drawing.Size(420, 24);
            this.LblFileName.TabIndex = 1;
            this.LblFileName.Text = "Example File.mp4";
            this.LblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LblFileName.Click += new System.EventHandler(this.LblFileName_Click);
            // 
            // BtnPreview
            // 
            this.BtnPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPreview.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPreview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPreview.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnPreview.Image = global::ChakramFF.Properties.Resources.preview_icon_16;
            this.BtnPreview.Location = new System.Drawing.Point(575, 12);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(23, 24);
            this.BtnPreview.TabIndex = 2;
            this.BtnPreview.UseVisualStyleBackColor = false;
            this.BtnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSettings.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSettings.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnSettings.Image = global::ChakramFF.Properties.Resources.settings_icon_16;
            this.BtnSettings.Location = new System.Drawing.Point(604, 12);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(23, 24);
            this.BtnSettings.TabIndex = 3;
            this.BtnSettings.UseVisualStyleBackColor = false;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // BtnUp
            // 
            this.BtnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnUp.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUp.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnUp.Image = global::ChakramFF.Properties.Resources.up_icon_16;
            this.BtnUp.Location = new System.Drawing.Point(633, 12);
            this.BtnUp.Name = "BtnUp";
            this.BtnUp.Size = new System.Drawing.Size(23, 24);
            this.BtnUp.TabIndex = 4;
            this.BtnUp.UseVisualStyleBackColor = false;
            this.BtnUp.Click += new System.EventHandler(this.BtnUp_Click);
            // 
            // BtnDown
            // 
            this.BtnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDown.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDown.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnDown.Image = global::ChakramFF.Properties.Resources.down_icon_16;
            this.BtnDown.Location = new System.Drawing.Point(662, 12);
            this.BtnDown.Name = "BtnDown";
            this.BtnDown.Size = new System.Drawing.Size(23, 24);
            this.BtnDown.TabIndex = 5;
            this.BtnDown.UseVisualStyleBackColor = false;
            this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
            // 
            // BtnStreamInfo
            // 
            this.BtnStreamInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStreamInfo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnStreamInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStreamInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStreamInfo.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnStreamInfo.Image = global::ChakramFF.Properties.Resources.info_icon_16;
            this.BtnStreamInfo.Location = new System.Drawing.Point(546, 12);
            this.BtnStreamInfo.Name = "BtnStreamInfo";
            this.BtnStreamInfo.Size = new System.Drawing.Size(23, 24);
            this.BtnStreamInfo.TabIndex = 6;
            this.BtnStreamInfo.UseVisualStyleBackColor = false;
            this.BtnStreamInfo.Click += new System.EventHandler(this.BtnStreamInfo_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnDelete.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDelete.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.BtnDelete.Image = global::ChakramFF.Properties.Resources.close_icon_16;
            this.BtnDelete.Location = new System.Drawing.Point(691, 12);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(23, 24);
            this.BtnDelete.TabIndex = 7;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // PanItemContainer
            // 
            this.PanItemContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(42)))), ((int)(((byte)(53)))));
            this.PanItemContainer.Controls.Add(this.ChkSelectStream);
            this.PanItemContainer.Controls.Add(this.BtnDelete);
            this.PanItemContainer.Controls.Add(this.BtnStreamInfo);
            this.PanItemContainer.Controls.Add(this.LblFileName);
            this.PanItemContainer.Controls.Add(this.BtnDown);
            this.PanItemContainer.Controls.Add(this.BtnPreview);
            this.PanItemContainer.Controls.Add(this.BtnUp);
            this.PanItemContainer.Controls.Add(this.BtnSettings);
            this.PanItemContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanItemContainer.Location = new System.Drawing.Point(0, 0);
            this.PanItemContainer.Name = "PanItemContainer";
            this.PanItemContainer.Size = new System.Drawing.Size(723, 47);
            this.PanItemContainer.TabIndex = 8;
            this.PanItemContainer.Click += new System.EventHandler(this.PanItemContainer_Click);
            // 
            // StreamItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.Controls.Add(this.PanItemContainer);
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "StreamItem";
            this.Size = new System.Drawing.Size(723, 54);
            this.PanItemContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ChkSelectStream;
        private System.Windows.Forms.Label LblFileName;
        private System.Windows.Forms.Button BtnPreview;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.Button BtnUp;
        private System.Windows.Forms.Button BtnDown;
        private System.Windows.Forms.Button BtnStreamInfo;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Panel PanItemContainer;
    }
}
