namespace LawyerProject.MyServices.UploadedFileService
{
    public interface IUploadedFileService
    {

        /// <summary>
        /// Upload File to the Server
        /// </summary>
        /// <param name="file">File To Save</param>
        /// <param name="subPathFolder">Name Of Sub Folder of Base Folder To Manage Files</param>
        /// <returns></returns>
        public string UploadFile(IFormFile file,string subPathFolder);
        public bool DeleteUploadedFile(string path);
    }
}
