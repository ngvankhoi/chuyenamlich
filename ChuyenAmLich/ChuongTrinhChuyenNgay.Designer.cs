namespace ChuyenAmLich
{
    partial class ChuongTrinhChuyenNgay
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
            this.dpk_ngayduong = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_ketqua = new System.Windows.Forms.Label();
            this.lb_ngaybt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpk_ngayduong
            // 
            this.dpk_ngayduong.CustomFormat = "dd/MM/yyyy";
            this.dpk_ngayduong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpk_ngayduong.Location = new System.Drawing.Point(111, 20);
            this.dpk_ngayduong.Name = "dpk_ngayduong";
            this.dpk_ngayduong.Size = new System.Drawing.Size(94, 20);
            this.dpk_ngayduong.TabIndex = 0;
            this.dpk_ngayduong.Value = new System.DateTime(2014, 1, 1, 0, 0, 0, 0);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Chuyển";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnchuyen_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_ngaybt);
            this.groupBox1.Controls.Add(this.lb_ketqua);
            this.groupBox1.Location = new System.Drawing.Point(12, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 103);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kết Quả:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ngày Dương Lịch:";
            // 
            // lb_ketqua
            // 
            this.lb_ketqua.AutoSize = true;
            this.lb_ketqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ketqua.Location = new System.Drawing.Point(9, 22);
            this.lb_ketqua.Name = "lb_ketqua";
            this.lb_ketqua.Size = new System.Drawing.Size(0, 13);
            this.lb_ketqua.TabIndex = 0;
            // 
            // lb_ngaybt
            // 
            this.lb_ngaybt.AutoSize = true;
            this.lb_ngaybt.Location = new System.Drawing.Point(9, 40);
            this.lb_ngaybt.Name = "lb_ngaybt";
            this.lb_ngaybt.Size = new System.Drawing.Size(0, 13);
            this.lb_ngaybt.TabIndex = 1;
            // 
            // ChuongTrinhChuyenNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 186);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dpk_ngayduong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChuongTrinhChuyenNgay";
            this.Text = "Chuyen Am Lich";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpk_ngayduong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_ketqua;
        private System.Windows.Forms.Label lb_ngaybt;
    }
}

