using System.ComponentModel.DataAnnotations;
using Trade_Pulse.Helpers;


namespace Trade_Pulse.Attributes;
public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedExtensionsAttribute(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null && !FileValidator.IsFileExtensionAllowed(file, _extensions)) return new ValidationResult(this.ErrorMessage);
        return ValidationResult.Success!;
    }
}