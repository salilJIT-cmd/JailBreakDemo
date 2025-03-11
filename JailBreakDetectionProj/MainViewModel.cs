using System.Threading.Tasks;

#if ANDROID || IOS
using banditoth.MAUI.JailbreakDetector.Interfaces;
#endif

namespace JailBreakDetectionProj
{
    public class MainViewModel
    {
        #if ANDROID || IOS
        private readonly IJailbreakDetector _detector;
        #endif
        private readonly IDialogService _dialogService;

        public MainViewModel(
            #if ANDROID || IOS
            IJailbreakDetector detector,
            #endif
            IDialogService dialogService)
        {
            #if ANDROID || IOS
            _detector = detector;
            #endif
            _dialogService = dialogService;
            CheckSecurity();
        }

        public async void CheckSecurity()
        {
            #if ANDROID || IOS
            bool isCompromised = await _detector.IsRootedOrJailbrokenAsync();
            await ShowAlert(isCompromised);
            #else
            await ShowAlert(false); // Always show "secure" for non-supported platforms
            #endif
        }

        private async Task ShowAlert(bool isCompromised)
        {
            await _dialogService.ShowAlertAsync(
                "Security Status",
                isCompromised ? "Device is compromised!" : "Device is secure",
                "OK"
            );
        }
    }
}