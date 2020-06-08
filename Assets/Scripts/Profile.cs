using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile
{
    public int ID;
    public string fullName;
    public string interest;
    public Answer[] answers;
    public int money;
}

public class Answer
{
    public string answer;
    public bool isTrue;
}