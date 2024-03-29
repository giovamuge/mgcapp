/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Mugelli.Software.It.Mgc"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<RootViewModel>();
            SimpleIoc.Default.Register<NewsViewModel>();
            SimpleIoc.Default.Register<CalendarViewModel>();
            SimpleIoc.Default.Register<ComunicationsViewModel>();
            SimpleIoc.Default.Register<NewsDetailViewModel>();
            SimpleIoc.Default.Register<CalendarDetailViewModel>();
            SimpleIoc.Default.Register<ImageGalleryViewModel>();
            SimpleIoc.Default.Register<CommunicationDetailViewModel>();
            SimpleIoc.Default.Register<InfoViewModel>();

        }

        public RootViewModel RootViewModel => ServiceLocator.Current.GetInstance<RootViewModel>();

        public NewsViewModel NewsViewModel => ServiceLocator.Current.GetInstance<NewsViewModel>();

        public CalendarViewModel CalendarViewModel => ServiceLocator.Current.GetInstance<CalendarViewModel>();

        public ComunicationsViewModel ComunicationsViewModel => ServiceLocator.Current.GetInstance<ComunicationsViewModel>();

        public NewsDetailViewModel NewsDetailViewModel => ServiceLocator.Current.GetInstance<NewsDetailViewModel>();

        public CalendarDetailViewModel CalendarDetailViewModel => ServiceLocator.Current.GetInstance<CalendarDetailViewModel>();

        public ImageGalleryViewModel ImageGalleryViewModel => ServiceLocator.Current.GetInstance<ImageGalleryViewModel>();

        public CommunicationDetailViewModel CommunicationDetailViewModel => ServiceLocator.Current.GetInstance<CommunicationDetailViewModel>();

        public InfoViewModel InfoViewModel => ServiceLocator.Current.GetInstance<InfoViewModel>();



        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}