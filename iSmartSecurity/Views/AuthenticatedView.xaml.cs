using iSmartSecurity.ViewModels;
using System;
using System.Windows.Controls;

namespace iSmartSecurity.Views
{
    /// <summary>
    /// Interaction logic for AuthenticatedView.xaml
    /// </summary>
    public partial class AuthenticatedView : UserControl
    {
        public AuthenticatedView(Guid context)
        {
            InitializeComponent();
            DataContext = new AuthenticatedViewModel(context);
        }
    }
}
