

namespace mobflix;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
    }

    private async void AdicionarVideo_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Alerta", "Adicionar novo video", "OK");
    }
}

