using System;
using System.Threading.Tasks;

namespace MarathonSkills.DesktopApp.ViewModels.WindowsViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private bool _isBigHeaderVisible;
        private bool _isSmallHeaderVisible;
        private TimeSpan _remainingTime;

        public bool IsBigHeaderVisible
        {
            get => _isBigHeaderVisible;
            set
            {
                if (value == _isBigHeaderVisible) return;
                _isBigHeaderVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsSmallHeaderVisible
        {
            get => _isSmallHeaderVisible;
            set
            {
                if (value == _isSmallHeaderVisible) return;
                _isSmallHeaderVisible = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan RemainingTime
        {
            get => _remainingTime;
            set
            {
                if (Equals(value, _remainingTime)) return;
                _remainingTime = value;
                OnPropertyChanged();
            }
        }

        public void ShowBigHeader()
        {
            IsBigHeaderVisible = true;
            IsSmallHeaderVisible = false;
        }

        public void ShowSmallHeader()
        {
            IsSmallHeaderVisible = true;
            IsBigHeaderVisible = false;
        }

        public MainWindowViewModel()
        {
            RunTimer();
        }

        private async void RunTimer()
        {
            while (true)
            {
                RemainingTime = DateTime.Parse("2021-10-21 06:00:00").Subtract(DateTime.Now);
                await Task.Delay(1000);
            }
        }
    }
}
