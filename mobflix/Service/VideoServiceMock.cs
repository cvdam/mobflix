using mobflix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Android.Provider.MediaStore;

namespace mobflix.Service
{
    public static class VideoServiceMock
    {
        static string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "videos");

        public static MBVideo RefreshMBVideos()
        {
            using var reader = new FileStream(targetFile, FileMode.Open, FileAccess.Read);
            MBVideo mbVideo = JsonSerializer.Deserialize<MBVideo>(reader);
            reader.Close();
            return mbVideo;
        }

        public static void RefreshMBVideoItem(string id)
        {

        }

        public static  void CreateMBVideoItem(MBVideo mbVideo)
        {
            string mbvideos = JsonSerializer.Serialize(mbVideo);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.Write(mbvideos);
            streamWriter.Close();
        }

        public static void UpdateMBVideoItem(MBVideo mbVideo)
        {

        }

        public static void DeleteMBVideo(string id)
        {

        }

        public static void InitMockData()
        {
            var video = new MBVideo();
            video.videoList.Add(new MBVideo { Category = "Mobile", Url = "card1.png", ButtonColorCode = "#D82D2D" });
            video.videoList.Add(new MBVideo { Category = "Mobile", Url = "card2.png", ButtonColorCode = "#D82D2D" });
            video.videoList.Add(new MBVideo { Category = "Mobile", Url = "card3.png", ButtonColorCode = "#D82D2D" });

            File.Delete(targetFile);
            string mbvideos = JsonSerializer.Serialize(video);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.Write(mbvideos);
            streamWriter.Close();
        }
    }
}
