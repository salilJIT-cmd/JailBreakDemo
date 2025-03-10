using banditoth.MAUI.JailbreakDetector.Interfaces;

namespace JailBreakDetectionProj
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IJailbreakDetector _jailbreakDetector;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = IPlatformApplication.Current.Services.GetRequiredService<MainViewModel>();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
