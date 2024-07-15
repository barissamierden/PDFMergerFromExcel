using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFMerger.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> ValidateUser(string userName, string password);
    }
}
