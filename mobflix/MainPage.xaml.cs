
using Java.Net;
using mobflix.Model;
using System.Collections.ObjectModel;
using System.IO;
using static Android.Provider.MediaStore;
using System.Runtime.Serialization;
using System.Text.Json;
using Android.Media;
using mobflix.Service;
using Microsoft.Maui.Controls.Xaml;
using System.Windows.Input;

namespace mobflix;

public partial class MainPage : ContentPage
{

    private ObservableCollection<MBVideo> videos;
    private ObservableCollection<MBCategory> categories;

    public MainPage()
    {
        InitializeComponent();
        
        MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
        videos = new ObservableCollection<MBVideo>(mbVideo.videoList as List<MBVideo>);
        foreach(MBVideo mbvideo in videos)
        {
            mbvideo.ButtonColor = Color.FromArgb(mbvideo.ButtonColorCode);
        }
        VideoList.ItemsSource = videos;

        MBCategory mbCategory = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
        categories = new ObservableCollection<MBCategory>(mbCategory.categoryList as List<MBCategory>);
        foreach (MBCategory category in categories)
        {
            category.ButtonColor = Color.FromArgb(category.ButtonColorCode);
        }
        CategoryList.ItemsSource = categories;
    }

    private async void AddVideo_Clicked(object sender, EventArgs e)
    {
        // await DisplayAlert("Alerta", "Add new video", "OK");
        await Navigation.PushAsync(new NewVideo());  
    }

    async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //string previous = (e.PreviousSelection.FirstOrDefault() as MBVideo)?.Url;
        //string current = (e.CurrentSelection.FirstOrDefault() as MBVideo)?.Url;
        if (e.CurrentSelection.Count > 0)
        {
            MBVideo video = new MBVideo()
            {
                Url = (e.CurrentSelection.FirstOrDefault() as MBVideo)?.Url,
                Category = (e.CurrentSelection.FirstOrDefault() as MBVideo)?.Category,
                id = (e.CurrentSelection.FirstOrDefault() as MBVideo).id
            };
            await Navigation.PushAsync(new UpdateVideo(video));
        }
        VideoList.SelectedItem = null;
    }

    private async void ImageVideoPreview_Clicked(object sender, EventArgs e)
    {
        //var img = (sender as ImageButton);
        //await DisplayAlert(img.Source.ToString(), "ok", "ok");
    }
}

