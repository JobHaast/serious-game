using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AI Manager", menuName = "Scriptable Objects/AI manager")]
public class AIManager : ScriptableObject
{
    public ServiceLocator serviceLocator;
    private List<NewsArticle> fakeNewsArticles = new();
    private List<NewsArticle> realNewsArticles = new();

    public void AddNewsArticle(NewsArticle newsArticle, bool isFake)
    {
        if (isFake)
        {
            fakeNewsArticles.Add(newsArticle);
        } else
        {
            realNewsArticles.Add(newsArticle);
        }
    }

    public void ClearArticles()
    {
        fakeNewsArticles.Clear();
        realNewsArticles.Clear();
    }

    public void PersistNewsArticles()
    {
        serviceLocator.GetDatabaseManager().AddNewsArticles(fakeNewsArticles, true);
        serviceLocator.GetDatabaseManager().AddNewsArticles(realNewsArticles, false);
    }
}

