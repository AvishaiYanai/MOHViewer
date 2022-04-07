using MOHViewer.Models.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace MOHViewer.Models
{
    public class CityDailyData : Screen
    {
        
        #region privateMembers
        private string  m_CityName;
        private int m_CityCode;
        #endregion

        #region properties
        [JsonProperty("City_Name")]
        public string CityName
        {
            get { return m_CityName; }
            set
            {
                m_CityName = value;
                NotifyOfPropertyChange(() => CityCode);
            }
        }  

        [JsonProperty("Date")]
        public DateTime Date { get; set; }
        [JsonProperty("Cumulative_verified_cases")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int TotalVerified { get; set; }
        [JsonProperty("Cumulated_deaths")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int TotalDeaths { get; set; }
        [JsonProperty("Cumulated_number_of_tests")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int TotalTests { get; set; }

        [JsonProperty("City_Code")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int CityCode
        {
            get { return m_CityCode; }
            set
            {
                m_CityCode = value;
                NotifyOfPropertyChange(() => CityCode);
            }
        }
       
        #endregion
    }
}
