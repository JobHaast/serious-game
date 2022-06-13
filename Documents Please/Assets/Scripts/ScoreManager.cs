using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public void AddNewOrLostSubscribers() 
    { 
    
    }
    
    
    public void AddNewSubscribers(int newSubscribers) 
    {
        int oldSubscribers = PlayerPrefs.GetInt("newSubscribers", 0);
        PlayerPrefs.SetInt("newSubscribers", oldSubscribers + newSubscribers);
    }
    public void AddLostSubscribers(int lostSubscribers)
    {
        int oldSubscribers = PlayerPrefs.GetInt("lostSubscribers", 0);
        PlayerPrefs.SetInt("lostSubscribers", oldSubscribers + lostSubscribers);
    }
}
