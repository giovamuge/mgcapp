using System;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class CustomListView : ListView
    {
        public CustomListView()
        {
            ItemTapped += OnItemTapped;
        }

        private static void OnItemTapped(object sender, ItemTappedEventArgs itemTappedEventArgs)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}