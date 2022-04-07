using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using MOHViewer.Models;
using Newtonsoft.Json.Linq;
using Caliburn.Micro;

namespace MOHViewer.Services
{
    public class MOHDataFetchService : Screen
    {
        #region privateMembers
        private const string BaseURL = "https://data.gov.il/api/3/action/datastore_search?resource_id=8a21d39d-91e3-40db-aca1-f73f7ab1df69&limit=300000&q=";
        private const string BaseURLGetCitiesList = "https://data.gov.il/api/3/action/datastore_search?resource_id=8a21d39d-91e3-40db-aca1-f73f7ab1df69&limit=500&offset=0&fields=City_Name&distinct=true&sort=City_Name&include_total=false";
        public const string defaultCity = "כל הערים";
        public const string loading ="Loading Data ......";
        public const string finishLoading = "";
        private readonly HttpClient m_client = new();
        private ObservableCollection<CityDailyData> _CitysList;
        private ObservableCollection<CityDailyData> _AllRecordes;
        private ObservableCollection<CityDailyData> _FilteredRecordes;
        private string _Loader;
        #endregion

        #region Properties
        public ObservableCollection<CityDailyData> CityList
        {
            get { return _CitysList; }
            set
            {
                _CitysList = value;
                NotifyOfPropertyChange(() => CityList);
            }
        }

        public ObservableCollection<CityDailyData> AllRecordes
        {
            get { return _AllRecordes; }
            set
            {
                _AllRecordes = value;
                NotifyOfPropertyChange(() => AllRecordes);
            }
        }
        public ObservableCollection<CityDailyData> FilteredRecordes
        {
            get { return _FilteredRecordes; }
            set
            {
                _FilteredRecordes = value;
                NotifyOfPropertyChange(() => FilteredRecordes);
            }
        }
        public string Loader
        {
            get { return _Loader; }
            set
            {
                _Loader = value;
                NotifyOfPropertyChange(() => Loader);
            }
        }
        #endregion

        public MOHDataFetchService()
        {
            AllRecordes = new ObservableCollection<CityDailyData>();
            CityList = new ObservableCollection<CityDailyData>();
            FilteredRecordes = new ObservableCollection<CityDailyData>();
        }


        public async Task<bool>GetCityData(string CityName)
        {
            try
            {
                if (CityName == defaultCity)
                {
                    Loader = loading;
                    CityName = "";
                }
                var response = await m_client.GetAsync(BaseURL + CityName);
                if (!response.IsSuccessStatusCode) throw new Exception();
                string content = await response.Content.ReadAsStringAsync();
                if (Newtonsoft.Json.JsonConvert.DeserializeObject(content) is not JObject responseData) throw new Exception();
                if (responseData["result"] is not JObject result) throw new Exception();
                var filteredRecords = result["records"];
                if (null == filteredRecords) throw new Exception();
                FilteredRecordes = filteredRecords.ToObject<ObservableCollection<CityDailyData>>();
                Loader = finishLoading;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Load Data");
                return false;
            }
        }

       
        public async Task<bool> GetCitysList()
        {
            try
            {
                Loader = loading;
                var response = await m_client.GetAsync(BaseURLGetCitiesList);
                if (!response.IsSuccessStatusCode) throw new Exception();
                string content = await response.Content.ReadAsStringAsync();
                if (Newtonsoft.Json.JsonConvert.DeserializeObject(content) is not JObject responseData) throw new Exception();
                if (responseData["result"] is not JObject result) throw new Exception();
                var allRecords = result["records"];
                if (null == allRecords) throw new Exception();
                CityList = allRecords.ToObject<ObservableCollection<CityDailyData>>();
                CityDailyData city = new CityDailyData();
                city.CityName = defaultCity;
                CityList.Insert(0, city);
                Loader = finishLoading;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed To Load Data");
                return false;
            }
        }

    }
}
