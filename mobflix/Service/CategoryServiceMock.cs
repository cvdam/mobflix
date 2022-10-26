using mobflix.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mobflix.Service
{
    public static class CategoryServiceMock
    {
        static string targetFile = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "categories");

        public static MBCategory RefreshMBCategories()
        {
            using var reader = new FileStream(targetFile, FileMode.Open, FileAccess.Read);
            MBCategory mbCategory = JsonSerializer.Deserialize<MBCategory>(reader);
            reader.Close();
            return mbCategory;
        }

        public static void RefreshMBCategoryItem(string id)
        {

        }

        public static void CreateMBCategoryItem(MBCategory mbCategory)
        {
            string mbcategories = JsonSerializer.Serialize(mbCategory);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.Write(mbcategories);
            streamWriter.Close();
        }

        public static void UpdateMBCategoryItem(MBCategory mbCategory)
        {

        }

        public static void DeleteMBCategory(string id)
        {

        }

        public static void InitMockData()
        {
            var category = new MBCategory();
            category.categoryList.Add(new MBCategory { Name = "Front end", ButtonColorCode = "#5781EF" });
            category.categoryList.Add(new MBCategory { Name = "Programação", ButtonColorCode = "#19940F" });
            category.categoryList.Add(new MBCategory { Name = "Mobile", ButtonColorCode = "#D82D2D" });

            File.Delete(targetFile);
            string mbcategories = JsonSerializer.Serialize(category);
            using FileStream outputStream = System.IO.File.OpenWrite(targetFile);
            using StreamWriter streamWriter = new StreamWriter(outputStream);
            streamWriter.Write(mbcategories);
            streamWriter.Close();
        }
    }
}

