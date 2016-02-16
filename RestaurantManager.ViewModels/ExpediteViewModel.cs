using RestaurantManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        protected override void OnDataLoaded()
        {
            base.FirePropertyChanged("OrderItems");
        }

        public List<Order> OrderItems => base.Repository.Orders; //Modern way to implement getter only function-like properties
        //public List<Order> OrderItems
        //{
        //    get { return base.Repository.Orders; }
        //}

    }
}
