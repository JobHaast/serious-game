using System.Collections.Generic;
using UnityEngine;

public class ArticleSpawner : MonoBehaviour
{
    public List<NewsArticleDisplay> articlePrefabs;
    private GameObject currentArticle;

    public delegate void OutOfArticles();
    public static event OutOfArticles outOfArticles;

    void OnEnable()
    {
        DialogueManager.dialogueFinished += SpawnArticle;
        Approve.articleDestroyed += SpawnArticle;
        Disapprove.articleDestroyed += SpawnArticle;
    }


    void OnDisable()
    {
        DialogueManager.dialogueFinished -= SpawnArticle;
        Approve.articleDestroyed -= SpawnArticle;
        Disapprove.articleDestroyed -= SpawnArticle;
    }

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
}
