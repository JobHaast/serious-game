using TMPro;
using UnityEngine;

public class PassportDisplay : MonoBehaviour
{
	public Passport passport;

	public TextMeshPro firstName;
	public TextMeshPro lastName;
	public TextMeshPro dateOfBirth;
	public TextMeshPro gender;
	public TextMeshPro country;
	public TextMeshPro experationDate;
	public SpriteRenderer photo;

	void Start()
	{
		firstName.text = passport.firstName;
		lastName.text = passport.lastName;
		dateOfBirth.text = passport.dateOfBirth;
		gender.text = passport.gender.ToString();
		country.text = passport.country;
		experationDate.text = passport.experationDate;
		photo.sprite = passport.photo;
	}
}
