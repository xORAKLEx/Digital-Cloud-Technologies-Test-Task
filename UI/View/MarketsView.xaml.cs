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
    /// Логика взаимодействия для MarketsView.xaml
    /// </summary>
    public partial class MarketsView : Window
    {
        public MarketsView()
        {
            InitializeComponent();

            var vm = new MarketsViewModel(Close);
            DataContext = vm;
        }
    }
}
