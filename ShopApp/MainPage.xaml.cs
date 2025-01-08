using ShopApp.DataAccess;

namespace ShopApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var dbContext = new ShopDbContext();
            Category.Text = dbContext.Categories.Count().ToString();
            Client.Text = dbContext.Clients.Count().ToString();
            Product.Text = dbContext.Products.Count().ToString();
        }

    }

}
