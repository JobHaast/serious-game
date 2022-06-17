using System;
using UnityEngine.Events;

[Serializable] public class ArticleDestroyed : UnityEvent<NewsArticle, bool> { }
[Serializable] public class ArticleSpawned : UnityEvent<NewsArticle> { }