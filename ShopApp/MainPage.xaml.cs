using Microsoft.Maui.Controls.Shapes;
using ShopApp.DataAccess;

namespace ShopApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            var dbContext = new ShopDbContext();
            Category.Text = dbContext.Categories.Count().ToString();
            Product.Text = dbContext.Products.Count().ToString();
            Client.Text = dbContext.Clients.Count().ToString();
        }

        //private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        //{
        //    (sender as Rectangle)?.ScaleTo(2);
        //    (sender as Rectangle)?.TranslateTo(200, 200);

        //}
    }

}
