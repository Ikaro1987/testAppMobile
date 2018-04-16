using System;

using Xamarin.Forms;

namespace TestApp.Views
{
    public class PopupView : ContentView
    {
        public event EventHandler<EventArgs> ButtonCloseClicked;
        PopupViewModel ViewModel { get; set; }
        RelativeLayout SlMain { get; set; }

        public View ContentView {
            get { return this.ViewModel.ContentView; }
            set { this.ViewModel.ContentView = value; }
        }

        public bool ShowPopup
        {
            get { return this.ViewModel.ShowPopup; }
            set { this.ViewModel.ShowPopup = value; }
        }

        public string Titulo
        {
            get { return this.ViewModel.Titulo; }
            set { this.ViewModel.Titulo = value; }
        }

        public PopupView(string title, View contentView)
        {
            this.BindingContext = this.ViewModel = new PopupViewModel();
            this.SetBinding(IsVisibleProperty, "ShowPopup");
            this.Titulo = title;
            this.ContentView = contentView;
            this.SlMain = new RelativeLayout();
            CreateBlur();
            CreateForm();

            Content = this.SlMain;


        }

        /// <summary>
        /// Crea el contenedor que servira como sombra
        /// </summary>
        void CreateBlur()
        {

            StackLayout slBlur = new StackLayout()
            {
                BackgroundColor = Color.FromHex("#c3c3c3"),
                Opacity = 0.5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = 0,
                Padding = 0
            };

            this.SlMain.Children.Add(slBlur,
                                Constraint.Constant(0),
                                Constraint.Constant(0),
                                Constraint.RelativeToParent((parent) => { return (parent.Width); }),
                                Constraint.RelativeToParent((parent) => { return (parent.Height); })
                               );
        }

        /// <summary>
        /// Crea el contenedor para el formulario
        /// </summary>
        void CreateForm()
        {
            StackLayout slForm = new StackLayout()
            {
                BackgroundColor = Color.White,
                Opacity = 1,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Margin = 20,
                Padding = 0
            };

            this.SlMain.Children.Add(slForm,
                                Constraint.Constant(0),
                                Constraint.Constant(0),
                                Constraint.RelativeToParent((parent) => { return (parent.Width); }),
                                Constraint.RelativeToParent((parent) => { return (parent.Height); })
                               );

            CreateHeader(slForm);
            CreateContent(slForm);
        }

        /// <summary>
        /// Espacio para agregar la vista
        /// </summary>
        /// <param name="ctrl">Ctrl.</param>
        private void CreateContent(StackLayout ctrl)
        {
            ctrl.Children.Add(this.ContentView);
        }


        /// <summary>
        /// Crea un header titulo y boton de cerrado
        /// </summary>
        /// <param name="ctrl">Ctrl.</param>
        void CreateHeader(StackLayout ctrl)
        {
            Grid grid = new Grid()
            {
                BackgroundColor = Color.FromHex("#0075a1"),
                Opacity = 1,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Margin = 0,
                Padding = 3
            };

            grid.ColumnDefinitions = new ColumnDefinitionCollection()
            {
                new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition() { Width = new GridLength(55, GridUnitType.Absolute)}
            };

            Button btnClose = new Button()
            {
                Text = "X",
                BackgroundColor = Color.White,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
                WidthRequest = 45,
                HeightRequest = 45,
                Margin = new Thickness(3),
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.Start
            };

            btnClose.Clicked += (sender, e) =>
            {
                this.ButtonCloseClicked?.Invoke(sender, e);
                this.ShowPopup = false;
            };

            Label lblTitle = new Label()
            {
                //Text = this.Titulo,
                TextColor = Color.White,
                FontSize = 14,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(3, 0)
            };

            lblTitle.SetBinding(Label.TextProperty, "Titulo");

            grid.Children.Add(lblTitle);
            grid.Children.Add(btnClose);

            Grid.SetColumn(lblTitle, 0);
            Grid.SetColumn(btnClose, 1);


            //ctrl.Children.Add(slHeader);
            ctrl.Children.Add(grid);
        }

        class PopupViewModel : BaseViewModel
        {
            bool showPopup;
            public bool ShowPopup
            {
                get { return showPopup; }
                set { SetProperty(ref showPopup, value); }
            }

            View contentView;
            public View ContentView
            {
                get { return contentView; }
                set { SetProperty(ref contentView, value); }
            }

            string titulo;
            public string Titulo
            {
                get { return titulo; }
                set { SetProperty(ref titulo, value); }
            }
        }
    }
}
