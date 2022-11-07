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


namespace mobflix.ViewModel
{

    public partial class NewVideoViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<MBCategory> obcategories;

        private MBVideo mbVideo { get; set; }

        private MBCategory selectedCategory;
        public MBCategory SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; }
        }

        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

        public NewVideoViewModel()
        {
            mbVideo = new MBVideo();
            MBCategory mbCategory = (MBCategory)ServiceMock.RefreshMBData<MBCategory>("categories");
            obcategories = new ObservableCollection<MBCategory>(mbCategory.categoryList as List<MBCategory>);
        }

        [RelayCommand]
        void AddNewVideo()
        {
            int videoid = 0;

            mbVideo = (MBVideo)ServiceMock.RefreshMBData<MBVideo>("videos");
            if (mbVideo.videoList.Count > 0)
            {
                videoid = mbVideo.videoList.LastOrDefault().id + 1;
            }

            mbVideo.videoList.Add(new MBVideo { id = videoid, Category = selectedCategory.Name, Url = Url, ButtonColorCode = selectedCategory.ButtonColorCode }); 
            ServiceMock.UpdateMBData(mbVideo, "videos");
            MessagingCenter.Send(this, "CreateNewVideo");
        }
    }
}
