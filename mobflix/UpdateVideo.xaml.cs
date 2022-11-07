
using mobflix.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using mobflix.Service;
using mobflix.ViewModel;

namespace mobflix;


public partial class UpdateVideo : ContentPage
{
    private MBCategory mbCategorySelected;

    public UpdateVideo(MBVideo mbVideo)
    {
		InitializeComponent();
        BindingContext = new UpdateVideoViewModel(mbVideo);
      
     }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MessagingCenter.Subscribe<MBVideo>(this, "UpdateVideoSelecionado",
            (msg) =>
            {
                Navigation.PushAsync(new MainPage());
            });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<MBVideo>(this, "UpdateVideoSelecionado");
    }

    private void OnSelectedIndexChanged_CategoryList(object sender, EventArgs e)
    {
        mbCategorySelected = ((Picker)sender).SelectedItem as MBCategory;
    }
}