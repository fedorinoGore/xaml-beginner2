using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _selected = new List<MenuItem>();
        private List<MenuItem> _items = new List<MenuItem>();

        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new List<MenuItem>
            {
                this.MenuItems[3],
                this.MenuItems[5],
                this.MenuItems[7],
            };
        }

        public List<MenuItem> MenuItems
        {
            get { return _items; }
            set
            {
                _items = value;
                base.FirePropertyChanged();
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _selected; }
            set
            {
                _selected = value;
                base.FirePropertyChanged();
            }
        }

    }
}
