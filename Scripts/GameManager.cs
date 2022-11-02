using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject loadingScreen;
    public float loadingDelay = 5.0f;
    private string loadingScene;
    void Awake()
    {
        loadingScreen.gameObject.SetActive(false);
        FindObjectOfType<ChangeWeather>().SetDefaultWeather();
    }
    void Update()
    {
    }
    public void SetHand(string hand)
    {
        PlayerPrefs.SetString("Hand", hand);
    }
    // public void SetLocomotion(string type)
    // {
    //     PlayerPrefs.SetString("Movement", type);
    // }
        //----- CHANGE SCENE -----
    public void ChangeScene(string name)
    {
        loadingScene = name;
        loadingScreen.gameObject.SetActive(true);
        Invoke("LoadNewScene", loadingDelay);
    }
    void LoadNewScene()
    {
        StartCoroutine(LoadAsyncronusly());
    }
    IEnumerator LoadAsyncronusly()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadingScene);

        while (operation.isDone)
        {
            yield return null;
        }
    }
        //----- CHANGE SCENE -----
    public void Quit()
    {
        Application.Quit();
    }    
}
