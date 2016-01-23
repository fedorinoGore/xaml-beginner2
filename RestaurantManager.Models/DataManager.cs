using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.Models
{
    public abstract class DataManager: INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public DataManager()
        {
            LoadData();
        }

        //[NotifyPropertyChangedInvocator]
        protected void FirePropertyChanged([CallerMemberName]string propName = null)
        {
            //if (PropertyChanged != null)
            //{
            //    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            //} 
            
            //Instead using modern c# syntax:
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private async void LoadData()
        {
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}
