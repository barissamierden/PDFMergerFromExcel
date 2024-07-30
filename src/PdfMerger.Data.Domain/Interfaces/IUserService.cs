using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerger.Data.Domain.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidateUserAsync(string userName, string password);
    }
}
