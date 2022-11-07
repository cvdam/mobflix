using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mobflix.Model;
using mobflix.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace mobflix.ViewModel
{
    public partial class UpdateVideoViewModel : ObservableObject  //:IQueryAttributable
    {

        [ObservableProperty]
        private ObservableCollection<MBCategory> obcategories;

        private MBVideo mbvideo { get; set; }

        public string Url
        {
            get { return mbvideo.Url; }
        }

        public string videoId
        {
            get { return mbvideo.id.ToString(); }
        }

        private MBCategory selectedCategory;
        public MBCategory SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; }
        }

        public string Name
        {
            get
            {
                return (string)obcategories.GetType().GetProperty("Name").GetValue(obcategories, null);
            }
        }

        public UpdateVideoViewModel(MBVideo video)
        {
            mbvideo = video;
            MBCategory mbCategory = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
            obcategories = new ObservableCollection<MBCategory>(mbCategory.categoryList as List<MBCategory>);

            int categoryIndex = mbCategory.categoryList.FindIndex(c => c.Name == mbvideo.Category);
            selectedCategory = mbCategory.categoryList[categoryIndex];
        }

        [RelayCommand]
        void UpdateVideoInfo()
        {
            MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
            int videoIndex = mbVideo.videoList.FindIndex(v => v.id == int.Parse(videoId));

            MBCategory mbcategories = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
            int categoryIndex = mbcategories.categoryList.FindIndex(c => c.Name == selectedCategory.Name);

            mbVideo.videoList[videoIndex].Url = Url;
            mbVideo.videoList[videoIndex].Category = selectedCategory.Name;
            mbVideo.videoList[videoIndex].ButtonColor = mbcategories.categoryList[categoryIndex].ButtonColor;
            mbVideo.videoList[videoIndex].ButtonColorCode = mbcategories.categoryList[categoryIndex].ButtonColorCode;

            ServiceMock.UpdateMBData(mbVideo, "videos");
            MessagingCenter.Send(mbVideo, "UpdateVideoSelecionado");

        }

        [RelayCommand]
        void DeleteVideoInfo()
        {
            MBVideo mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
            var videoToRemove = mbVideo.videoList.Single(v => v.id == int.Parse(videoId));
            mbVideo.videoList.Remove(videoToRemove);

            ServiceMock.UpdateMBData(mbVideo, "videos");
            MessagingCenter.Send(mbVideo, "UpdateVideoSelecionado");
        }


        //public void ApplyQueryAttributes(IDictionary<string, object> query)
        //{
        //    mbvideo = (MBVideo)query["data"];
        //}
    }
}
