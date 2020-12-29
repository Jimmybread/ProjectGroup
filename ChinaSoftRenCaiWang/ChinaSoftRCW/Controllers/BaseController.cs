using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChinaSoftRCW.Models;
using ChinaSoftRCW.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ChinaSoftRCW.Controllers
{
    public class BaseController : Controller
    {
        internal readonly IHostEnvironment _hostEnvironment;
        internal readonly IDataRepository _dataRepository;
        internal readonly IEnumerable<DimValue> dimValues;

        public BaseController(IDataRepository dataRepository,
            IHostEnvironment hostEnvironment)
        {
            _dataRepository = dataRepository;
            _hostEnvironment = hostEnvironment;

            if (dimValues is null)
            {
                dimValues = _dataRepository.GetDimValues();
            }
        }

        internal string UploadFile(IFormFile file, string fullName)
        {
            var exts = new List<string> { ".doc", ".docx", ".pdf", ".txt" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (exts.Contains(ext))
            {
                var resumePath = _hostEnvironment.ContentRootPath;
                resumePath = Path.Combine(resumePath, "wwwroot", "Resume");
                var fileName = $"{fullName}_{DateTimeOffset.Now.ToString("yyyy_MM_dd_hh_mm_ss")}_{file.FileName}";
                resumePath = Path.Combine(resumePath, fileName);
                resumePath = resumePath.Replace(' ', '_');
                using (var fileStream = new FileStream(resumePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                return resumePath;
            }

            return string.Empty;
        }
    }
}