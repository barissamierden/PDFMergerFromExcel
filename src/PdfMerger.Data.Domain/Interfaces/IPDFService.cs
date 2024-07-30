using Microsoft.Office.Interop.Excel;
using PdfMerger.Data.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.Data.Domain.Interfaces
{
    public interface IPDFService
    {
        public Task MergeAsync(string path, SourceType sourceType);
    }
}
