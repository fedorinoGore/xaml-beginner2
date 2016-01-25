using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RestaurantManager.Extensions
{
    public class RightClickBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }
        public string Message { get; set; } = "God Bless you";
        public string Title { get; set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page) {
                this.AssociatedObject = associatedObject;
                (this.AssociatedObject as Page).RightTapped += Right_Click;
            }
        }

        private async void Right_Click(object sender, RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(this.Message, this.Title).ShowAsync();
        }

        public void Detach()
        {
            (this.AssociatedObject as Page).RightTapped -= Right_Click;
        }
    }
}
