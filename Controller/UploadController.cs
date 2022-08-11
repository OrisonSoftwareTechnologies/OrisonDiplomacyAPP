using AdminDiplomacyAPP.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnv;
        private GeneralServices _genServ;
        //public string path;
        public UploadController(IWebHostEnvironment hostingEnv, GeneralServices genServ)
        {
            _hostingEnv = hostingEnv;
            _genServ = genServ;

        }
        [HttpPost("[action]")]
        public async void Save(IList<IFormFile> UploadFiles)
        {

            long size = 0;
            string path = "";

            path = _genServ.MiscImagePath().Result;
            // path = $@"D:\Orison\OrisonPortal\OrisonSPMS\OrisonSparePartsImages\";

            try
            {

                foreach (var file in UploadFiles)
                {

                    var filename = ContentDispositionHeaderValue
                            .Parse(file.ContentDisposition)
                            .FileName
                            .Trim('"');
                    filename = Path.Combine(path, filename);
                    filename = $@"{filename}";

                    size += (int)file.Length;


                    string t = file.ContentType;

                    if (filename.Contains(".jpg"))
                    { }

                    else if (filename.Contains(".png"))
                    { }
                    else if (filename.Contains(".PNG"))
                    { }

                    else if (filename.Contains(".jpeg"))
                    { }
                    else if (filename.Contains(".JPEG"))
                    { }
                    else
                    {
                        int pos = t.IndexOf("/");
                        if (pos >= 0)
                        {

                            // Remove everything before founder but include founder  
                            t = t.Remove(0, pos + 1);
                            t = "." + t;

                        }

                        //string t = file.ContentType;
                        bool d = filename.Contains(t);
                        if (d == false)
                        {
                            filename = filename + t;

                        }
                    }
                    if (!System.IO.File.Exists(filename))
                    {
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }

                    }
                    else
                    {
                        System.IO.File.Delete(filename);
                        using (FileStream fs = System.IO.File.Create(filename))
                        {
                            file.CopyTo(fs);
                            fs.Flush();
                        }


                    }

                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 204;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File failed to upload";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
        [HttpPost("[action]")]
        public async void Remove(IList<IFormFile> UploadFiles)
        {
            try
            {
                string path = "";
                //  path = $@"D:\Orison\OrisonPortal\OrisonSPMS\OrisonSparePartsImages\";
                path = _genServ.MiscImagePath().Result;
                var filename = Path.Combine(path, UploadFiles[0].FileName);
                filename = $@"{filename}";
                string t = UploadFiles[0].ContentType;
                int pos = t.IndexOf("/");
                if (pos >= 0)
                {
                    t = t.Remove(0, pos + 1);
                    t = "." + t;
                }
                filename = filename + t;
                //var filename = $@"C:\Orison\OrisonResources\HRDocuments\{UploadFiles[0].FileName}";
                if (System.IO.File.Exists(filename))
                {
                    System.IO.File.Delete(filename);
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.StatusCode = 200;
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "File removed successfully";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
    }
}
