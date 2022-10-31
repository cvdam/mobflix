using mobflix.Model;
using mobflix.Service;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace mobflix;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		ServiceMock.InitMockData();

        MainPage = new AppShell();
		
	}
}
