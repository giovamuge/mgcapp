using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Mugelli.Software.It.Mgc.Models;
using System.Reflection;
using Newtonsoft.Json;
using System;
using Xamarin.Forms.Internals;
using Mugelli.Software.It.Mgc.Extensions;

namespace Mugelli.Software.It.Mgc.Services
{
    public class FirebaseRestHelper
    {
        private static volatile FirebaseRestHelper _instance;
        private static readonly object SyncRoot = new object();

        private readonly string _databaseUrl = "https://mgc-news.firebaseio.com/";

        private FirebaseRestHelper()
        {
        }

        private FirebaseClient Client { get; set; }

        public static FirebaseRestHelper Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new FirebaseRestHelper();
                }

                return _instance;
            }
        }

        public void Init()
        {
            Client = new FirebaseClient(_databaseUrl);
        }

        /// <summary>
        ///     Ottieni tutte le comunicazioni
        /// </summary>
        /// <returns></returns>
        public async Task<List<Communication>> GetCommunications()
        {
            if (Client == null)
            {
                Init();
            }

            return (await Client.Child("advertising").OnceAsync<object>()).Select(
                x => JsonConvert.DeserializeObject<Communication>(x.Object.ToString()))/*.Where(x => x.Date >= DateTime.Now)*/.OrderByDescending(x => x.Date).ToList();
        }

        /// <summary>
        ///     Ottieni tutti gli appuntamenti del calendario
        /// </summary>
        /// <returns></returns>
        public async Task<List<Appointment>> GetCalendar()
        {
            if (Client == null)
            {
                Init();
            }

            return (await Client.Child("calendar").OnceAsync<object>()).Select(
                x => JsonConvert.DeserializeObject<Appointment>(x.Object.ToString())).Where(x => x.Date >= DateTime.Now).OrderBy(x => x.Date).ToList();
        }

        public async Task<Communication> GetAdvertising(string id)
        {
            try
            {
                if (Client == null)
                {
                    Init();
                }
                var data = await Client.Child($"advertising/{id}").OnceAsync<object>();
                var dir = data.ToDictionary(x => x.Key.FirstCharToUpper(), x => x.Object); //.Select(x => new Dictionary<string, object> { x.Key, x.Object });
                var comm = GetObject<Communication>(dir);
                return comm;

            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<FeedRssItem>> GetNews()
        {
            try
            {
                if (Client == null)
                {
                    Init();
                }
                return (await Client.Child($"news").OnceAsync<object>()).Select(
                    x => JsonConvert.DeserializeObject<FeedRssItem>(x.Object.ToString()))/*.Where(x => x.DatePublished >= DateTime.Now)*/.OrderByDescending(x => x.DatePublished).Take(10).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<FeedRssItem> GetSingleNews(string id)
        {
            try
            {
                if (Client == null)
                {
                    Init();
                }
                var data = await Client.Child($"news/{id}").OnceAsync<object>();
                var dir = data.ToDictionary(x => x.Key.FirstCharToUpper(), x => x.Object); //.Select(x => new Dictionary<string, object> { x.Key, x.Object });
                var comm = GetObject<FeedRssItem>(dir);
                return comm;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private T GetObject<T>(Dictionary<string, object> dict)
        {
            Type type = typeof(T);
            var obj = Activator.CreateInstance(type);

            foreach (var kv in dict)
            {
                if (type.HasProperty(kv.Key))
                    type.GetProperty(kv.Key).SetValue(obj, kv.Value);
            }
            return (T)obj;
        }
    }
}