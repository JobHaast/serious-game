using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public DatabaseManager databaseManager;
    public void CatogorizeArticle(NewsArticleDisplay newsArticleDisplay) 
    {
        //Check database if author is there and return isFake
        //Check database if source is there and return isFake
        bool? isFake = CheckDatabase(newsArticleDisplay.newsArticle);
        //if isFake == true move article to trash can
        //if isFake == false move article to stack of papers
        //if isFake == null player should move article somewhere
        if (isFake == true)
        {
            MoveArticle(newsArticleDisplay, true);
        }
        else if (isFake == false)
        {
            MoveArticle(newsArticleDisplay, false);
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
    private void MoveArticle(NewsArticleDisplay newsArticleDisplay,bool isFake)
    {
        if (isFake)
        {
            Debug.Log("Move to trash can");

            //move article to trash can
            newsArticleDisplay.gameObject.GetComponent<ClickAndDrag>().canMove = true;

            Debug.Log(newsArticleDisplay.gameObject.GetComponent<ClickAndDrag>().canMove);
            newsArticleDisplay.transform.position = Vector2.MoveTowards(newsArticleDisplay.transform.position, new Vector2(100, 200), 10 * Time.deltaTime);
            //newsArticleDisplay.gameObject.GetComponent<ClickAndDrag>().transform.Translate(Vector2.right * Time.deltaTime * 100);
            //newsArticleDisplay.transform.Translate(Vector2.right * Time.deltaTime * 100);
        }
        else 
        {
            Debug.Log("Move to stack of papers");
            newsArticleDisplay.gameObject.GetComponent<ClickAndDrag>().canMove = true;

            Debug.Log(newsArticleDisplay.gameObject.GetComponent<ClickAndDrag>().canMove);
            newsArticleDisplay.transform.position = Vector2.MoveTowards(newsArticleDisplay.transform.position, Vector2.right, 10 * Time.deltaTime);
            //newsArticleDisplay.gameObject.GetComponent<ClickAndDrag>().transform.Translate(Vector2.left * Time.deltaTime * 100);
            //newsArticleDisplay.transform.Translate(Vector2.left * Time.deltaTime * 100);
            //move article to stack of papers
        }
    }
}
