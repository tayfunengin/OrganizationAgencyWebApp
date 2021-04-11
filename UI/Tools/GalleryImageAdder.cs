using Microsoft.AspNetCore.Http;
using Repository;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Tools
{
    public class GalleryImageAdder
    {
        private readonly IRepository<Model> _modelRepository;

        public GalleryImageAdder(IRepository<Model> modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public bool UploadImage(PhotoGraphy photo,IFormFile formFile, int id, string webRoot)
        {

            Model model = _modelRepository.GetById(id);
            var fileName = "";
            string serverPath = "~/images/modelImage/";


            var uniqueName = Guid.NewGuid();
            serverPath = serverPath.Replace("~", "");
            var fileArray = formFile.FileName.Split('.');
            string extension = '.' + fileArray[fileArray.Length - 1].ToLower();
            fileName = uniqueName + extension;

            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif")
            {
                if (File.Exists(webRoot + serverPath + fileName))
                {
                    return false;
                }
                else
                {
                    try
                    {
                        var filePath = Path.GetDirectoryName(webRoot + serverPath + fileName);
                        var stream = new FileStream(Path.Combine(filePath, fileName), FileMode.Create);
                        formFile.CopyTo(stream);

                        PhotoGraphy photoGraphy = new PhotoGraphy();
                        photoGraphy.Title = photo.Title;
                        photoGraphy.Path = fileName;
                        model.PhotoGraphies.Add(photoGraphy);
                        _modelRepository.SaveChanges();
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
