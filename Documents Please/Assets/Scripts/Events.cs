using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class ArticleDestroyed : UnityEvent<NewsArticle, bool> { }
[Serializable] public class ArticleSpawned : UnityEvent<GameObject> { }