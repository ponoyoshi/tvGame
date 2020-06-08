using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Profile", order = 1)]
public class Profile : ScriptableObject
{
    public int ID;
    public string fullName;
    public string interest;
    public List<Answer> answers;
    public int money;
    public Image image;

    [Serializable]
    public struct Answer
    {
        [TextArea(3,3)]
        public string answer;
        public bool isTrue;
    }
}

