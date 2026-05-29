using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;
using T2502E_Assignment_Nguyen_anh_tu_NetCore.Helpers;

namespace T2502E_Assignment_Nguyen_anh_tu_NetCore.Services;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary _cloudinary;

    public PhotoService(IOptions<CloudinarySettings> config) {
        var acc = new Account(config.Value.CloudName, config.Value.ApiKey, config.Value.ApiSecret);
        _cloudinary = new Cloudinary(acc);
    }

    public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file) {
        var uploadResult = new ImageUploadResult();
        if (file.Length > 0) {
            using var stream = file.OpenReadStream();
            var uploadParams = new ImageUploadParams {
                File = new FileDescription(file.FileName, stream),
                Transformation = new Transformation().Height(100).Width(100).Crop("fill") // Tự động resize
            };
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }
        return uploadResult;
    }
    
    public async Task<RawUploadResult> AddAudioAsync(IFormFile file)
    {
        var uploadResult = new RawUploadResult();

        if (file.Length > 0)
        {
            using var stream = file.OpenReadStream();
            var uploadParams = new VideoUploadParams 
            {
                File = new FileDescription(file.FileName, stream)
            };
        
            uploadResult = await _cloudinary.UploadAsync(uploadParams);
        }

        return uploadResult;
    }
}