using UnityEngine;

public class MuteButton : MonoBehaviour
{
    public ServiceLocator serviceLocator;

    public void ToggleAudio(bool toggle)
    {
        serviceLocator.GetAudioManager().ToggleSound(toggle);
    }
}
