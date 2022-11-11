using Xamarin.Forms;

namespace AppChida
{
    public partial class App : Application
    {
        public static NavigationPage nvp;

        public App ()
        {
            InitializeComponent();

            nvp = new NavigationPage(new MainPage());

            MainPage = nvp;
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

