using ShopApp.DataAccess;
using ShopApp.Views;

namespace ShopApp
{
    public partial class App : Application
    {
        public App(LoginPage loginPage, ShopOutDbContext context)
        {
            InitializeComponent();
            context.Database.EnsureCreated();
            var accessToken = Preferences.Get("accessToken", string.Empty);            
            MainPage = string.IsNullOrEmpty(accessToken) ? loginPage : new AppShell();
        }
    }
}
