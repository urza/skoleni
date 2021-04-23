using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace WPFCore
{
    class APILoader
    {
        public static async Task<(int Sum, string Url)> LoadAPIResults()
        {
            string url1 = "http://demo.vakutech.cz/api2/values";
            string url2 = "http://demo.vakutech.cz/api/values";

            var t1 = Task<int>.Run(() => LoadAPI(url1));
            var t2 = Task<int>.Run(() => LoadAPI(url2));

            var first = await Task.WhenAny(t1, t2);


            return first.Result;
        }

        public static (int Sum, string Url) LoadAPI(string url)
        {
            HttpClient c = new HttpClient();
            var values = c.GetFromJsonAsync<IEnumerable<int>>(url).Result;
            return (values.Sum(),url);
        }
    }
}
