using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListViewDemo.Models
{
    public class SymbolGroup
    {
        private string _name = string.Empty;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                //this.NotifyChange();
            }
        }

        public ObservableCollection<SymbolItem> SymbolItems
        {
            get;
            private set;
        }

        public SymbolGroup()
        {
            this.SymbolItems = new ObservableCollection<SymbolItem>();
        }
    }
}
