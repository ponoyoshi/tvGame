using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommonPanelWidget : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private TextMeshProUGUI playerMoneyText = null;
    [SerializeField] private TextMeshProUGUI currentQuestionText = null;
    [SerializeField] private TextMeshProUGUI currentQuestionNumbText = null;
    [SerializeField] public Animator animator = null;

    public void SetCurrentQuestion(string question, int numQuestion)
    {
        currentQuestionText.text = question;
        if(numQuestion < 10)
        {
            currentQuestionNumbText.text = "0"+numQuestion.ToString();
        }
        else
        {
            currentQuestionNumbText.text = numQuestion.ToString();
        }
        
    }

    public void SetPlayerMoney(int money)
    {
        playerMoneyText.text = money.ToString();
    }

    public void UpdateObjective()
    {
        gameManager.SetCurrentQuestion();
    }
}
