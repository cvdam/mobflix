
using mobflix.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using mobflix.Service;

namespace mobflix;

public partial class UpdateVideo : ContentPage
{
    private MBCategory mbCategorySelected;

    public UpdateVideo(MBVideo video)
    {
		InitializeComponent();

        MBCategory mbcategories = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
        CategoryList.ItemsSource = mbcategories.categoryList;

        urlEntry.Text = video.Url;
        CategoryList.SelectedItem = video;
        videoId.Text  = video.id.ToString();
     }

	private async void UpdateVideoInfo_Clicked(object sender, EventArgs e)
	{
        MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
        int videoIndex = mbVideo.videoList.FindIndex(v => v.id == int.Parse(videoId.Text));

        MBCategory mbcategories = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
        int categoryIndex = mbcategories.categoryList.FindIndex(c => c.Name == mbCategorySelected.Name);

        mbVideo.videoList[videoIndex].Url = urlEntry.Text;
        mbVideo.videoList[videoIndex].Category = mbCategorySelected.Name;
        mbVideo.videoList[videoIndex].ButtonColor = mbcategories.categoryList[categoryIndex].ButtonColor;
        mbVideo.videoList[videoIndex].ButtonColorCode = mbcategories.categoryList[categoryIndex].ButtonColorCode;

        ServiceMock.UpdateMBData(mbVideo, "videos");

        await Navigation.PushAsync(new MainPage());
    }

    private async void DeleteVideoInfo_Clicked(object sender, EventArgs e)
    {
        MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
        var videoToRemove = mbVideo.videoList.Single(v => v.id == int.Parse(videoId.Text));
        mbVideo.videoList.Remove(videoToRemove);

        ServiceMock.UpdateMBData(mbVideo, "videos");
        await Navigation.PushAsync(new MainPage());
    }

    private void OnSelectedIndexChanged_CategoryList(object sender, EventArgs e)
    {
        mbCategorySelected = ((Picker)sender).SelectedItem as MBCategory;
    }
}