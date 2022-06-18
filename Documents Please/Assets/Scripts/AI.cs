using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public DatabaseManager databaseManager;
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
        } else
        {
            //player move article somewhere
        }


    }
    private bool? CheckDatabase(NewsArticle newsArticle) 
    {
        bool? authorIsFake = databaseManager.GetAuthor(newsArticle.author);
        bool? sourceIsFake = databaseManager.GetSource(newsArticle.source);
        
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
    private void MoveArticle(GameObject gameObject,bool isFake)
    {

        gameObject.GetComponent<ClickAndDrag>().isAI = true;
        Debug.Log(gameObject.GetComponent<ClickAndDrag>().isAI);
        if (isFake)
        {
            Debug.Log("Move to trash can");
            gameObject.GetComponent<ClickAndDrag>().isFake = true;
        }
        else
        {
            Debug.Log("Move to stack of papers");
            gameObject.GetComponent<ClickAndDrag>().isFake = false;
        }
    }
}
