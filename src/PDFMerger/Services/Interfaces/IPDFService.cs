using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFMerger.Services.Interfaces
{
    public interface IPDFService
    {
        public Task Merge(Application excelApp, string excelFilePath);
    }
}