using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Cars
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppViewModel avm = new AppViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = avm;            
            
            dgCars.Columns[0].Width = 150;
            dgCars.Columns[1].Width = 75;
            dgCars.Columns[2].Width = 50;
            dgCars.Columns[3].Width = 130;

            avm.DG = dgCars;
        }        
    }
}
