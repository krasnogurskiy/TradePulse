using System.ComponentModel.DataAnnotations;
using Trade_Pulse.Helpers;

namespace Trade_Pulse.Attributes
{
    public class FileList : ValidationAttribute
    {
        private readonly int _length;
        private readonly string[] _allowedExtension;
        private long _totalSize;

        public FileList(long totalSize, string[] allowedExtension, int length)
        {
            _totalSize = totalSize;
            _allowedExtension = allowedExtension;
            _length = length;
        }

        public FileList()
        {
            _totalSize = 0;
            _allowedExtension = new string[] { };
            _length = 0;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || value is not IEnumerable<IFormFile>) return null!;
            var files = (value as IEnumerable<IFormFile>)!.ToArray();
            if (files.Length > _length) return new ValidationResult($"Забагато файлів, {_length} дозволено");
            long totalSize = 0;
            foreach ( var file in files )
            {
                if(file.Length + totalSize > _totalSize ) return new ValidationResult($"Розмір файлів завеликий ({_totalSize / 1024} МБ дозволено)");
                else if(!FileValidator.IsFileExtensionAllowed(file, _allowedExtension)) return new ValidationResult($"Невалідне розширення файлу ({string.Join(" , ", _allowedExtension)} дозволені)");
                totalSize += file.Length;
            }
            return ValidationResult.Success!;
        }
    }
}
