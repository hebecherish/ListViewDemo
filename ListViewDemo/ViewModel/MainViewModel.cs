using GalaSoft.MvvmLight;
using ListViewDemo.Models;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace ListViewDemo.ViewModel
{
    public class MainViewModel: ViewModelBase
    {
        public MainViewModel()
        {
            SetSymbolList();
        }

        private ObservableCollection<SymbolItem> _symbolItems;

        public ObservableCollection<SymbolItem> SymbolItems
        {
            get
            {
                return _symbolItems;
            }
            set
            {
                _symbolItems = value;
                RaisePropertyChanged();
            }
        }

        private void SetSymbolList()
        {
            this.SymbolItems = new ObservableCollection<SymbolItem>();

            foreach (Symbol item in Enum.GetValues(typeof(Symbol)))
            {
                //SymbolIcon si = new SymbolIcon((Symbol)Enum.Parse(typeof(Symbol), i.ToString(), true));
                SymbolItem symbolItem = new SymbolItem()
                {
                    Item = item,
                    IntVal=(int)item,
                    StringVal=Enum.GetName(typeof(Symbol),item)
                };
                SymbolItems.Add(symbolItem);
            }
        }
    }
}
