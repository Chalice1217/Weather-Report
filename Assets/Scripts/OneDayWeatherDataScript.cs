using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OneDayWeatherDataScript : MonoBehaviour {


    public Text m_date;
    public RawImage m_dayPictureUrl;
    public Text m_weather;
    public Text m_wind;
    public Text m_temperature;

    public void OneDayWeather(Weather_dataList oneday)
    {
        m_date.text = oneday.date;
        m_weather.text = oneday.weather;
        m_wind.text = oneday.wind;
        m_temperature.text = oneday.temperature;

        StartCoroutine(LoadTexture(oneday.dayPictureUrl));
    }

    IEnumerator LoadTexture(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        if (www.isDone)
        {
            m_dayPictureUrl.texture = www.texture;
        }

    }




}
