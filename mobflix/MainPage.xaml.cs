
using mobflix.Model;
using System.Collections.ObjectModel;

namespace mobflix;

public partial class MainPage : ContentPage
{

    private ObservableCollection<Video> videos;
    private ObservableCollection<Category> categories;
   
	public MainPage()
	{
		InitializeComponent();

        //Mocks to populate CollectionViews

        videos = new ObservableCollection<Video>()
        {
            new Video { Name = "Mobile", Card = "card1.png", ButtonColor = Color.FromArgb("#D82D2D") },
            new Video { Name = "Mobile", Card = "card2.png", ButtonColor = Color.FromArgb("#D82D2D") },
            new Video { Name = "Mobile", Card = "card3.png", ButtonColor = Color.FromArgb("#D82D2D") }
        };

        VideoList.ItemsSource = videos;

        categories = new ObservableCollection<Category>()
        {
            new Category { Name = "Front end", ButtonColor = Color.FromArgb("#5781EF") },
            new Category { Name = "programação", ButtonColor = Color.FromArgb("#19940F") },
            new Category { Name = "Mobile", ButtonColor = Color.FromArgb("#D82D2D") }
        };

        CategoryList.ItemsSource = categories;
    }

    private async void AdicionarVideo_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Alerta", "Add new video", "OK");
    }
}

