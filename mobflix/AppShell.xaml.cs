using mobflix.ViewModel;
namespace mobflix;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NewVideo), typeof(NewVideo));
        Routing.RegisterRoute(nameof(UpdateVideo), typeof(UpdateVideo));
    }
}
