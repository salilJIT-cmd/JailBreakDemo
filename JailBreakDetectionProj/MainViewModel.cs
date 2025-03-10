using banditoth.MAUI.JailbreakDetector.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailBreakDetectionProj
{
    public class MainViewModel
    {
        private readonly IJailbreakDetector _detector;
        private readonly IDialogService _dialogService;

        public MainViewModel(IJailbreakDetector detector, IDialogService dialogService)
        {
            _detector = detector;
            _dialogService = dialogService;
            CheckSecurity();
        }

        public async void CheckSecurity()
        {
            bool isCompromised = await _detector.IsRootedOrJailbrokenAsync();
            await _dialogService.ShowAlertAsync(
                "Security Status",
                isCompromised ? "Device is compromised!" : "Device is secure",
                "OK"
            );
        }
    }
}
