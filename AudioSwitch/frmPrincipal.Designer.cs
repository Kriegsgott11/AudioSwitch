namespace AudioSwitch
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.txtActualDevice = new System.Windows.Forms.TextBox();
            this.BtnChangeDevice = new System.Windows.Forms.Button();
            this.BtnSettings = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDevices = new System.Windows.Forms.CheckedListBox();
            this.chkStartAtStartUp = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtActualDevice
            // 
            this.txtActualDevice.Location = new System.Drawing.Point(12, 106);
            this.txtActualDevice.Name = "txtActualDevice";
            this.txtActualDevice.ReadOnly = true;
            this.txtActualDevice.Size = new System.Drawing.Size(343, 20);
            this.txtActualDevice.TabIndex = 0;
            this.txtActualDevice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BtnChangeDevice
            // 
            this.BtnChangeDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.BtnChangeDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChangeDevice.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChangeDevice.ForeColor = System.Drawing.Color.White;
            this.BtnChangeDevice.Location = new System.Drawing.Point(96, 146);
            this.BtnChangeDevice.Name = "BtnChangeDevice";
            this.BtnChangeDevice.Size = new System.Drawing.Size(175, 50);
            this.BtnChangeDevice.TabIndex = 1;
            this.BtnChangeDevice.Text = "Change Device";
            this.BtnChangeDevice.UseVisualStyleBackColor = false;
            this.BtnChangeDevice.Click += new System.EventHandler(this.BtnChangeDevice_Click);
            // 
            // BtnSettings
            // 
            this.BtnSettings.BackgroundImage = global::AudioSwitch.Properties.Resources.options1;
            this.BtnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettings.Location = new System.Drawing.Point(328, 6);
            this.BtnSettings.Name = "BtnSettings";
            this.BtnSettings.Size = new System.Drawing.Size(33, 34);
            this.BtnSettings.TabIndex = 3;
            this.BtnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSettings.UseVisualStyleBackColor = true;
            this.BtnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(80, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lstDevices);
            this.groupBox1.Controls.Add(this.chkStartAtStartUp);
            this.groupBox1.Location = new System.Drawing.Point(12, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 185);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select your favourite devices";
            // 
            // lstDevices
            // 
            this.lstDevices.FormattingEnabled = true;
            this.lstDevices.Location = new System.Drawing.Point(6, 85);
            this.lstDevices.Name = "lstDevices";
            this.lstDevices.Size = new System.Drawing.Size(331, 94);
            this.lstDevices.TabIndex = 1;
            // 
            // chkStartAtStartUp
            // 
            this.chkStartAtStartUp.AutoSize = true;
            this.chkStartAtStartUp.Checked = true;
            this.chkStartAtStartUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStartAtStartUp.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStartAtStartUp.ForeColor = System.Drawing.Color.White;
            this.chkStartAtStartUp.Location = new System.Drawing.Point(98, 29);
            this.chkStartAtStartUp.Name = "chkStartAtStartUp";
            this.chkStartAtStartUp.Size = new System.Drawing.Size(158, 17);
            this.chkStartAtStartUp.TabIndex = 0;
            this.chkStartAtStartUp.Text = "Start at Windows start up";
            this.chkStartAtStartUp.UseVisualStyleBackColor = true;
            this.chkStartAtStartUp.CheckedChanged += new System.EventHandler(this.chkStartAtStartUp_CheckedChanged);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(52)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(367, 221);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSettings);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnChangeDevice);
            this.Controls.Add(this.txtActualDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AudioSwitch";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtActualDevice;
        private System.Windows.Forms.Button BtnChangeDevice;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox lstDevices;
        private System.Windows.Forms.CheckBox chkStartAtStartUp;
    }
}

