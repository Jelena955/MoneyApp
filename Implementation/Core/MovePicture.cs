using Application.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Core
{
    public class MovePicture : IMovePicture
    {
        public string movePicture(IFormFile picture)
        {
            var time = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
            var exstension = Path.GetExtension(picture.FileName);
            var newName = time + exstension;
            var path = Path.Combine("wwwroot", "Images", newName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                picture.CopyTo(stream);
            }
            return newName;
        }
    }
}
