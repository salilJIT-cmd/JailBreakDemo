using Microsoft.Maui.Controls;

namespace JailBreakDetectionProj
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            #if ANDROID || IOS
            // Resolve IJailbreakDetector for Android/iOS
            BindingContext = IPlatformApplication.Current.Services.GetRequiredService<MainViewModel>();
            #endif
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