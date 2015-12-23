using GalaSoft.MvvmLight;
using ListViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using System.Linq;

namespace ListViewDemo.ViewModel
{
    public class GroupMainViewModel : ViewModelBase
    {
        public GroupMainViewModel()
        {
            SetSymbolList();
            Grouping();//实现分组
        }

        private ObservableCollection<SymbolItem> symbolItems;

        private ObservableCollection<SymbolGroup> _symbolGroups;

        public ObservableCollection<SymbolGroup> SymbolGroups
        {
            get
            {
                return _symbolGroups;
            }

            set
            {
                _symbolGroups = value;
            }
        }

        private void SetSymbolList()
        {
            this.symbolItems = new ObservableCollection<SymbolItem>();

            foreach (Symbol item in Enum.GetValues(typeof(Symbol)))
            {
                //SymbolIcon si = new SymbolIcon((Symbol)Enum.Parse(typeof(Symbol), i.ToString(), true));
                SymbolItem symbolItem = new SymbolItem()
                {
                    Item = item,
                    IntVal = (int)item,
                    StringVal = Enum.GetName(typeof(Symbol), item)
                };
                symbolItems.Add(symbolItem);
            }
        }

        private void Grouping()
        {
            SymbolGroups = new ObservableCollection<SymbolGroup>();
            List<string> groupList = new List<string>();
            foreach (SymbolItem item in symbolItems)
            {
                string val = item.StringVal[0].ToString();
                if (groupList.Contains(val))
                {
                    var group = SymbolGroups.First(g => g.Name == val);
                    group.SymbolItems.Add(item);
                }
                else
                {
                    groupList.Add(val);
                    var group = new SymbolGroup()
                    {
                        Name=val
                    };
                    group.SymbolItems.Add(item);
                    SymbolGroups.Add(group);
                }
            }

            SortSymbolGroup();
        }

        private void SortSymbolGroup()
        {
            //SymbolGroups = new ObservableCollection<SymbolGroup>(SymbolGroups.OrderBy(g => g.Name).ToList());
            //return;

            var copyArray = new SymbolGroup[SymbolGroups.Count];
            SymbolGroups.CopyTo(copyArray, 0);
            SymbolGroups.Clear();

            for (int i = 65; i < 91; i++)//65-90 ASCII A-Z
            {
                try
                {
                    var group = copyArray.First(g => g.Name == ((char)i).ToString());
                    if (group != null)
                    {
                        SymbolGroups.Add(group);
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
