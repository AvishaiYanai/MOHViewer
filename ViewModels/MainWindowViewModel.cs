using MOHViewer.Models;
using MOHViewer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;



namespace MOHViewer.ViewModels
{
   public class MainWindowViewModel:Screen
    {
        #region PrivateMembers
        private string m_Title;
        private CityDailyData _SelectedCity;
        private string _Loader;
        #endregion

        #region Properties

        public MOHDataFetchService MOHDataFetchService { get;  }
       
        public string Title
        {
            get { return m_Title; }
            set
            {
                m_Title = value;
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

        public CityDailyData SelectedCity
        {
            get { return _SelectedCity; }
            set
            {
                _SelectedCity = value;
                GetCityData();
            }

        }
        #endregion

        public MainWindowViewModel()
        {
            MOHDataFetchService = new MOHDataFetchService();
            Title = "Ministry Of Health Covid Data";
            GetCitysList();

        }

        public void GetCitysList()
        {
                MOHDataFetchService.GetCitysList();
        }
        private void GetCityData()
        {
                MOHDataFetchService.GetCityData(SelectedCity.CityName);
        }

    }
}
