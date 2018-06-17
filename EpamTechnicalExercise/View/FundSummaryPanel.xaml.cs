using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EpamTechnicalExercise.View
{
    /// <summary>
    /// Interaction logic for FundSummaryPanel.xaml
    /// </summary>
    public partial class FundSummaryPanel : UserControl
    {
        public FundSummaryPanel()
        {
            InitializeComponent();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int index = (sender as DataGrid).Items.IndexOf(e.Row.DataContext);
            if (index == (sender as DataGrid).Items.Count - 1)
            {
                e.Row.FontWeight = FontWeights.Bold;
            }
        }
    }
}
