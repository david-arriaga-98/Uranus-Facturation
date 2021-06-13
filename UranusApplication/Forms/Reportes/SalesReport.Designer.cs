
namespace ProyectoPuntoNet.Forms.Reportes
{
    partial class SalesReport
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reporteVentasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.projectDataSet = new ProyectoPuntoNet.ProjectDataSet();
            this.BtnBack = new FontAwesome.Sharp.IconButton();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporte_VentasTableAdapter = new ProyectoPuntoNet.ProjectDataSetTableAdapters.Reporte_VentasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteVentasBindingSource
            // 
            this.reporteVentasBindingSource.DataMember = "Reporte_Ventas";
            this.reporteVentasBindingSource.DataSource = this.projectDataSet;
            // 
            // projectDataSet
            // 
            this.projectDataSet.DataSetName = "ProjectDataSet";
            this.projectDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.White;
            this.BtnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnBack.FlatAppearance.BorderSize = 0;
            this.BtnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBack.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.Black;
            this.BtnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.BtnBack.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(64)))), ((int)(((byte)(175)))));
            this.BtnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BtnBack.IconSize = 20;
            this.BtnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBack.Location = new System.Drawing.Point(3, 3);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(26, 28);
            this.BtnBack.TabIndex = 38;
            this.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            reportDataSource1.Name = "SalesDataSet";
            reportDataSource1.Value = this.reporteVentasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProyectoPuntoNet.Forms.Reportes.ReportesGraficos.Sales.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 26);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(624, 505);
            this.reportViewer1.TabIndex = 41;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // reporte_VentasTableAdapter
            // 
            this.reporte_VentasTableAdapter.ClearBeforeFill = true;
            // 
            // SalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(622, 530);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.BtnBack);
            this.Font = new System.Drawing.Font("Poppins", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SalesReport";
            this.Text = "SalesReport";
            this.Load += new System.EventHandler(this.SalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.projectDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton BtnBack;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private ProjectDataSet projectDataSet;
        private System.Windows.Forms.BindingSource reporteVentasBindingSource;
        private ProjectDataSetTableAdapters.Reporte_VentasTableAdapter reporte_VentasTableAdapter;
    }
}