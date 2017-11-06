using System;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class CustomListView : ListView
    {
        public CustomListView()
        {
            //ItemTapped += OnItemTapped;
            ItemSelected += OnItemSelected;

        }

        private static void OnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            ((ListView)sender).SelectedItem = null;
        }

        //private static void OnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        //{
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}