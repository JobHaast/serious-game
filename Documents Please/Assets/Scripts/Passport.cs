using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Passport", menuName = "Passport")]
[Serializable]
public class Passport : ScriptableObject
{
    public string firstName;
    public string lastName;
    public string dateOfBirth;
    public Gender gender;
    public string country;
    public string experationDate;
    public Sprite photo;
}
