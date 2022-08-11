using AdminDiplomacyAPP.Contract.BoldReport;
using BoldReports.Web.ReportViewer;
using BoldReports.Writer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Controller
{
    [Route("api/{controller}/{action}/{id?}")]
    public class ReportViewerController : ControllerBase, IReportController
    {
        private IMemoryCache _cache;
        private IWebHostEnvironment _hostingEnvironment;
        public static Dictionary<string, Object> jsonResult = null;
        public static IBoldReportManager _repository;

        public ReportViewerController(IMemoryCache memoryCache, IWebHostEnvironment hostingEnvironment, IBoldReportManager repository)
        {
            _cache = memoryCache;
            _hostingEnvironment = hostingEnvironment;
            _repository = repository;
        }
        [ActionName("GetResource")]
        [AcceptVerbs("GET")]
        public object GetResource(ReportResource resource)
        {
            return ReportHelper.GetResource(resource, this, _cache);
        }
        public void OnInitReportOptions(ReportViewerOptions reportOption)
        {
            string ID = null;
            string basePath = _hostingEnvironment.WebRootPath;
            reportOption.ReportModel.ProcessingMode = BoldReports.Web.ReportViewer.ProcessingMode.Local;
            if (reportOption.ReportModel.ReportPath == "Job Report")
            {
                foreach (var i in jsonResult)
                {
                    if (i.Key == "parameters")
                    {
                        ID = i.Value.ToString().Split(",")[1].Split(":")[1].Split("\"")[1];
                    }
                }
                FileStream inputStream = new FileStream(basePath + @"\Reports\" + reportOption.ReportModel.ReportPath + ".rdl", FileMode.Open, FileAccess.Read);
                MemoryStream reportStream = new MemoryStream();
                inputStream.CopyTo(reportStream);
                reportStream.Position = 0;
                inputStream.Close();
                reportOption.ReportModel.Stream = reportStream;
                reportOption.ReportModel.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetJobByID(Convert.ToInt64(ID)).Result.ToList() });
                reportOption.ReportModel.ExportSettings = new BoldReports.Writer.ExportSettings() { FileName = "Job Report" };
            }
        }

        [HttpGet]
        public IActionResult Export(string Parameter)
        {
            string ReportName = Parameter.Split(",")[0].Split(":")[1].Split("\"")[1];
            string basePath = _hostingEnvironment.WebRootPath;

            FileStream inputStream = new FileStream(basePath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);

            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "Job Report")
            {
                string ID = Parameter.Split(",")[1].Split(":")[1].Split("\"")[1];
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = _repository.GetJobByID(Convert.ToInt64(ID)).Result.ToList() });
            }

            string fileName = ReportName + ".pdf";
            MemoryStream memoryStream = new MemoryStream();
            WriterFormat format = WriterFormat.PDF;
            writer.Save(memoryStream, format);

            memoryStream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, "application/" + "pdf");
            fileStreamResult.FileDownloadName = fileName;
            return fileStreamResult;
        }
        public void OnReportLoaded(ReportViewerOptions reportOption)
        {

        }

        [HttpPost]
        public object PostFormReportAction()
        {
            return ReportHelper.ProcessReport(null, this, _cache);
        }

        [HttpPost]
        public object PostReportAction([FromBody] Dictionary<string, object> jsonArray)
        {
            jsonResult = jsonArray;
            return ReportHelper.ProcessReport(jsonArray, this, this._cache);
        }
    }
}
