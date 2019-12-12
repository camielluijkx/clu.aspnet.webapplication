using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Reflection;

namespace clu.aspnet.webapplication.mvc.core.Controllers
{
    public class FileController : Controller
    {
        private readonly IFileProvider _fileProvider1;
        private readonly IFileProvider _fileProvider2;
        private readonly IFileProvider _fileProvider3;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _fileProvider1 = hostingEnvironment.ContentRootFileProvider;
            _fileProvider2 = new ManifestEmbeddedFileProvider(Assembly.GetEntryAssembly());
            _fileProvider3 = new CompositeFileProvider(_fileProvider1, _fileProvider2);
        }

        public IActionResult Index1()
        {
            string content = "file not found";

            try
            {
                IFileInfo fileInfo = _fileProvider1.GetFileInfo("appText.txt");

                if (fileInfo.Exists)
                {
                    using (Stream fileStream = fileInfo.CreateReadStream())
                    {
                        StreamReader streamReader = new StreamReader(fileStream);

                        content = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                content = "error reading file";
            }

            return Content(content);
        }

        public IActionResult Index2()
        {
            string content = "file not found";

            try
            {
                IFileInfo fileInfo = _fileProvider2.GetFileInfo("embeddedText.txt");

                if (fileInfo.Exists)
                {
                    using (Stream fileStream = fileInfo.CreateReadStream())
                    {
                        StreamReader streamReader = new StreamReader(fileStream);

                        content = streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                content = "error reading file";
            }

            return Content(content);
        }

        public IActionResult Index3()
        {
            string content = "file not found";

            try
            {
                IFileInfo embeddedfileInfo = _fileProvider3.GetFileInfo("embeddedText.txt");

                if (embeddedfileInfo.Exists)
                {
                    using (Stream fileStream = embeddedfileInfo.CreateReadStream())
                    {
                        StreamReader streamReader = new StreamReader(fileStream);

                        content = streamReader.ReadToEnd();
                    }
                }

                IFileInfo physicalFileInfo = _fileProvider3.GetFileInfo("physicalText.txt");

                if (physicalFileInfo.Exists)
                {
                    using (Stream fileStream = physicalFileInfo.CreateReadStream())
                    {
                        StreamReader streamReader = new StreamReader(fileStream);

                        content += streamReader.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
                content = "error reading file";
            }

            return Content(content);
        }
    }
}