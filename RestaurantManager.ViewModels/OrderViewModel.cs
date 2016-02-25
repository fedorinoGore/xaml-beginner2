using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using RestaurantManager.Extensions;
using System;
using System.Linq;
using System.Diagnostics;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private ObservableCollection<MenuItem> _selected = new ObservableCollection<MenuItem>();
        private ObservableCollection<MenuItem> _items = new ObservableCollection<MenuItem>();
        private string _specialRequestText = String.Empty;

        public DelegateCommand<int> AddToOrderCommand { get; private set; }
        public DelegateCommand<string> SubmitOrderCommand { get; private set; }

        public OrderViewModel()
        {
            AddToOrderCommand = new DelegateCommand<int>(AddToOrderExecute, AddToOrderCanExecute);
            SubmitOrderCommand = new DelegateCommand<string>(SubmitOrderExecute, SubmitOrderCanExecute);
        }

        private bool AddToOrderCanExecute(int ListItemkey)
        {
            if (ListItemkey >= 0) return true;
            return false;
        }

        private bool SubmitOrderCanExecute(string obj)
        {
            return this.CurrentlySelectedMenuItems.Count > 0;
            //return true;
        }

        private void SubmitOrderExecute(string obj)
        {
            var rnd = new Random();
            int tableIndex = rnd.Next((int)base.Repository.Tables.Count());

            base.Repository.Orders.Add(
                new Order()
                {
                    Complete = false,
                    Expedite = true,
                    SpecialRequests = SpecialRequestText,
                    Table = base.Repository.Tables[tableIndex], //random Table selected
                    Items = CurrentlySelectedMenuItems.ToList<MenuItem>()
                });
            this.CurrentlySelectedMenuItems.Clear();
            SpecialRequestText = String.Empty;
            //SubmitOrderCommand.RaiseCanExecuteChanged(); //Not sure that this is a right place for this.Maybe it will be better to put in a CurrentlySelectedMenuItems setter
            //TODO:Have to navigate to Expedite page I guess... Should I Use button event?
        }

        private void AddToOrderExecute(int index)
        {
            if (index >= 0) this.CurrentlySelectedMenuItems.Add(this.MenuItems[index]);
        }

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5],
                this.MenuItems[7],
            };

        }

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _items; }
            set
            {
                _items = value;
                base.FirePropertyChanged();
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _selected; }
            set
            {
                _selected = value;
                base.FirePropertyChanged();
                SubmitOrderCommand?.RaiseCanExecuteChanged();
            }
        }


        public string SpecialRequestText
        {
            get { return _specialRequestText; }
            set
            {
                if (_specialRequestText != value) _specialRequestText = value;
                base.FirePropertyChanged();
            }
        }
    }
}
