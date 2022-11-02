using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeather : MonoBehaviour
{
    //Effects
    public GameObject mainLight;
    public GameObject rainEffect;
    [Space]
    //Skyboxes
    public Material clearSky;
    public Material cloudySky;
    public Material coldSky;
    public Material staryNightSky;
    public Material stormySky;
    [Space]
    //Colors
    public Color dustyGrey;
    public Color coolBlue;
    public Color hotYellow;
    public Color white;
    public Color black;
    void Start()
    {
    }
    void Update()
    {
    }
    public void SetDefaultWeather() {
        string currentWeather = PlayerPrefs.GetString("Current Weather", "HotClearSky");
        Invoke(currentWeather, 0.0f);
    }
    public void HotClearSky()
    {
        RenderSettings.skybox = clearSky;
        mainLight.SetActive(true);
        mainLight.GetComponent<Light>().color = hotYellow;
        mainLight.GetComponent<Light>().intensity = 1f;
        RenderSettings.fog = true;
        RenderSettings.fogColor = dustyGrey;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.01f;
        rainEffect.SetActive(false);
        FindObjectOfType<AudioManager>().StopSound("Rain");
        PlayerPrefs.SetString("Current Weather", "HotClearSky");
        Debug.Log(PlayerPrefs.GetString("Current Weather"));
    }
    public void Sunset()
    {
        RenderSettings.skybox = clearSky;
        mainLight.SetActive(false);
        RenderSettings.fog = true;
        RenderSettings.fogColor = dustyGrey;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.008f;
        rainEffect.SetActive(false);
        FindObjectOfType<AudioManager>().StopSound("Rain");
        PlayerPrefs.SetString("Current Weather", "Sunset");
        Debug.Log(PlayerPrefs.GetString("Current Weather"));
    }
    public void CloudySky()
    {
        RenderSettings.skybox = cloudySky;
        mainLight.SetActive(true);
        mainLight.GetComponent<Light>().color = white;
        mainLight.GetComponent<Light>().intensity = 0.4f;
        RenderSettings.fog = true;
        RenderSettings.fogColor = dustyGrey;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.001f;
        rainEffect.SetActive(false);
        FindObjectOfType<AudioManager>().StopSound("Rain");
        PlayerPrefs.SetString("Current Weather", "CoudySky");
        Debug.Log(PlayerPrefs.GetString("Current Weather"));
    }
    public void StaryNightSky()
    {
        RenderSettings.skybox = staryNightSky;
        mainLight.SetActive(false);
        RenderSettings.fog = true;
        RenderSettings.fogColor = black;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.0008f;
        rainEffect.SetActive(false);
        FindObjectOfType<AudioManager>().StopSound("Rain");
        PlayerPrefs.SetString("Current Weather", "StaryNightSky");
        Debug.Log(PlayerPrefs.GetString("Current Weather"));
    }
    public void RainDay()
    {
        RenderSettings.skybox = stormySky;
        mainLight.SetActive(true);
        mainLight.GetComponent<Light>().color = dustyGrey;
        mainLight.GetComponent<Light>().intensity = .25f;
        RenderSettings.fog = true;
        RenderSettings.fogColor = dustyGrey;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.002f;
        rainEffect.SetActive(true);
        FindObjectOfType<AudioManager>().PlaySound("Rain");
        PlayerPrefs.SetString("Current Weather", "RainDay");
        Debug.Log(PlayerPrefs.GetString("Current Weather"));
    }
    public void ColdDay()
    {
        RenderSettings.skybox = coldSky;
        mainLight.SetActive(true);
        mainLight.GetComponent<Light>().color = coolBlue;
        mainLight.GetComponent<Light>().intensity = 1f;
        RenderSettings.fog = true;
        RenderSettings.fogColor = white;
        RenderSettings.fogMode = FogMode.ExponentialSquared;
        RenderSettings.fogDensity = 0.025f;
        rainEffect.SetActive(false);
        FindObjectOfType<AudioManager>().StopSound("Rain");
        PlayerPrefs.SetString("Current Weather", "ColdDay");
        Debug.Log(PlayerPrefs.GetString("Current Weather"));
    }
}
