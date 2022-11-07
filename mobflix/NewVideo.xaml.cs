
using mobflix.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using mobflix.Service;
using mobflix.ViewModel;


namespace mobflix;

public partial class NewVideo : ContentPage
{
    private MBCategory mbCategorySelected;
    public NewVideo()
    {
		InitializeComponent();
        BindingContext = new NewVideoViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MessagingCenter.Subscribe<NewVideoViewModel>(this, "CreateNewVideo",
            (msg) =>
            {
                Navigation.PushAsync(new MainPage());
            });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<NewVideoViewModel>(this, "CreateNewVideo");
    }

    private void OnSelectedIndexChanged_CategoryList(object sender, EventArgs e)
    {
        mbCategorySelected = ((Picker)sender).SelectedItem as MBCategory;
    }
}