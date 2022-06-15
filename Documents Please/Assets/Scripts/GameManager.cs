using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("previousAmountOfSubscribers", 0) == 0) PlayerPrefs.SetInt("previousAmountOfSubscribers", 10000);
    }
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game");
        Application.Quit();
    }

    public void ToggleSound(bool toggle)
    {
        toggle = !toggle;

        if (toggle)
            AudioListener.volume = 0.6f;

        else
            AudioListener.volume = 0f;
    }
}
