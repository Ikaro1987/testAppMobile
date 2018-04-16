using System;

using Xamarin.Forms;

namespace TestApp.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel()
        {
            Title = "Test";
            this.ShowPopup = false;
            this.ShowBlur = false;
        }

        bool showPopup;
        public bool ShowPopup {
            get { return showPopup; }
            set { SetProperty(ref showPopup, value); }
        }

        bool showBlur;
        public bool ShowBlur
        {
            get { return showBlur; }
            set { SetProperty(ref showBlur, value); }
        }
    }
}

