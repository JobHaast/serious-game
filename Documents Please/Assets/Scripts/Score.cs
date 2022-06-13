using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text previousAmountOfSubscribers;
    public Text lostSubscribers;
    public Text newSubscribers;
    public Text newTotalOfSubscribers;
    public Text totalGoodRatedArticles;

    private void Start()
    {
        SetPreviousAmountSubscribers();
        SetLostSubscribers();
        SetNewSubscribers();
        SetNewTotalSubscribers();
        SetTotalGoodRatedArticles();
    }

    private void SetPreviousAmountSubscribers()
    {
        var subscribers = PlayerPrefs.GetInt("previousAmountOfSubscribers");
        previousAmountOfSubscribers.text = subscribers.ToString();
    }

    private void SetLostSubscribers()
    {
        var subscribers = PlayerPrefs.GetInt("lostSubscribers");
        lostSubscribers.text = subscribers.ToString();
    }

    private void SetNewSubscribers()
    {
        var subscribers = PlayerPrefs.GetInt("newSubscribers");
        newSubscribers.text = subscribers.ToString();
    }

    private void SetNewTotalSubscribers()
    {
        var subscribers = PlayerPrefs.GetInt("newTotalOfSubscribers");
        newTotalOfSubscribers.text = subscribers.ToString();
    }

    private void SetTotalGoodRatedArticles()
    {
        var articles = PlayerPrefs.GetInt("totalGoodRatedArticles");
        totalGoodRatedArticles.text = articles.ToString();
    }
}
