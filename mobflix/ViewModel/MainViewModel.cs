using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mobflix.Model;
using mobflix.Service;
namespace mobflix.ViewModel
{ 
    public partial class MainViewModel : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<MBCategory> obcategories;

        [ObservableProperty]
        public ObservableCollection<MBVideo> obvideos;

        //Category
        public string Name
        {
            get
            {
                return (string) obcategories.GetType().GetProperty("Name").GetValue(obcategories, null);
            }
        }

        public string ButtonColor
        {
            get
            {
                return (string)obcategories.GetType().GetProperty("ButtonColor").GetValue(obcategories, null);
            }
        }

        //Video
        public string Category
        {
            get
            {
                return (string)obvideos.GetType().GetProperty("Category").GetValue(obvideos, null);
            }
        }

        public string Url
        {
            get
            {
   
                return (string)obvideos.GetType().GetProperty("Url").GetValue(obvideos, null);

            }
        }

        public string Id
        {
            get
            {
                return (string)obvideos.GetType().GetProperty("Id").GetValue(obvideos, null);
            }
        }

        partial void OnObvideosChanged(ObservableCollection<MBVideo> value)
        {
            MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
            obvideos = new ObservableCollection<MBVideo>(mbVideo.videoList as List<MBVideo>);
            foreach (MBVideo mbvideo in obvideos)
            {
                mbvideo.ButtonColor = Color.FromArgb(mbvideo.ButtonColorCode);
            }
        }

        partial void OnObcategoriesChanged(ObservableCollection<MBCategory> value)
        {
            MBCategory mbCategory = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
            obcategories = new ObservableCollection<MBCategory>(mbCategory.categoryList as List<MBCategory>);
            foreach (MBCategory category in obcategories)
            {
                category.ButtonColor = Color.FromArgb(category.ButtonColorCode);
            }
        }

        MBVideo videoSelecionado;
        public MBVideo VideoSelecionado
        {
            get
            {
                return videoSelecionado;
            }
            set
            {
                videoSelecionado = value;
                if(value != null)
                {
                    MessagingCenter.Send(videoSelecionado, "VideoSelecionado");
                }
                videoSelecionado = null;
            }
        }

        public MainViewModel()
        {
            MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
            obvideos = new ObservableCollection<MBVideo>(mbVideo.videoList as List<MBVideo>);
            foreach (MBVideo mbvideo in obvideos)
            {
                mbvideo.ButtonColor = Color.FromArgb(mbvideo.ButtonColorCode);
            }

            MBCategory mbCategory = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
            obcategories = new ObservableCollection<MBCategory>(mbCategory.categoryList as List<MBCategory>);
            foreach (MBCategory category in obcategories)
            {
                category.ButtonColor = Color.FromArgb(category.ButtonColorCode);
            }
        }

        [RelayCommand]
        void AddNewVideo()
        {
            MessagingCenter.Send(this, "NewVideo");
        }


        //[RelayCommand]
        //async void MBSelectionChanged(MBVideo video)
        //{
        //    var videoDictionary = new Dictionary<string, object>();
        //    videoDictionary["data"] = video;
        //    await Shell.Current.GoToAsync("UpdateVideo", videoDictionary);
        //}

        //SelectionChangedCommand="{Binding MBSelectionChangedCommand}"
        //SelectionChangedCommandParameter="{Binding SelectedItem, Source={x:Reference VideoList}}"
    }
}
