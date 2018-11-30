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
using Newtonsoft.Json.Linq;

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
            catch (Exception ex)
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
                return (await Client.Child($"news").OnceAsync<object>()).Select(x =>
                    {
                        var item = JsonConvert.DeserializeObject<FeedRssItem>(x.Object.ToString());
                        item.Id = x.Key;
                        return item;
                    })/*.Where(x => x.DatePublished >= DateTime.Now)*/.OrderByDescending(x => x.DatePublished).Take(10).ToList();

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
                // TODO: risolto con una cosa molto molto molto brutta
                var data = await Client.Child($"news/{id}").OnceAsync<object>();
                var dir = data.ToDictionary(x => x.Key.FirstCharToUpper(), x => x.Object); //.Select(x => new Dictionary<string, object> { x.Key, x.Object });
                var comm = GetObject<FeedRssItem>(dir);
                return comm;
                //var news = await GetNews();
                //return news.SingleOrDefault(x => x.Id == id);
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
                if (kv.Value.GetType() == typeof(JObject))
                    continue;

                //if (kv.Value.GetType() == typeof(JObject))
                //{
                //    var typee = GetTypee(type, kv.Key);
                //    var objj = Activator.CreateInstance(typee);
                //    var valuee = GetObject(typee, (JObject)kv.Value);
                //    type.GetProperty(typee.Name).SetValue(objj, valuee);
                //    continue;
                //}

                if (type.HasProperty(kv.Key))
                {
                    type.GetProperty(kv.Key).SetValue(obj, kv.Value);
                    continue;
                }

                var propertiyJson = type.GetProperties().SingleOrDefault(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute))
                        .Cast<JsonPropertyAttribute>().Any(f => f.PropertyName == kv.Key.ToLowerInvariant()));

                if (propertiyJson != null)
                    type.GetProperty(propertiyJson.Name).SetValue(obj, kv.Value);

            }
            return (T)obj;
        }

        //private object GetObject(Type type, JObject dict)
        //{
        //    var obj = Activator.CreateInstance(type);

        //    foreach (var kv in dict)
        //    {
        //        //if (kv.Value.GetType() == typeof(JObject))
        //        //var typee = (IReadOnlyCollection<FirebaseObject<object>>)kv.Value
        //        //continue;

        //        if (kv.Value.GetType() == typeof(JObject))
        //        {
        //            var typee = GetTypee(type, kv.Key);
        //            var objj = GetObject(typee, (JObject)kv.Value);
        //            continue;
        //        }

        //        if (type.HasProperty(kv.Key))
        //        {
        //            type.GetProperty(kv.Key).SetValue(obj, kv.Value);
        //            continue;
        //        }

        //        var propertiyJson = type.GetProperties().SingleOrDefault(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute))
        //                .Cast<JsonPropertyAttribute>().Any(f => f.PropertyName == kv.Key.ToLowerInvariant()));

        //        if (propertiyJson != null)
        //            type.GetProperty(propertiyJson.Name).SetValue(obj, kv.Value);

        //    }
        //    return obj;
        //}

        private Type GetTypee(Type typeFather, string propertyName)
        {
            if (typeFather.HasProperty(propertyName))
                return typeFather.GetProperty(propertyName).GetType();


            var propertiyJson = typeFather.GetProperties().SingleOrDefault(p => p.GetCustomAttributes(typeof(JsonPropertyAttribute))
                    .Cast<JsonPropertyAttribute>().Any(f => f.PropertyName == propertyName.ToLowerInvariant()));

            if (propertiyJson != null)
                return typeFather.GetProperty(propertiyJson.Name).GetType();

            return default(Type);
        }
    }
}