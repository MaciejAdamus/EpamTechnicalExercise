using EpamTechnicalExercise.ViewModel;
using System.Windows;

namespace EpamTechnicalExercise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FundViewModel _fundViewModel;

        public MainWindow()
        {
            InitializeComponent();

            _fundViewModel = new FundViewModel();

            xFundAddPanel.DataContext = _fundViewModel;
            xFundGridPanel.DataContext = _fundViewModel;
            xFundSummaryPanel.DataContext = _fundViewModel;
        }
    }
}
