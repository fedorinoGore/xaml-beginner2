using RestaurantManager.Extensions;
using RestaurantManager.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        private ObservableCollection<Order> _orderItems = new ObservableCollection<Order>();
        public DelegateCommand<string> ClearAllOrdersCommand { get; private set; }
        public DelegateCommand<int> DeleteOrderCommand { get; private set; }

        public ExpediteViewModel()
        {
            ClearAllOrdersCommand = new DelegateCommand<string>(ClearAllOrdersExecute, ClearAllOrdersCanExecute);
            DeleteOrderCommand = new DelegateCommand<int>(DeleteOrderExecute, DeleteOrderCanExecute);
        }

        private bool DeleteOrderCanExecute(int Id)
        {
            return true;
        }

        private void DeleteOrderExecute(int Id)
        {
            Order _orderToRemove = new Order();
            Debug.WriteLine("Deleting Id: " + Id.ToString());
            _orderToRemove = (Order)OrderItems.Where(item => item.Id == Id).Single();
            OrderItems.Remove(_orderToRemove);
        }

        private bool ClearAllOrdersCanExecute(string obj)
        {
            return this.OrderItems.Count > 0;
        }

        private void ClearAllOrdersExecute(string obj)
        {
            this.OrderItems.Clear();
            base.Repository.Orders.Clear();
            ClearAllOrdersCommand?.RaiseCanExecuteChanged();
            //base.FirePropertyChanged("OrderItems");
        }

        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;


        }

        //public List<Order> OrderItems => base.Repository.Orders; //Modern way to implement getter only function-like properties
        public ObservableCollection<Order> OrderItems
        {
            get { return _orderItems; }
            set
            {
                _orderItems = value;
                base.FirePropertyChanged();
                ClearAllOrdersCommand?.RaiseCanExecuteChanged();
            }
        }

    }
}
