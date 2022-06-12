using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    void OnEnable()
    {
        ArticleSpawner.outOfArticles += Pass;
    }


    void OnDisable()
    {
        ArticleSpawner.outOfArticles -= Pass;
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
}
