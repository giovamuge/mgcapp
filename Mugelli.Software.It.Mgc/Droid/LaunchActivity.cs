
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Mugelli.Software.It.Mgc.Droid
{
    [Activity(MainLauncher = true, NoHistory = true, Icon = "@drawable/icon", Theme = "@style/LaunchTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class LaunchActivity : Activity
	{      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Window.DecorView.SystemUiVisibility = StatusBarVisibility.Hidden;
            ActionBar?.Hide();
        }

        protected override void OnResume()
        {
            base.OnResume();

			StartActivity(typeof(MainActivity));

            // Viene una schermata nera
			//Task.Factory.StartNew(() => StartActivity(typeof(MainActivity));
        }
    }
}
