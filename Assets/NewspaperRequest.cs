using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;


public class NewspaperRequest : MonoBehaviour
{
    public string url = "https://newsapi.org/v2/everything?q=tesla&from=2022-02-09&sortBy=publishedAt&apiKey=6e490f023c1c48febf81c1f335f95444";
    public NewsResponse response;
    public Text harsh;

    public void GetNewpaper()
    {
        StartCoroutine(MakeNewspaperRequest());
    }

    

IEnumerator MakeNewspaperRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        //Debug.Log(request.SendWebRequest());
        yield return request.SendWebRequest();


        if(request.error != null)
        {
            Debug.Log(request.error);
        }
        else
        {
            response = JsonUtility.FromJson<NewsResponse>(request.downloadHandler.text);
            Debug.Log(request.downloadHandler.text);
            harsh.text = response.articles[0].title;
            //for(int i = 0; i<= 10; i++)
            //{
              //   Debug.Log(response.articles[i].title);
            //}
        }
        
    }




}
[System.Serializable]
public class Source
{
    public string id;
    public string name;
}
[System.Serializable]
public class Article
{
    public Source source;
    public string author;
    public string title;
    public string description;
    public string url;
    public string urlToImage;
    public DateTime publishedAt;
    public string content;
}
[System.Serializable]
public class NewsResponse
{
    public string status;
    public int totalResults;
    public List<Article> articles;
    public object Article;
}
