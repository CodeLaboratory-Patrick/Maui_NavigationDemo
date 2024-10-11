using Maui_NavigationDemo.MVVM.Pages;

namespace Maui_NavigationDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
        }
    }
}
