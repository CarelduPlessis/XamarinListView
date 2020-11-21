//using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinListView
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            StackLayout MainStackLayout = new StackLayout ();
            Label hdNameLabel = new Label { Text = "Name", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)) };
            Label hdLastNameLabel = new Label { Text = "LastName", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)), HorizontalTextAlignment = TextAlignment.Center };
            Label hdBestScoreLabel = new Label { Text = "BestScore", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)), HorizontalTextAlignment = TextAlignment.Center };
            Label hdGemsLabel = new Label { Text = "Gems", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)), HorizontalTextAlignment = TextAlignment.Center };
            Label hdAvatarLabel = new Label { Text = "Avatar", FontAttributes = FontAttributes.Bold, FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label)), HorizontalTextAlignment = TextAlignment.Center};
            Grid gridMain = new Grid();
            
            List<Person> ls = new List<Person> 
            { 
                new Person { Name = "Steve", LastName = "Smith", BestScore = 50, Gems = 5, Avatar = "Avatar1.jpg"},
                new Person { Name = "Emma", LastName = "Williams",BestScore = 90, Gems = 10, Avatar = "Avatar2.jpg"}
            };

            var personDataTemplate = new DataTemplate(() =>
            {
                var grid = new Grid();
                var nameLabel = new Label ();
                var lastNameLabel = new Label { HorizontalTextAlignment = TextAlignment.Center };
                var bestScoreLabel = new Label { HorizontalTextAlignment = TextAlignment.Center };
                var gemsLabel = new Label { HorizontalTextAlignment = TextAlignment.Center };
                var Avatar = new Image();

                nameLabel.SetBinding(Label.TextProperty, "Name");
                lastNameLabel.SetBinding(Label.TextProperty, "LastName");
                bestScoreLabel.SetBinding(Label.TextProperty, "BestScore");
                gemsLabel.SetBinding(Label.TextProperty, "Gems");
                Avatar.SetBinding(Image.SourceProperty, "Avatar");

                grid.Children.Add(nameLabel);
                grid.Children.Add(lastNameLabel, 1, 0);
                grid.Children.Add(bestScoreLabel, 2, 0);
                grid.Children.Add(gemsLabel, 3, 0);
                grid.Children.Add(Avatar, 4, 0);

                return new ViewCell { View = grid };
            });

            ListView listView = new ListView
            {
                ItemsSource = ls,
                ItemTemplate = personDataTemplate,
                Margin = new Thickness(0, 20, 0, 0),
                HeightRequest = 20
            };
            
            gridMain.Children.Add(hdNameLabel);
            gridMain.Children.Add(hdLastNameLabel, 1, 0);
            gridMain.Children.Add(hdBestScoreLabel, 2, 0);
            gridMain.Children.Add(hdGemsLabel, 3, 0);
            gridMain.Children.Add(hdAvatarLabel, 4, 0);

            MainStackLayout.Children.Add(gridMain);
            MainStackLayout.Children.Add(listView);

            Content = MainStackLayout;
        }
    }
}
