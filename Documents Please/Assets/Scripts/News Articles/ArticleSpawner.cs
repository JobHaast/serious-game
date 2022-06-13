using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArticleSpawner : MonoBehaviour
{
    public List<NewsArticleDisplay> articlePrefabs;
    private GameObject currentArticle;

    [SerializeField] private UnityEvent outOfArticles;


    public void SpawnArticle() 
    {
        if (articlePrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, articlePrefabs.Count - 1);
            currentArticle = Instantiate(articlePrefabs[randomIndex].gameObject, transform.position, Quaternion.identity);
            articlePrefabs.RemoveAt(randomIndex);
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
