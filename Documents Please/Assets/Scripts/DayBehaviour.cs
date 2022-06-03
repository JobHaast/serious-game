using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayBehaviour : MonoBehaviour
{
    public TextMeshPro day;
    int counter;

    void Start()
    {
        counter = 0;
    }

    void Update()
    {
        counter++;
        day.text = counter.ToString();
    }
}
