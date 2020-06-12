namespace ManagerCoffe
{
    partial class Report
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ChiTietBanHangMonthBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.OrderCoffeDataSet = new ManagerCoffe.OrderCoffeDataSet();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMonthBH = new System.Windows.Forms.ComboBox();
            this.cbYearBH = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ChiTietBanHangMonthTableAdapter = new ManagerCoffe.OrderCoffeDataSetTableAdapters.ChiTietBanHangMonthTableAdapter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.OrderCoffeDataSet2 = new ManagerCoffe.OrderCoffeDataSet2();
            this.DOANHTHUREPORTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DOANHTHUREPORTTableAdapter = new ManagerCoffe.OrderCoffeDataSet2TableAdapters.DOANHTHUREPORTTableAdapter();
            this.cbMonthDT = new System.Windows.Forms.ComboBox();
            this.cbYearDT = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietBanHangMonthBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCoffeDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCoffeDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHUREPORTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ChiTietBanHangMonthBindingSource
            // 
            this.ChiTietBanHangMonthBindingSource.DataMember = "ChiTietBanHangMonth";
            this.ChiTietBanHangMonthBindingSource.DataSource = this.OrderCoffeDataSet;
            // 
            // OrderCoffeDataSet
            // 
            this.OrderCoffeDataSet.DataSetName = "OrderCoffeDataSet";
            this.OrderCoffeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(931, 733);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbMonthBH);
            this.tabPage1.Controls.Add(this.cbYearBH);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(923, 704);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bán Hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(584, 20);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Xuất Năm";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(459, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 36);
            this.button1.TabIndex = 5;
            this.button1.Text = "Xuất Tháng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(240, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Năm :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tháng :";
            // 
            // cbMonthBH
            // 
            this.cbMonthBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonthBH.FormattingEnabled = true;
            this.cbMonthBH.Items.AddRange(new object[] {
            "Tháng 01",
            "Tháng 02",
            "Tháng 03",
            "Tháng 04",
            "Tháng 05",
            "Tháng 06",
            "Tháng 07",
            "Tháng 08",
            "Tháng 09",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cbMonthBH.Location = new System.Drawing.Point(98, 27);
            this.cbMonthBH.Name = "cbMonthBH";
            this.cbMonthBH.Size = new System.Drawing.Size(121, 24);
            this.cbMonthBH.TabIndex = 2;
            // 
            // cbYearBH
            // 
            this.cbYearBH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYearBH.FormattingEnabled = true;
            this.cbYearBH.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cbYearBH.Location = new System.Drawing.Point(308, 27);
            this.cbYearBH.Name = "cbYearBH";
            this.cbYearBH.Size = new System.Drawing.Size(121, 24);
            this.cbYearBH.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 74);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 627);
            this.panel1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.ChiTietBanHangMonthBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ManagerCoffe.BanHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(917, 627);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.ReportViewer1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.cbYearDT);
            this.tabPage2.Controls.Add(this.cbMonthDT);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(923, 704);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Doanh Thu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ChiTietBanHangMonthTableAdapter
            // 
            this.ChiTietBanHangMonthTableAdapter.ClearBeforeFill = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 634);
            this.panel2.TabIndex = 0;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.DOANHTHUREPORTBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "ManagerCoffe.DoanhThuReport.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(917, 634);
            this.reportViewer2.TabIndex = 0;
            // 
            // OrderCoffeDataSet2
            // 
            this.OrderCoffeDataSet2.DataSetName = "OrderCoffeDataSet2";
            this.OrderCoffeDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DOANHTHUREPORTBindingSource
            // 
            this.DOANHTHUREPORTBindingSource.DataMember = "DOANHTHUREPORT";
            this.DOANHTHUREPORTBindingSource.DataSource = this.OrderCoffeDataSet2;
            // 
            // DOANHTHUREPORTTableAdapter
            // 
            this.DOANHTHUREPORTTableAdapter.ClearBeforeFill = true;
            // 
            // cbMonthDT
            // 
            this.cbMonthDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMonthDT.FormattingEnabled = true;
            this.cbMonthDT.Items.AddRange(new object[] {
            "Tháng 01",
            "Tháng 02",
            "Tháng 03",
            "Tháng 04",
            "Tháng 05",
            "Tháng 06",
            "Tháng 07",
            "Tháng 08",
            "Tháng 09",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cbMonthDT.Location = new System.Drawing.Point(101, 19);
            this.cbMonthDT.Name = "cbMonthDT";
            this.cbMonthDT.Size = new System.Drawing.Size(121, 24);
            this.cbMonthDT.TabIndex = 1;
            // 
            // cbYearDT
            // 
            this.cbYearDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbYearDT.FormattingEnabled = true;
            this.cbYearDT.Items.AddRange(new object[] {
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025"});
            this.cbYearDT.Location = new System.Drawing.Point(312, 17);
            this.cbYearDT.Name = "cbYearDT";
            this.cbYearDT.Size = new System.Drawing.Size(121, 24);
            this.cbYearDT.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(495, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "Xuất Tháng";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(623, 10);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 36);
            this.button4.TabIndex = 4;
            this.button4.Text = "Xuất Năm";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tháng :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(244, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Năm :";
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 747);
            this.Controls.Add(this.tabControl1);
            this.Name = "Report";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChiTietBanHangMonthBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrderCoffeDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrderCoffeDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DOANHTHUREPORTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ChiTietBanHangMonthBindingSource;
        private OrderCoffeDataSet OrderCoffeDataSet;
        private OrderCoffeDataSetTableAdapters.ChiTietBanHangMonthTableAdapter ChiTietBanHangMonthTableAdapter;
        private System.Windows.Forms.ComboBox cbMonthBH;
        private System.Windows.Forms.ComboBox cbYearBH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource DOANHTHUREPORTBindingSource;
        private OrderCoffeDataSet2 OrderCoffeDataSet2;
        private OrderCoffeDataSet2TableAdapters.DOANHTHUREPORTTableAdapter DOANHTHUREPORTTableAdapter;
        private System.Windows.Forms.ComboBox cbYearDT;
        private System.Windows.Forms.ComboBox cbMonthDT;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}