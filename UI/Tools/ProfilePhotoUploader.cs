using Domain.Enums;
using Microsoft.AspNetCore.Http;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Tools
{
    public class ProfilePhotoUploader
    {
        public static bool UploadImage(Model model, IFormFile formFile, string webRoot)
        {

            var fileName = "";
            string serverPath = "~/images/modelImage/";

            
                var uniqueName = Guid.NewGuid();
                serverPath = serverPath.Replace("~", "");
                var fileArray = formFile.FileName.Split('.');
                string extension = '.' + fileArray[fileArray.Length - 1].ToLower();
                fileName = uniqueName + extension;

                if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif")
                {
                    if (File.Exists(webRoot+serverPath + fileName))
                    {                    
                        return false;
                    }
                    else
                    {
                        try
                        {
                            var filePath = Path.GetDirectoryName(webRoot+serverPath + fileName);
                            var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                            formFile.CopyTo(stream);
                            model.ProfilePhotoPath = fileName;
                            return true;
                        }
                        catch (Exception)
                        {                        
                            return false;
                        }
                    }
                }
                else
                {                    
                    return false;
                }

        }
    }
}
