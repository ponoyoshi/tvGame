using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CommonPanelWidget commonPanelWidget = null;
    [SerializeField] private CandidatesPanelWidget candidatePanelWidget = null;
    public int currentQuestion = 0;
    public int currentMoney = 0;
    public const int MONEY_LOST_PER_MISTAKE = 250;
    public const int MONEY_GAINED_PER_GOOD_PREDICTION = 500;

    public void OnRoundEnded(int correctPredictions, int incorrectPredictions)
    {
        SetMoney(correctPredictions, incorrectPredictions);
        candidatePanelWidget.SetCandidateTiles();

        //currentQuestion++;
    }

    public void SetMoney(int correctPredictions, int incorrectPredictions)
    {
        if (incorrectPredictions > 0 && correctPredictions == 0)
        {
            currentMoney = currentMoney / 2;
        }
        else if (incorrectPredictions > 0)
        {
            currentMoney -= MONEY_LOST_PER_MISTAKE * incorrectPredictions;
        }
        else
        {
            currentMoney += MONEY_GAINED_PER_GOOD_PREDICTION * correctPredictions;
        }

        commonPanelWidget.SetPlayerMoney(currentMoney);
    }
}
