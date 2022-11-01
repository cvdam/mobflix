
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

        MBCategory mbcategories = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
        CategoryList.ItemsSource = mbcategories.categoryList;
    }

	private async void AddNewVideo_Clicked(object sender, EventArgs e)
	{
        int videoid = 0;

        MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
        if (mbVideo.videoList.Count > 0)
        {
            videoid = mbVideo.videoList.LastOrDefault().id + 1;
        }

        mbVideo.videoList.Add(new MBVideo { id = videoid ,Category = mbCategorySelected.Name, Url = urlEntry.Text, ButtonColorCode = mbCategorySelected.ButtonColorCode }); ; ; ; ;
        ServiceMock.UpdateMBData(mbVideo,"videos");

        await Navigation.PushAsync(new MainPage());
    }

    private void OnSelectedIndexChanged_CategoryList(object sender, EventArgs e)
    {
        mbCategorySelected = ((Picker)sender).SelectedItem as MBCategory;
    }
}