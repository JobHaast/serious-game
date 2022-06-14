using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArticleSpawner : MonoBehaviour
{
    public NewsArticleDisplay articlePrefab;
    public List<NewsArticle> newsArticles;
    private GameObject currentArticle;

    [SerializeField] private UnityEvent outOfArticles;


    public void SpawnArticle() 
    {
        if (newsArticles.Count > 0)
        {
            int randomIndex = Random.Range(0, newsArticles.Count - 1);
            articlePrefab.newsArticle = newsArticles[randomIndex];
            currentArticle = Instantiate(articlePrefab.gameObject, transform.position, Quaternion.identity);
            newsArticles.RemoveAt(randomIndex);
        } else
        {
            outOfArticles?.Invoke();
        }      
    }

    public void Display(NewsArticle newsArticle)
    {
        Debug.Log(newsArticle);
    }
}
