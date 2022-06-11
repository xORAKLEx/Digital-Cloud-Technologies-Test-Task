using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModel
{
    public class AssetRowViewModel
    {
        public AssetRowViewModel(Action<string> detailsCommand, string base_asset)
        {
            DetailsCommand = new RelayCommand(() => detailsCommand.Invoke(Base_asset));
            Base_asset = base_asset;
        }

        public ICommand DetailsCommand { get; }
        public string Base_asset { get; }
    }
}
