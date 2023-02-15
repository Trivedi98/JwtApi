using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJwtApi.Core.Services.Helper
{
    public interface IFileUpload
    {
        Task<string>UploadCv(IFormFile file);

    }
}
