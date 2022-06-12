using BLL.Core.Models;
using BLL.Core.Services;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using UI.Commands;
using UI.View;

namespace UI.ViewModel
{
    public class AssetsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly ICurrencyService _currencyService;

        private readonly Action _closeAction;
        private Brush backgroundColor;
        private Brush dataGridBackgroundColor;
             
        public AssetsViewModel(Action close)
        {
            _closeAction = close;
            MoveToMarketsCommand = new RelayCommand(() => Move());
            ChangeBackgroundColorCommand = new RelayCommand(() => Change());
            _currencyService = new CurrencyService();
            Assets = new ObservableCollection<AssetRowViewModel>();
            Markets = new ObservableCollection<Market>();
            InitAsync();
            BackgroundColor = Brushes.White;
            DataGridBackground = Brushes.GhostWhite;
        }

        public ObservableCollection<AssetRowViewModel> Assets { get; }
        public ObservableCollection<Market> Markets { get; }
        public ICommand SearchCommand { get; }
        public ICommand MoveToMarketsCommand { get; }
        public ICommand ChangeBackgroundColorCommand { get; }

        public Brush BackgroundColor { get => backgroundColor;
            set
            {
                
                backgroundColor = value;
                NotifyPropertyChanged();
            }  
        }

        public Brush DataGridBackground { get => dataGridBackgroundColor;
            set 
            {
                dataGridBackgroundColor = value;
                NotifyPropertyChanged();
            }
        }

        private void Change()
        {

            if (BackgroundColor == Brushes.White && DataGridBackground == Brushes.GhostWhite)
            {
                BackgroundColor = Brushes.Black;
                DataGridBackground = Brushes.DarkGray;

            }
            else if (BackgroundColor == Brushes.Black && DataGridBackground == Brushes.DarkGray)
            {
                BackgroundColor = Brushes.White;
                DataGridBackground = Brushes.GhostWhite;

            }

        }

        private void Move()
        {
            var view = new MarketsView();
            view.Show();
            _closeAction.Invoke();

        }

        private async Task InitAsync()
        {
            var m = await _currencyService.GetAssets();

            Assets.Clear();

            foreach (var item in m)
            {
                Assets.Add(new AssetRowViewModel((x) => GetRowDetailsAsync(x), item.Name, item.Asset_id));
            }
        }

        private async Task GetRowDetailsAsync(string str)
        {
            var m = await _currencyService.GetMarkets();

            Markets.Clear();

            foreach (var item in m.Where(x => x.Base_asset.Contains(str, StringComparison.OrdinalIgnoreCase)))
            {
                Markets.Add(item);
            }
        }



        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
