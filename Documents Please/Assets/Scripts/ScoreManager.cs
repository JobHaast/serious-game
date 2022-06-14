using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text text;
    private void Start()
    {
        int previousAmountOfSubscribers = PlayerPrefs.GetInt("previousAmountOfSubscribers", 0);
        text.text = (previousAmountOfSubscribers.ToString() + " subscribers");
    }

    public void AddNewOrLostSubscribers(NewsArticle newsArticle, bool approved) 
    {
        if ((newsArticle.isFakeNews && approved) || (!newsArticle.isFakeNews && !approved))
        {
            AddLostSubscribers(newsArticle.amountOfSubscribers);
        }
        else 
        {
            AddNewSubscribers(newsArticle.amountOfSubscribers);
        }
    }
    
    
    public void AddNewSubscribers(int newSubscribers) 
    {
        Debug.Log("New subscribers: " + newSubscribers);
        int oldSubscribers = PlayerPrefs.GetInt("newSubscribers", 0);
        PlayerPrefs.SetInt("newSubscribers", oldSubscribers + newSubscribers);
    }
    public void AddLostSubscribers(int lostSubscribers)
    {
        Debug.Log("Lost subscribers: " + lostSubscribers);
        int oldSubscribers = PlayerPrefs.GetInt("lostSubscribers", 0);
        PlayerPrefs.SetInt("lostSubscribers", oldSubscribers + lostSubscribers);
    }
}
