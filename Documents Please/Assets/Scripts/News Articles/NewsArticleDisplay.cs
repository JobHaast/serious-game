using TMPro;
using UnityEngine;

public class NewsArticleDisplay : MonoBehaviour
{
	public NewsArticle newsArticle;

	public TextMeshPro title;
	public TextMeshPro description;
	public TextMeshPro source;
	public TextMeshPro author;
	//public SpriteRenderer photo;

	void Start()
	{
		title.text = newsArticle.title;
		description.text = newsArticle.description;
		source.text = newsArticle.source;
		author.text = newsArticle.author;
	}
}

