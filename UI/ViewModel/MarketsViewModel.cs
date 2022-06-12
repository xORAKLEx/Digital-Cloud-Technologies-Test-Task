using BLL.Core.Models;
using BLL.Core.Services;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using UI.Commands;
using UI.View;

namespace UI.ViewModel
{
    public class MarketsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Market> Markets { get; }

        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand MoveToAssetsCommand { get; }
        public ICommand ChangeBackgroundColorCommand { get; }


        public string SearchText { get; set; }
        
        public MarketsViewModel(Action close)
        {
            _closeAction = close;
            SearchCommand = new RelayCommand(() => SearchAsync());
            RefreshCommand = new RelayCommand(() => InitAsync());
            MoveToAssetsCommand = new RelayCommand(() => Move());
            ChangeBackgroundColorCommand = new RelayCommand(() => Change());
            _currencyService = new CurrencyService();
            Markets = new ObservableCollection<Market>();
            BackgroundColor = Brushes.White;
            DataGridBackground = Brushes.GhostWhite;
            InitAsync();
        }

        public Brush BackgroundColor
        {
            get => backgroundColor;
            set
            {

                backgroundColor = value;
                NotifyPropertyChanged();
            }
        }
        
        public Brush DataGridBackground
        {
            get => dataGridBackgroundColor;
            set
            {

                dataGridBackgroundColor = value;
                NotifyPropertyChanged();
            }
        }

        private readonly ICurrencyService _currencyService;

        private readonly Action _closeAction;
        private Brush backgroundColor;
        private Brush dataGridBackgroundColor;

        private async Task SearchAsync()
        {
            var m = await _currencyService.GetMarkets();

            Markets.Clear();

            foreach (var item in m.Where (x => x.Base_asset.Contains(SearchText)))
            {
                Markets.Add(item);
            }
        }

        private void Move()
        {
            var view = new AssetView();
            view.Show();
            _closeAction.Invoke();

        }

        private async Task InitAsync()
        {
            var m = await _currencyService.GetMarkets();

            Markets.Clear();

            var i = 0;

            foreach (var item in m.OrderBy(x => x.Volume_24h))
            {
                Markets.Add(item);

                i++;

                if (i == 10)
                {break; }

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

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        
        
    }
}
