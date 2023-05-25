using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LawyerProject.MyServices.UploadedFileService
{
    public  class UploadedFileService : IUploadedFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UploadedFileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        protected int MaxSize { get; set; } = 21000000;
        protected List<string> FileExtensions { get; set; } = new List<string>() {"image","pdf" };
        public bool DeleteUploadedFile(string path)
        {
            string pathAfterConcatination = _webHostEnvironment.WebRootPath +'/'+ path;
            Boolean isExist = File.Exists(pathAfterConcatination);
            if (isExist)
            {
                try
                {
                    File.Delete(pathAfterConcatination);
                    return true;
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return false;
                }
            }
            return false;
        }

        public string UploadFile(IFormFile file, string subPathFolder)
        {
            if (FileExtensions.Any(x => file.ContentType.Contains(x)&&file.Length>0&&file.Length<=MaxSize))
            {
                string pathToSaveOnDB = $"uploads/{subPathFolder}/{file.FileName}";
                string path = $"{_webHostEnvironment.WebRootPath}/uploads/{subPathFolder}/";
                if (!Directory.Exists(path)) 
                    Directory.CreateDirectory(path);
                path += file.FileName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return pathToSaveOnDB;
            }else
            {
                return "";
            }
        }
    }
}
