using System.ComponentModel;

namespace RestaurantManager.Models
{
    public abstract class DataManager: INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        public DataManager()
        {
            LoadData();
        }

        public abstract event PropertyChangedEventHandler PropertyChanged;

        private async void LoadData()
        {
            this.Repository = new RestaurantContext();
            await this.Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}
