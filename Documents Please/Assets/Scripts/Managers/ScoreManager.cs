using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text previousAmountOfSubscribers;
    public Text lostSubscribers;
    public Text newSubscribers;
    public Text newTotalOfSubscribers;
    public Text totalGoodRatedArticles;
    public Text totalAmountOfArticles;
    private int newAmountOfSubscribers;

    private void Start()
    {
        SetPreviousAmountSubscribers();
        SetLostSubscribers();
        SetNewSubscribers();
        SetNewTotalSubscribers();
        SetTotalGoodRatedArticles();
        SetTotalAmountOfArticles();
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
        var subscribers = PlayerPrefs.GetInt("previousAmountOfSubscribers");
        var newSubscribers = PlayerPrefs.GetInt("newSubscribers");
        var lostSubscribers = PlayerPrefs.GetInt("lostSubscribers");
        newAmountOfSubscribers = subscribers + newSubscribers - lostSubscribers;
        newTotalOfSubscribers.text = newAmountOfSubscribers.ToString();
    }

    private void SetTotalGoodRatedArticles()
    {
        var articles = PlayerPrefs.GetInt("totalGoodRatedArticles");
        totalGoodRatedArticles.text = articles.ToString();
    }

    private void SetTotalAmountOfArticles()
    {
        var articles = PlayerPrefs.GetInt("totalAmountOfArticles");
        totalAmountOfArticles.text = articles.ToString();
    }


    public void SetNewValues() 
    {
        PlayerPrefs.SetInt("previousAmountOfSubscribers", newAmountOfSubscribers);
    }
    public void ResetValues() 
    {
        PlayerPrefs.SetInt("lostSubscribers", 0);
        PlayerPrefs.SetInt("newSubscribers", 0);
        PlayerPrefs.SetInt("totalGoodRatedArticles", 0);
        newAmountOfSubscribers = 0;
    }
}
