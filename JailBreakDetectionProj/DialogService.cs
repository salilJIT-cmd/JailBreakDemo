using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JailBreakDetectionProj
{
    public interface IDialogService
    {
        Task ShowAlertAsync(string title, string message, string cancel);
    }

    public class DialogService : IDialogService
    {
        public Task ShowAlertAsync(string title, string message, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
