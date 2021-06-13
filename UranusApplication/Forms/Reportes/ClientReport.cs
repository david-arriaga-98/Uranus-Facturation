using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms.Reportes
{
    public partial class ClientReport : Form
    {
        public ClientReport()
        {
            InitializeComponent();
        }

        private void SalesReport_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'projectDataSet.Reporte_Cliente' Puede moverla o quitarla según sea necesario.
            this.reporte_ClienteTableAdapter.Fill(this.projectDataSet.Reporte_Cliente);
            // TODO: esta línea de código carga datos en la tabla 'projectDataSet.Reporte_Inventario' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'projectDataSet.Reporte_Ventas' Puede moverla o quitarla según sea necesario.
            // TODO: esta línea de código carga datos en la tabla 'projectDataSet.Reporte_Ventas' Puede moverla o quitarla según sea necesario.
            //this.reporte_VentasTableAdapter.Fill(this.projectDataSet.Reporte_Ventas);
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("name", "David Arriaga Avilez");
            this.reportViewer1.LocalReport.SetParameters(parameters);
            //// TODO: esta línea de código carga datos en la tabla 'dB_Proyecto_ParcialDataSet.Reporte_Ventas' Puede moverla o quitarla según sea necesario.
            ////this.reporte_VentasTableAdapter.Fill(this.dB_Proyecto_ParcialDataSet.Reporte_Ventas);
            //// TODO: esta línea de código carga datos en la tabla 'dB_Proyecto_ParcialDataSet.Reporte_Ventas' Puede moverla o quitarla según sea necesario.
            //this.reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Control topParent = (Control)TopLevelControl;
            topParent.panelPosition = -1;
            topParent.btnReports_Click(null, null);
        }
    }
}
