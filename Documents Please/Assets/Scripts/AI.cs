using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public DatabaseManager databaseManager;
    public void CatogorizeArticle(NewsArticle newsArticle) 
    {
        //Check database if author is there and return isFake
        //Check database if source is there and return isFake
        bool? isFake = CheckDatabase(newsArticle);
        //if isFake == true move article to trash can
        //if isFake == false move article to stack of papers
        //if isFake == null player should move article somewhere
        if (isFake == true)
        {
            MoveArticle(true);
        }
        else if (isFake == false)
        {
            MoveArticle(false);
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
    private void MoveArticle(bool isFake)
    {
        if (isFake)
        {
            //move article to trash can
        }
        else 
        {
            //move article to stack of papers
        }
    }
}
