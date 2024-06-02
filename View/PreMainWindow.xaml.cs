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
using System.Windows.Shapes;
using Task18.ViewModels;

namespace Task18.View
{
    /// <summary>
    /// Логика взаимодействия для PreMainWindow.xaml
    /// </summary>
    public partial class PreMainWindow : Window
    {
        public PreMainWindow()
        {
            InitializeComponent();
            DataContext = new PreMainViewModel();
        }
    }
}
