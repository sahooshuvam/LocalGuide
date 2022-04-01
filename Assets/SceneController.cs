using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static string keyword;
    private void Start()
    {
       // StartCoroutine(GetRequest("https://bit.ly/3wScWio"));
    }
    public void Quit()
    {
        Application.Quit(); 
    }

    public void GoNextScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void KeywordForGoogle(string keywordName)
    {
        keyword = keywordName;
        print(keyword);
        //string url = "https://tools.learningcontainer.com/sample-json-file.json";
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        string uri = "https://bit.ly/3wScWio";
        print("In Coroutine Function");
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    print("here 3");
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    print("Here");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    print("here 1");
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    print("Here 2");
                    break;
            }
        }
    }

}
