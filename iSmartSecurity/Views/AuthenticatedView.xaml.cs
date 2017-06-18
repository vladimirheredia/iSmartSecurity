using iSmartSecurity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
