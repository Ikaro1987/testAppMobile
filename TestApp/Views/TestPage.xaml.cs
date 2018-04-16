using System;
using System.Collections.Generic;

using Xamarin.Forms;

using TestApp.Controls;

namespace TestApp.Views
{
    public partial class TestPage : ContentPage
    {
        ViewModels.TestViewModel ViewModel { get; set; }
        PopupView CtrlPopup { get; set; }

        public TestPage()
        {
            InitializeComponent();

            this.BindingContext = ViewModel = new ViewModels.TestViewModel();

            //for (int c = 0; c < 3; c++)
            //{
            //    TestCtrlView ctrl = new TestCtrlView();
            //    ctrl.ButtonClicked += (sender, e) => { lblCounter.Text = ctrl.AsuntoID.ToString(); };
            //    this.slContent.Children.Add(ctrl);
            //}

            TestCtrlView ctrl = new TestCtrlView();
            ctrl.ButtonClicked += (sender, e) =>
            {
                lblCounter.Text = ctrl.AsuntoID.ToString();
                this.CtrlPopup.ShowPopup = false;
            };

            CtrlPopup = new PopupView("Asuntos", ctrl) { ShowPopup = false };
            CtrlPopup.ButtonCloseClicked += (sender, e) => { lblCounter.Text = "Se pulso el b oton cerrar"; };
            var al = ((AbsoluteLayout)this.Content);
            al.Children.Add(CtrlPopup);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            this.CtrlPopup.Opacity = 0;
            this.CtrlPopup.ShowPopup = true;
            this.CtrlPopup.FadeTo(1, 300);

        }
    }

}
