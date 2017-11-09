using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Xamarin.Database;
using Mugelli.Software.It.Mgc.Models;

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

            var items = await Client.Child("advertising").OnceAsync<object>();
            var result = items;
            return new List<Communication>();
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

            return (await Client.Child("calendar").OnceAsync<Appointment>()).Select(x => x.Object).ToList();
        }
    }
}