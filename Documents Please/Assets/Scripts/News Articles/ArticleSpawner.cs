using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArticleSpawner : MonoBehaviour
{
    public NewsArticleDisplay articlePrefab;
    public List<NewsArticle> newsArticles;

    [SerializeField] private UnityEvent outOfArticles;
    [SerializeField] private ArticleSpawned onArticleSpawned;

    private void Start()
    {
        PlayerPrefs.SetInt("totalAmountOfArticles", newsArticles.Count);
    }

    public void SpawnArticle() 
    {
        if (newsArticles.Count > 0)
        {
            int randomIndex = Random.Range(0, newsArticles.Count - 1);
            articlePrefab.newsArticle = newsArticles[randomIndex];
            GameObject gameObject = Instantiate(articlePrefab.gameObject, transform.position, Quaternion.identity);
            newsArticles.RemoveAt(randomIndex);
            onArticleSpawned?.Invoke(gameObject);
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
