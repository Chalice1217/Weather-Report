using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using LitJson;

public class GetDataFromNetScript : MonoBehaviour {


    public Text m_currentCity;
    public Text m_pm25;
    public Dropdown m_Drop;
    public Transform m_Content;


    string m_Head = "http://api.map.baidu.com/telematics/v3/weather?location=";
    string m_Tail = "&output=json&ak=O6uQVmx12PF0Y2MGwwfo1md3lGHEVut9";



    private void Start()
    {
        List<string> citys = new List<string>() { "北京", "济南", "上海", "六安", "深圳", "广州" };
        m_Drop.ClearOptions();
        m_Drop.AddOptions(citys);

        StartCoroutine(GetDate(m_Head + citys[0] + m_Tail));

        m_Drop.onValueChanged.RemoveAllListeners();
        m_Drop.onValueChanged.AddListener((int i) =>
        {

            StartCoroutine(GetDate(m_Head + citys[i] + m_Tail));
        });

    }


    IEnumerator GetDate(string url)
    {
        WWW www = new WWW(url);
        yield return www;

        if (www.isDone)
        {
            ParseJson(www.text);
        }

    }


    public void ParseJson(string jsonstr)
    {
        Weather rootWeather = JsonMapper.ToObject<Weather>(jsonstr);
        m_currentCity.text = "当前城市 : " + rootWeather.results[0].currentCity;
        m_pm25.text = "pm25 : " + rootWeather.results[0].pm25;
         print(rootWeather.date);

        for (int i = 0; i < rootWeather.results[0].weather_data.Count; i++)
        {
            if (m_Content.transform.childCount < rootWeather.results[0].weather_data.Count)
            {
                OneDayWeatherDataScript m_Prefab = Resources.Load<OneDayWeatherDataScript>("Panel");
                OneDayWeatherDataScript obj = Instantiate(m_Prefab) as OneDayWeatherDataScript;
                obj.OneDayWeather(rootWeather.results[0].weather_data[i]);
                obj.transform.parent = m_Content.transform;
            }
            else
            {
                OneDayWeatherDataScript obj = m_Content.GetChild(i).GetComponent<OneDayWeatherDataScript>();
                obj.OneDayWeather(rootWeather.results[0].weather_data[i]);
            }
        }
    }

    // 2 

    //public Text m_currentCity;
    //public Text m_pm25;
    //public Transform m_Conrtent;
    //public Dropdown m_Drop;

    //const string m_Head = "http://api.map.baidu.com/telematics/v3/weather?location=";
    //const string m_Tail = "&output=json&ak=O6uQVmx12PF0Y2MGwwfo1md3lGHEVut9";

    //private void Start()
    //{
    //    List<string> citys = new List<string>() { "北京", "上海" };
    //    m_Drop.ClearOptions();
    //    m_Drop.AddOptions(citys);

    //    StartCoroutine(GetDate(m_Head + citys[0] + m_Tail));

    //    m_Drop.onValueChanged.RemoveAllListeners();
    //    m_Drop.onValueChanged.AddListener((int i) =>
    //   {
    //       StartCoroutine(GetDate(m_Head + citys[i] + m_Tail));
    //   });


    //} 

    //IEnumerator GetDate(string url)
    //{
    //    WWW w = new WWW(url);
    //    yield return w;
    //    if (w.isDone)
    //    {
    //        ParseJson(w.text);
    //    }


    //}




    //void ParseJson(string jsonstr)
    //{
    //    Weather root = JsonMapper.ToObject<Weather>(jsonstr);
    //    m_currentCity.text = root.results[0].currentCity;
    //    m_pm25.text = root.results[0].pm25;

    //    for (int i = 0; i < root.results[0].weather_data.Count; i++)
    //    {
    //        if (m_Conrtent.transform.childCount < root.results[0].weather_data.Count)
    //        {
    //            OneDayWeatherDataScript m_Prefab = Resources.Load<OneDayWeatherDataScript>("Panel");
    //            OneDayWeatherDataScript obj = Instantiate(m_Prefab) as OneDayWeatherDataScript;
    //            obj.OneDayWeather(root.results[0].weather_data[i]);
    //            obj.transform.parent = m_Conrtent;
    //        }
    //        else
    //        {
    //            OneDayWeatherDataScript obj = m_Conrtent.GetChild(i).GetComponent<OneDayWeatherDataScript>();
    //            obj.OneDayWeather(root.results[0].weather_data[i]);
    //        }

    //    }


    //}


    // 3

    //public Text m_currentCity;
    //public Text m_pm25;
    //public Dropdown m_Drop;
    //public Transform m_Content;

    //const string m_Head = "http://api.map.baidu.com/telematics/v3/weather?location=";
    //const string m_Tail = "&output=json&ak=O6uQVmx12PF0Y2MGwwfo1md3lGHEVut9";

    //private void Start()
    //{
    //    List<string> citys = new List<string>() { "北京", "上海", "济南" };

    //    m_Drop.ClearOptions();
    //    m_Drop.AddOptions(citys);
    //    StartCoroutine(GetData(m_Head + citys[0] + m_Tail));

    //    m_Drop.onValueChanged.RemoveAllListeners();
    //    m_Drop.onValueChanged.AddListener((int i) =>
    //    {
    //        StartCoroutine(GetData(m_Head + citys[i] + m_Tail));
    //    });


    //}


    //IEnumerator GetData(string url)
    //{
    //    WWW www = new WWW(url);
    //    yield return www;
    //    if (www.isDone)
    //    {
    //        ParseJson(www.text);
    //    }
    //}

    //void ParseJson(string jsonstr)
    //{
    //    Weather root = JsonMapper.ToObject<Weather>(jsonstr);
    //    m_currentCity.text = root.results[0].currentCity;
    //    m_pm25.text = root.results[0].pm25;

    //    for (int i = 0; i < root.results[0].weather_data.Count; i++)
    //    {
    //        if (m_Content.transform.childCount < root.results[0].weather_data.Count)
    //        {
    //            OneDayWeatherDataScript m_Prefab = Resources.Load<OneDayWeatherDataScript>("Panel");
    //            OneDayWeatherDataScript obj = Instantiate(m_Prefab) ;
    //            obj.OneDayWeather(root.results[0].weather_data[i]);
    //            obj.transform.parent = m_Content.transform;

    //        }else
    //        {
    //            OneDayWeatherDataScript obj = m_Content.transform.GetChild(i).GetComponent<OneDayWeatherDataScript>();
    //            obj.OneDayWeather(root.results[0].weather_data[i]);
    //        }



    //    }


    //}


}
