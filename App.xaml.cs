
namespace TodoSAM
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var b = base.CreateWindow(activationState);
            b.Width = 600;
            return b;
        }
    }
}
