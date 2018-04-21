using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 

    [System.Serializable]
    public class Weather
    {
        public string date = "";

        public int error;

        public string status = "";

        public List<ResultList> results = new List<ResultList>();
    }
    [System.Serializable]
    public  class ResultList
    {
        public string currentCity = "";
        public string pm25 = "";

        public List<IndexList> index = new List<IndexList>();
        public List<Weather_dataList> weather_data = new List<Weather_dataList>();



    }

    [System.Serializable]

    public class IndexList
    {
        public string title = "";
        public string zs = "";
        public string tipt = "";
        public string des = "";

    }

    [System.Serializable]
    public class Weather_dataList
    {
        public string date = "";
        public string dayPictureUrl = "";
        public string nightPictureUrl = "";
        public string weather = "";
        public string wind = "";
        public string temperature = "";

    }






