using EpamTechnicalExercise.Validations;
using System.Windows.Controls;

namespace EpamTechnicalExercise.View
{
    /// <summary>
    /// Interaction logic for FundAddPanel.xaml
    /// </summary>
    public partial class FundAddPanel : UserControl
    {
        public FundAddPanel()
        {
            InitializeComponent();
        }

        private void FundAddPanel_Error(object sender, ValidationErrorEventArgs e)
        {
            if(e.Action == ValidationErrorEventAction.Added)
            {
                ValidationErrorContainer.AddError(e.Error);
            }

            if(e.Action == ValidationErrorEventAction.Removed)
            {
                ValidationErrorContainer.RemoveError(e.Error);
            }
        }
    }
}
