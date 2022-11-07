using mobflix.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using mobflix.Service;
using Microsoft.Maui.Controls.Xaml;
using System.Windows.Input;
using mobflix.ViewModel;

namespace mobflix;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel(); 
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        MessagingCenter.Subscribe<MBVideo>(this, "VideoSelecionado",
            (msg) =>
            {
                Navigation.PushAsync(new UpdateVideo(msg));
            });
        VideoList.SelectedItem = null;

        MessagingCenter.Subscribe<MainViewModel>(this, "NewVideo",
            (msg) =>
            {
                Navigation.PushAsync(new NewVideo());
            });
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        MessagingCenter.Unsubscribe<MBVideo>(this, "VideoSelecionado");
    }
}