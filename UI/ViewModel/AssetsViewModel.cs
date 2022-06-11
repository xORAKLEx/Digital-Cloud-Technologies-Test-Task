using BLL.Core.Models;
using BLL.Core.Services;
using BLL.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModel
{
    public class AssetsViewModel
    {
        private readonly ICurrencyService _currencyService;

        private readonly Action _closeAction;

        public AssetsViewModel(Action close)
        {
            _closeAction = close;
            MoveToMarketsCommand = new RelayCommand(() => _closeAction.Invoke());
            _currencyService = new CurrencyService();
            Assets = new ObservableCollection<AssetRowViewModel>();
            InitAsync();
        }

        private async Task InitAsync()
        {
            var m = await _currencyService.GetAssets();

            Assets.Clear();

            foreach (var item in m)
            {
                Assets.Add(new AssetRowViewModel((x) => GetRowDetails(x), item.Name));
            }
        }

        private void GetRowDetails(string x)
        {
        }

        public ObservableCollection<AssetRowViewModel> Assets { get; }

        public ICommand SearchCommand { get; }
        public ICommand MoveToMarketsCommand { get; }
    }
}
