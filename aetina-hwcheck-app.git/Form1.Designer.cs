namespace aetina_hwcheck_app.git
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_serialnumber = new System.Windows.Forms.TextBox();
            this.serial_number = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GPU_STATUS = new System.Windows.Forms.TextBox();
            this.RAM_STATUS = new System.Windows.Forms.TextBox();
            this.SSD_STATUS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_hw_info = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tb_serialnumber);
            this.panel1.Controls.Add(this.serial_number);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.GPU_STATUS);
            this.panel1.Controls.Add(this.RAM_STATUS);
            this.panel1.Controls.Add(this.SSD_STATUS);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbx_hw_info);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 573);
            this.panel1.TabIndex = 0;
            // 
            // tb_serialnumber
            // 
            this.tb_serialnumber.AcceptsReturn = true;
            this.tb_serialnumber.Location = new System.Drawing.Point(242, 22);
            this.tb_serialnumber.Name = "tb_serialnumber";
            this.tb_serialnumber.Size = new System.Drawing.Size(509, 22);
            this.tb_serialnumber.TabIndex = 15;
            // 
            // serial_number
            // 
            this.serial_number.AutoSize = true;
            this.serial_number.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.serial_number.Location = new System.Drawing.Point(64, 19);
            this.serial_number.Name = "serial_number";
            this.serial_number.Size = new System.Drawing.Size(177, 24);
            this.serial_number.TabIndex = 23;
            this.serial_number.Text = "Serial Number : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(619, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "GPU Card";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(359, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 21;
            this.label2.Text = "DRAM";
            // 
            // GPU_STATUS
            // 
            this.GPU_STATUS.Font = new System.Drawing.Font("PMingLiU", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.GPU_STATUS.Location = new System.Drawing.Point(547, 146);
            this.GPU_STATUS.Multiline = true;
            this.GPU_STATUS.Name = "GPU_STATUS";
            this.GPU_STATUS.ReadOnly = true;
            this.GPU_STATUS.Size = new System.Drawing.Size(238, 158);
            this.GPU_STATUS.TabIndex = 20;
            this.GPU_STATUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RAM_STATUS
            // 
            this.RAM_STATUS.Font = new System.Drawing.Font("PMingLiU", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RAM_STATUS.Location = new System.Drawing.Point(280, 146);
            this.RAM_STATUS.Multiline = true;
            this.RAM_STATUS.Name = "RAM_STATUS";
            this.RAM_STATUS.ReadOnly = true;
            this.RAM_STATUS.Size = new System.Drawing.Size(238, 158);
            this.RAM_STATUS.TabIndex = 19;
            this.RAM_STATUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SSD_STATUS
            // 
            this.SSD_STATUS.Font = new System.Drawing.Font("PMingLiU", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.SSD_STATUS.Location = new System.Drawing.Point(3, 146);
            this.SSD_STATUS.Multiline = true;
            this.SSD_STATUS.Name = "SSD_STATUS";
            this.SSD_STATUS.ReadOnly = true;
            this.SSD_STATUS.Size = new System.Drawing.Size(238, 158);
            this.SSD_STATUS.TabIndex = 18;
            this.SSD_STATUS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(82, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 24);
            this.label1.TabIndex = 17;
            this.label1.Text = "SSD";
            // 
            // tbx_hw_info
            // 
            this.tbx_hw_info.Location = new System.Drawing.Point(3, 310);
            this.tbx_hw_info.Multiline = true;
            this.tbx_hw_info.Name = "tbx_hw_info";
            this.tbx_hw_info.ReadOnly = true;
            this.tbx_hw_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbx_hw_info.Size = new System.Drawing.Size(791, 238);
            this.tbx_hw_info.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperEdge Verify Tools";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_serialnumber;
        private System.Windows.Forms.Label serial_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GPU_STATUS;
        private System.Windows.Forms.TextBox RAM_STATUS;
        private System.Windows.Forms.TextBox SSD_STATUS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_hw_info;
    }
}

