using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModel
{
    public class AssetRowViewModel
    {
        public AssetRowViewModel(Action<string> detailsCommand, string base_asset, string asset_id)
        {
            DetailsCommand = new RelayCommand(() => detailsCommand.Invoke(asset_id));
            Base_asset = base_asset;
        }

        public ICommand DetailsCommand { get; }
        public string Base_asset { get; }
    }
}
