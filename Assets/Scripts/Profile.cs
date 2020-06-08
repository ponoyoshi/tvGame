using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Profile", order = 1)]
public class Profile : ScriptableObject
{
    public string fullName;
    public string interest;
    public int money;
    public Image image;
    public List<Answer> answers;

    [Serializable]
    public struct Answer
    {
        [TextArea(3,3)]
        public string answer;
        public bool isTrue;
    }
}