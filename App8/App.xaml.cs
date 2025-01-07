namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var button = new Button() { Text = "Create new window." };
            button.Clicked += async (s, a) =>
            {
                var window2 = new Window(new ContentPage());
                window2.Created += (s, a) => System.Diagnostics.Debug.WriteLine(nameof(window2.Created));
                window2.Deactivated += (s, a) => System.Diagnostics.Debug.WriteLine(nameof(window2.Deactivated));
                window2.Activated += (s, a) => System.Diagnostics.Debug.WriteLine(nameof(window2.Activated));
                OpenWindow(window2);
            };

            MainPage = new MainPage();
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnStart()
        {
            base.OnStart();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window =  base.CreateWindow(activationState);
            
            window.Created += Window_Created;
            window.Deactivated += Window_Deactivated;
            window.Activated += Window_Activated;

            return window;
        }

        private void Window_Activated(object? sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Window_Activated");
        }

        private void Window_Deactivated(object? sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Window_Deactivated");
        }

        private void Window_Created(object? sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Window_Created");
        }
    }
}
