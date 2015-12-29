using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        public override event PropertyChangedEventHandler PropertyChanged;

        protected override void OnDataLoaded()
        {

        }

        public List<Order> OrderItems
        {
            get { return base.Repository.Orders; }
        }

        public void FireExpeditePropertyChanged([CallerMemberName]string propName = null)
        {

        }
    }
}
