using UnityEngine;

[CreateAssetMenu(fileName = "New Service Locator", menuName = "Scriptable Objects/Service Locator")]
public class ServiceLocator : ScriptableObject
{
    public GameObject audioManagerPrefab;
    public DatabaseManager databaseManager;

    private AudioManager audioManager;

    public AudioManager GetAudioManager()
    {
        if (audioManager == null)
        {
            GameObject audioManagerGameObject = Instantiate(audioManagerPrefab);
            DontDestroyOnLoad(audioManagerGameObject);
            audioManager = audioManagerGameObject.GetComponent<AudioManager>();
        }

        return audioManager;
    }

    public DatabaseManager GetDatabaseManager()
    {
        return databaseManager;
    }
}
