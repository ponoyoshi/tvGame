using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CommonPanelWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerMoneyText = null;
    [SerializeField] private TextMeshProUGUI currentQuestionText = null;
    [SerializeField] public Animator animator = null;

    public void SetCurrentQuestion(string question)
    {
        currentQuestionText.text = question;
    }

    public void SetPlayerMoney(int money)
    {
        playerMoneyText.text = money.ToString();
    }
}
