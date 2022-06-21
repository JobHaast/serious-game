using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text textDisplay;
    public int secondsLeft = 30;
    public bool tickingAway = true;

    [SerializeField] private UnityEvent outOfTime;


    private void Start()
    {
        textDisplay.text = secondsLeft.ToString();
    }

    private void Update()
    {
        if (tickingAway && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
        if(secondsLeft == 0)
        {
            outOfTime?.Invoke();
        }
    }

    IEnumerator TimerTake()
    {
        tickingAway = false;
        yield return new WaitForSeconds(1);
        secondsLeft--;
        textDisplay.text = secondsLeft.ToString();
        tickingAway = true;
    }

    public void SetTickingAway(bool tickingAway)
    {
        this.tickingAway = tickingAway;
    }
}
