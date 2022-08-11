using AdminDiplomacyAPP.Contract.BoldReport;
using AdminDiplomacyAPP.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Concrete.BoldReport
{
    public class BoldReportManager : IBoldReportManager
    {
        private IWebHostEnvironment _hostingEnvironment;
        private string BaseUrl;
        private readonly IConfiguration _config;
        private readonly HttpClient httpClient;
        public BoldReportManager(IWebHostEnvironment hostingEnvironment, HttpClient httpClient, IConfiguration config)
        {
            _hostingEnvironment = hostingEnvironment;
            this.httpClient = httpClient;
            this._config = config;
            BaseUrl = _config.GetValue<string>("APIURL:BaseUrl");
        }

        public async Task<List<ExpandoObject>> GetJobByID(long id)
        {
            List<ExpandoObject> Result = new List<ExpandoObject>();
            var job = await httpClient.GetJsonAsync<List<object>>(BaseUrl + "voucher/getReportData?id=" + id.ToString());
            foreach (var dt in job)
                Result.Add(JsonConvert.DeserializeObject<ExpandoObject>(dt.ToString()));
            return Result;
        }

        public async Task<FileStreamResult> GetDocument(string ReportName, string ID)
        {
            FileStream inputStream = new FileStream(_hostingEnvironment.WebRootPath + @"\Reports\" + ReportName + ".rdl", FileMode.Open, FileAccess.Read);
            MemoryStream reportStream = new MemoryStream();
            inputStream.CopyTo(reportStream);
            reportStream.Position = 0;
            inputStream.Close();
            BoldReports.Writer.ReportWriter writer = new BoldReports.Writer.ReportWriter(reportStream);
            writer.ReportProcessingMode = BoldReports.Writer.ProcessingMode.Local;
            writer.DataSources.Clear();

            if (ReportName == "Job Report")
            {
                var Job = await GetJobByID(Convert.ToInt64(ID));
                writer.DataSources.Add(new BoldReports.Web.ReportDataSource { Name = "DataSet1", Value = Job.ToList() });
            }

            string fileName = ReportName + ".pdf";
            BoldReports.Writer.WriterFormat format = BoldReports.Writer.WriterFormat.PDF;
            string type = "pdf";

            MemoryStream memoryStream = new MemoryStream();
            writer.Save(memoryStream, format);

            memoryStream.Position = 0;
            FileStreamResult fileStreamResult = new FileStreamResult(memoryStream, "application/" + type);
            fileStreamResult.FileDownloadName = fileName;
            return fileStreamResult;
        }
    }
}
