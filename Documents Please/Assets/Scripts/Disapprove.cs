using UnityEngine;

public class Disapprove : MonoBehaviour
{
    public ServiceLocator serviceLocator;
    public string disapproveArticleAudioName;
    [SerializeField] private ArticleDestroyed articleDestroyed;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Article"))
        {
            if (!collision.gameObject.GetComponent<ClickAndDrag>().dragging)
            {
                Debug.Log("Disapproved");
                Destroy(collision.gameObject);
                serviceLocator.GetAudioManager().Play(disapproveArticleAudioName);

                DatabaseManager databaseManager = serviceLocator.GetDatabaseManager();
                NewsArticle newsArticle = collision.gameObject.GetComponent<NewsArticleDisplay>().newsArticle;

                databaseManager.AddSource(newsArticle, false);
                databaseManager.AddAuthor(newsArticle, false);
                articleDestroyed?.Invoke(newsArticle, false);
            }

        }
    }
}
