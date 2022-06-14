using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
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
}
