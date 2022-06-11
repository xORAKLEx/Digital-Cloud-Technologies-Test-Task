using BLL.Core.Models;
using BLL.Core.Services;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModel
{
    public class MarketsViewModel
    {
        private readonly ICurrencyService _currencyService;

        private readonly Action _closeAction;
        public MarketsViewModel(Action close)
        {
            _closeAction = close;
            SearchCommand = new RelayCommand(() => SearchAsync());
            RefreshCommand = new RelayCommand(() => InitAsync());
            MoveToAssetsCommand = new RelayCommand(() => _closeAction.Invoke());
            _currencyService = new CurrencyService();
            Markets = new ObservableCollection<Market>();
            InitAsync();
        }

        private async Task SearchAsync()
        {
            var m = await _currencyService.GetMarkets();

            Markets.Clear();

            foreach (var item in m.Where (x => x.Base_asset.Contains(SearchText)))
            {
                Markets.Add(item);
            }
        }

        private async Task InitAsync()
        {
            var m = await _currencyService.GetMarkets();

            Markets.Clear();

            foreach (var item in m)
            {
                Markets.Add(item);
            }
        }

        

        public ObservableCollection<Market> Markets { get; }

        public ICommand SearchCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand MoveToAssetsCommand { get; }

        public string SearchText { get; set; }
        
    }
}
