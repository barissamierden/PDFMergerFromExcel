using PDFMerger.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFMerger.Services.Concretes
{
    public class UserService : IUserService
    {
        public async Task<bool> ValidateUser(string userName, string password)
        {

            using var client = new HttpClient();
            var values = new Dictionary<string, string> { { "userName", userName }, { "password", password } };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("https://licensecontrol.erdenteknoloji.com/licensecontrol/PDFMerger", content);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
    }
}
