using Android.Database.Sqlite;
using Kotlin.Reflect;
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
    public static class CommonServiceMock
    {
        public static Object readData<T>(string targetFile)
        {
            using var reader = new FileStream(targetFile, FileMode.Open, FileAccess.Read);
            Object mbObj = JsonSerializer.Deserialize<T>(reader);
            reader.Close();
            return mbObj;
        }

        public static void writeData(string targetFile, Object obj)
        {
            string mb = JsonSerializer.Serialize(obj);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.Write(mb);
            streamWriter.Close();
        }


    }
}
