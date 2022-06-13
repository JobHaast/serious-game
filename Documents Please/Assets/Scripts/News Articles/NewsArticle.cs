using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New News Article", menuName = "News Article")]
[Serializable]
public class NewsArticle : ScriptableObject
{
    public string title;
    [TextArea(3, 10)]
    public string description;
    public string source;
    public string author;
    public bool isFakeNews;
    public int amountOfSubscribers;
}

