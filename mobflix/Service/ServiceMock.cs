using mobflix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Provider.MediaStore;

namespace mobflix.Service
{
    public static class ServiceMock
    {
        static string targetFile;

        public static Object RefreshMBData<T>(string fileType)
        {
            targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, fileType);
            return CommonServiceMock.readData<T>(targetFile);
        }

        public static void CreateMBItem(Object mbObj, string fileType)
        {
            targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, fileType);
            CommonServiceMock.writeData(targetFile, mbObj);
        }

        //public static Object RefreshMBVideoItem(int idValue, string fileType, Object mbObj)
        //{

        //}

        public static void UpdateMBVideoItem(MBVideo videoValue)
        {

        }

        public static void DeleteMBVideo(int idValue)
        {

        }

        public static void InitMockData()
        {
            var video = new MBVideo();
            video.videoList.Add(new MBVideo { id = 1, Category = "Mobile", Url = "card1.png", ButtonColorCode = "#D82D2D" });
            video.videoList.Add(new MBVideo { id = 2, Category = "Mobile", Url = "card2.png", ButtonColorCode = "#D82D2D" });
            video.videoList.Add(new MBVideo { id = 3, Category = "Mobile", Url = "card3.png", ButtonColorCode = "#D82D2D" });

            var category = new MBCategory();
            category.categoryList.Add(new MBCategory { id = 1, Name = "Front end", ButtonColorCode = "#5781EF" });
            category.categoryList.Add(new MBCategory { id = 2, Name = "Programação", ButtonColorCode = "#19940F" });
            category.categoryList.Add(new MBCategory { id = 3, Name = "Mobile", ButtonColorCode = "#D82D2D" });

            string targetVideoFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "videos");
            string targetCategoryFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "categories");
            File.Delete(targetVideoFile);
            File.Delete(targetCategoryFile);
            CommonServiceMock.writeData(targetVideoFile, video);
            CommonServiceMock.writeData(targetCategoryFile, category);

        }
    }
}
