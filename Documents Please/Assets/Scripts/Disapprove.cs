using UnityEngine;

public class Disapprove : MonoBehaviour
{
    [SerializeField] private ArticleDestroyed articleDestroyed;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Article"))
        {
            //Debug.Log(collision.gameObject.GetComponent<NewsArticleDisplay>().newsArticle.title);
            if (!collision.gameObject.GetComponent<ClickAndDrag>().dragging)
            {
                Debug.Log("Disapproved");
                Destroy(collision.gameObject);
                articleDestroyed?.Invoke(collision.gameObject.GetComponent<NewsArticleDisplay>().newsArticle);
            }

        }
    }
}
