using UnityEngine;

public class Approve : MonoBehaviour
{
    public ServiceLocator serviceLocator;
    public string approveArticleAudioName;
    [SerializeField] private ArticleDestroyed articleDestroyed;

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Article"))
        {
            if (!collision.gameObject.GetComponent<ClickAndDrag>().dragging)
            {
                Debug.Log("Approved");
                Destroy(collision.gameObject);
                serviceLocator.GetAudioManager().Play(approveArticleAudioName);

                NewsArticle newsArticle = collision.gameObject.GetComponent<NewsArticleDisplay>().newsArticle;
                serviceLocator.GetAIManager().AddNewsArticle(newsArticle, true);
                articleDestroyed?.Invoke(newsArticle, true);
            }
        }
    }
}
