using UnityEngine;

public class AI : MonoBehaviour
{
    //public DatabaseManager databaseManager;
    public ServiceLocator serviceLocator;
    public GameObject stackOfPapers;
    public GameObject trashCan;

    public void CatogorizeArticle(GameObject gameObject) 
    {
        //Check database if author is there and return isFake
        //Check database if source is there and return isFake
        bool? isFake = CheckDatabase(gameObject.GetComponent<NewsArticleDisplay>().newsArticle);
        //if isFake == true move article to trash can
        //if isFake == false move article to stack of papers
        //if isFake == null player should move article somewhere
        if (isFake == true)
        {
            MoveArticle(gameObject, true);
        }
        else if (isFake == false)
        {
            MoveArticle(gameObject, false);
        }

        //player move article
        return;
    }
    private bool? CheckDatabase(NewsArticle newsArticle) 
    {
        bool? authorIsFake = serviceLocator.GetDatabaseManager().GetAuthor(newsArticle.author);
        bool? sourceIsFake = serviceLocator.GetDatabaseManager().GetSource(newsArticle.source);
        
        if (authorIsFake == true && sourceIsFake == true)
        {
            return true;
        }
        else if (authorIsFake == false && sourceIsFake == false)
        {
            return false;
        }
        return null;
    }

    private void MoveArticle(GameObject gameObject, bool isFake)
    {
        gameObject.GetComponent<ClickAndDrag>().isAI = true;
        Debug.Log(gameObject.GetComponent<ClickAndDrag>().isAI);
        gameObject.GetComponent<ClickAndDrag>().isFake = isFake;
    }
}
