
namespace SStorm.CTH.Web.Infrastructure
{
    public interface IFileService
    {
        Task<string> SaveFile(int RequestID, IFormFile file);

        byte[] ReadFile(string fileName);
    }

    public class FileService : IFileService
    {
        public IConfiguration Configuration { get; }
        public string MainFolderPath { get; set; }
        public FileService(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
            MainFolderPath = Configuration.GetSection("FileStoreOptions")["Location"];

        }
        public async Task<string> SaveFile(int RequestID, IFormFile file)
        {
            string SubPath = $"{DateTime.Today: yyyy/MM}/{RequestID}/";
            string FolderPath = $"{MainFolderPath}/{SubPath}";

            try
            {
                string fileName = Path.ChangeExtension($"{Guid.NewGuid():N}", Path.GetExtension(file.FileName));

                if (file.Length > 0)
                {
                    if (!Directory.Exists(FolderPath))
                        Directory.CreateDirectory(FolderPath);
                    string filePath = Path.Combine(FolderPath, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                return Path.Combine(SubPath, fileName);

            }
            catch (Exception ex)
            {
                return string.Empty;

            }
        }

        public byte[] ReadFile(string fileName)
        {
            string fileLocation = Path.Combine(MainFolderPath , fileName);
            if(File.Exists(fileLocation))
                return File.ReadAllBytes(fileLocation);
            return null;

        }
    }

}
