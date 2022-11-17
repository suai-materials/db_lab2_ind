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

namespace SuperDBApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel _viewModel = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            Constants.Frame = SFrame;
            DataContext = _viewModel;
            _viewModel.ChangeToView(Box.Text);
        }

        private void ToAddTable(object sender, RoutedEventArgs e)
        {
            _viewModel.ChangeToAddTable();
        }

        private void ToViewTable(object sender, RoutedEventArgs e)
        {
            _viewModel.ChangeToView(Box.Text);
        }

        private void Box_OnSelected(object sender, RoutedEventArgs e)
        {
            _viewModel.ChangeToView(((TextBlock) ((ComboBox) sender).SelectedItem).Text);
        }
    }
}