using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UI.ViewModel;

namespace UI.View
{
    /// <summary>
    /// Логика взаимодействия для AssetView.xaml
    /// </summary>
    public partial class AssetView : Window
    {
        public AssetView()
        {
            InitializeComponent();
            var vm = new AssetsViewModel(Close);
            DataContext = vm;
        }
    }
}
