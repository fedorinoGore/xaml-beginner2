using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
            base.FirePropertyChanged();
        }

        public List<Order> OrderItems
        {
            get { return base.Repository.Orders; }
        }

    }
}
