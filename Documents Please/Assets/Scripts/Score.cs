using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int previousAmountOfAbonnees;
    private int lostAbonnees;
    private int newAbonnees;
    private int newTotalOfAbonnees;
    private int totalGoodRatedArticles;

    private void Start()
    {
        PlayerPrefs.GetInt("previousAmountOfAbonnees");
        PlayerPrefs.GetInt("lostAbonnees");
        PlayerPrefs.GetInt("newAbonnees");
        PlayerPrefs.GetInt("newTotalOfAbonnees");
        PlayerPrefs.GetInt("totalGoodRatedArticles");
    }
}
