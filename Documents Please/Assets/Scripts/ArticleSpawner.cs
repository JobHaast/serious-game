using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArticleSpawner : MonoBehaviour
{
    public List<NewsArticleDisplay> articlePrefabs;
    private GameObject currentArticle;
    // Start is called before the first frame update
    void Start()
    {
        SpawnArticles();
    }
    public void SpawnArticles() 
    {
        int randomIndex = Random.Range(0, articlePrefabs.Count -1);
        currentArticle = Instantiate(articlePrefabs[randomIndex].gameObject, transform.position, Quaternion.identity);
        articlePrefabs.RemoveAt(randomIndex);        
    }
    // Update is called once per frame
    void Update()
    {
        if (!currentArticle && articlePrefabs.Count > 0)
        {
            SpawnArticles();
        }
    }
}
