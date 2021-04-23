using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WPFCore
{
    public class WebLoader
    {
        public static string[] urls = {
            "https://seznam.cz",
            "https://seznamzpravy.cz",
            "https://idnes.cz",
            "https://lidovky.cz",
            "https://novinky.cz",
            "https://bbc.co.uk",
            "https://cnn.com",
            "https://microsoft.com",
            "https://www.mzcr.cz/",
            "https://www.google.com/"
        };

        public static IEnumerable<SearchResult> SearchUrls(string searchterm)
        {
            Stopwatch s = new Stopwatch();

            List<Task<SearchResult>> tasks = new List<Task<SearchResult>>();

            foreach(var url in urls)
            {
                tasks.Add(Task<SearchResult>.Run(() => SearchWeb(url, searchterm)));
            }

            List<SearchResult> results = new List<SearchResult>();

            foreach(var t in tasks)
            {
                results.Add(t.Result);
            }

            //Task.WaitAll(tasks.ToArray());

            s.Stop();
            var elapsed = s.ElapsedMilliseconds;

            return results;
        }

        public static IEnumerable<SearchResult> SearchUrlsWithProgress(string searchterm, IProgress<SearchResult> progress)
        {
            Stopwatch s = new Stopwatch();

            List<Task<SearchResult>> tasks = new List<Task<SearchResult>>();

            foreach (var url in urls)
            {
                tasks.Add(Task<SearchResult>.Run(() => SearchWebWithProgress(url, searchterm, progress)));
            }

            List<SearchResult> results = new List<SearchResult>();

            foreach (var t in tasks)
            {
                results.Add(t.Result);
                //progress.Report(t.Result);
            }

            //Task.WaitAll(tasks.ToArray());

            s.Stop();
            var elapsed = s.ElapsedMilliseconds;

            return results;
        }

        public static IEnumerable<SearchResult> SearchUrlsSeq(string searchterm)
        {
            Stopwatch s = new Stopwatch();

            List<SearchResult> results = new List<SearchResult>();

            foreach (var url in urls)
            {
                results.Add(SearchWeb(url, searchterm));
            }

            s.Stop();
            var elapsed = s.ElapsedMilliseconds;
            return results;
        }

        public static SearchResult SearchWeb(string url, string searchterm)
        {
            Random r = new Random();
            Task.Delay(500 + r.Next(10_000)).Wait();

            SearchResult sr = new SearchResult();
            sr.Url = url;

            HttpClient c = new HttpClient();
            try
            {
                var webcontent = c.GetStringAsync(url).Result;
                sr.Contains = webcontent.Contains(searchterm,StringComparison.OrdinalIgnoreCase);
            }
            catch(Exception ex)
            {
                sr.Error = ex.Message;
            }

            return sr;
        }

        public static SearchResult SearchWebWithProgress(string url, string searchterm, IProgress<SearchResult> progress)
        {
            Stopwatch s = new Stopwatch();
            s.Start();

            Random r = new Random();
            Task.Delay(500 + r.Next(10_000)).Wait();


            SearchResult sr = new SearchResult();
            sr.Url = url;

            HttpClient c = new HttpClient();
            try
            {
                var webcontent = c.GetStringAsync(url).Result;
                sr.Contains = webcontent.Contains(searchterm, StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                sr.Error = ex.Message;
            }
            finally
            {
                s.Stop();
                sr.ElapsedMs = s.ElapsedMilliseconds.ToString();

            }
            
            progress.Report(sr);
            return sr;
        }
    }



    public class SearchResult
    {
        public string Url { get; set; }

        public bool Contains { get; set; }

        public string Error { get; set; }

        public string ElapsedMs { get; set; }
    }

    public class WebSearchViewModel
    {
        public ObservableCollection<SearchResult> WebSearchResults { get; set; } = new ObservableCollection<SearchResult>();
    }
}
