using Microsoft.Office.Interop.Excel;
using PDFMerger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFMerger.Services.Interfaces
{
    public interface IPDFService
    {
        public Task Merge(Application? excelApp, string path, SourceType sourceType);
    }
}