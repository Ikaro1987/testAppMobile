using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestApp.Views;
using Xamarin.Forms;

namespace TestApp
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        PopupView CtrlPopup { get; set; }

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

            CtrlPopup = new PopupView("Turnos", new Controls.TestCtrlView()) { ShowPopup = false };
            var al = ((AbsoluteLayout)this.Content);
            al.Children.Add(CtrlPopup);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            CtrlPopup.ShowPopup = true;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItemPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
