using AdminDiplomacyAPP.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDiplomacyAPP.Contract.BoldReport
{
    public interface IBoldReportManager
    {
        public Task<List<ExpandoObject>> GetJobByID(long id);
        public Task<FileStreamResult> GetDocument(string ReportName, string ID);
    }
}
