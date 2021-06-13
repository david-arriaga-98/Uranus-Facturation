using System;
using System.Windows.Forms;

namespace ProyectoPuntoNet.Forms.Products
{
    public partial class SalesApplyFilters : Form
    {
        private Sales.DelegateApplyFilter _delegateApplyFilter;

        public SalesApplyFilters(Sales.DelegateApplyFilter delegateApplyFilter)
        {
            _delegateApplyFilter = delegateApplyFilter;
            InitializeComponent();
            DTmTO.Value = DateTime.Now.AddDays(1);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = DTmFrom.Value;
            DateTime dateTo = DTmTO.Value;
            if (CBoxState.SelectedIndex.Equals(-1))
            {
                _delegateApplyFilter(dateFrom, dateTo, null);
            }
            else
            {
                _delegateApplyFilter(dateFrom, dateTo, CBoxState.SelectedIndex.Equals(0) ? true : false);
            }
            Dispose();
        }
    }
}
