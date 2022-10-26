
using mobflix.Model;
using System.Collections.ObjectModel;
using static Android.Provider.MediaStore;
using System.Text.Json;
using mobflix.Service;

namespace mobflix;

public partial class NewVideo : ContentPage
{
    private MBCategory mbCategorySelected;

    public NewVideo()
    {
		InitializeComponent();

        MBCategory mbcategories = new MBCategory();
        mbcategories = CategoryServiceMock.RefreshMBCategories();

        CategoryList.ItemsSource = mbcategories.categoryList;
    }

	private async void AddNewVideo_Clicked(object sender, EventArgs e)
	{

        MBVideo mbVideo = VideoServiceMock.RefreshMBVideos();
        mbVideo.videoList.Add(new MBVideo { Category = mbCategorySelected.Name, Url = urlEntry.Text, ButtonColorCode = mbCategorySelected.ButtonColorCode });
        VideoServiceMock.CreateMBVideoItem(mbVideo);

        await Navigation.PushAsync(new MainPage());
    }

    private void OnSelectedIndexChanged_CategoryList(object sender, EventArgs e)
    {
        mbCategorySelected = ((Picker)sender).SelectedItem as MBCategory;
    }
}