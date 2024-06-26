﻿

using Microsoft.AspNetCore.Http;

namespace BusinessLogicLayer.Extensions
{
    public static class ImageExtension
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image/");
        }
        public static bool IsOrder1Mb(this IFormFile file)
        {
            return file.Length / 1024 > 1024;
        }
        public static async Task<string> SaveFileAsync(this IFormFile file, string folder)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(folder, filename);
            using (FileStream fileStream = new(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;

        }
    }
}
