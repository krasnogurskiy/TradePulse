namespace Trade_Pulse.Helpers
{
    public class FileSaver
    {
        private readonly string _path;

        public FileSaver()
        {
            _path = "";
        }

        public FileSaver(string path)
        {
            _path = path;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            string ext = file.ContentType.Split('/')[1]; 
            string fileName = Guid.NewGuid().ToString() + $".{ext}";
            var savePath = Path.Combine(_path, fileName);
            using Stream stream = new FileStream(savePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }
        public string SaveFile(IFormFile file)
        {
            string ext = file.ContentType.Split('/')[1]; 
            string fileName = Guid.NewGuid().ToString() + $".{ext}";
            var savePath = Path.Combine(_path, fileName);
            using Stream stream = new FileStream(savePath, FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }
    }
}
