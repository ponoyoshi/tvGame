using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentQuestion = 0;
    public int currentMoney = 0;

    public void NextQuestion()
    {
        currentQuestion++;
    }
}
