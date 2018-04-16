using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TestApp.Controls
{
    public partial class TestCtrlView : ContentView
    {
        public bool IsBusy = false;
        public int AsuntoID { get; set; }

        public event EventHandler<EventArgs> ButtonClicked;

        public TestCtrlView()
        {
            this.AsuntoID = 0;
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            this.IsBusy = !this.IsBusy;
            this.AsuntoID ++;
            this.ButtonClicked?.Invoke(sender, e);
        }
    }
}
