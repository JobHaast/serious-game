using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Text text;

    private void Start()
    {
        int previousAmountOfSubscribers = PlayerPrefs.GetInt("previousAmountOfSubscribers", 0);
        text.text = (previousAmountOfSubscribers.ToString() + " subscribers");
    }

    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelsUnlocked"))
        {
            PlayerPrefs.SetInt("levelsUnlocked", currentLevel + 1);
        }

        Debug.Log("Level " + PlayerPrefs.GetInt("levelsUnlocked") + " unlocked");
        SceneManager.LoadScene("ScoreScene");
    }

    public void FinalPass()
    {
        SceneManager.LoadScene("ScoreScene");
    }

    public void Fail()
    {
        SceneManager.LoadScene("FailScene");
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
            AddGoodRatedArticle();
        }
    }

    public void AddGoodRatedArticle()
    {
        int previousAmountOfGoodRatedArticles = PlayerPrefs.GetInt("totalGoodRatedArticles", 0);
        PlayerPrefs.SetInt("totalGoodRatedArticles", previousAmountOfGoodRatedArticles + 1);
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
