using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CommonPanelWidget commonPanelWidget = null;
    [SerializeField] private CandidatesPanelWidget candidatePanelWidget = null;
    [HideInInspector] public int currentQuestion = 0;
    public int currentMoney = 0;
    public int MONEY_MULTIPLE = 50;
    public int MONEY_DIVIDE_RATIO = 2;
    public int MONEY_LOST_PER_MISTAKE = 250;
    public int MONEY_GAINED_PER_GOOD_PREDICTION = 500;
    [SerializeField] private List<string> questions = new List<string>();

    public void OnRoundEnded(int correctPredictions, int incorrectPredictions)
    {
        SetMoney(correctPredictions, incorrectPredictions);
        candidatePanelWidget.SetCandidateTiles();
    }

    public void SetCurrentQuestion()
    {
        currentQuestion++;
        commonPanelWidget.SetCurrentQuestion(questions[currentQuestion]);
    }

    public void SetMoney(int correctPredictions, int incorrectPredictions)
    {
        if (incorrectPredictions > 0 && correctPredictions == 0)
        {
            int roundedMoney = currentMoney / MONEY_DIVIDE_RATIO;
            roundedMoney /= MONEY_MULTIPLE;
            roundedMoney = Mathf.RoundToInt(roundedMoney);
            roundedMoney *= MONEY_MULTIPLE;

            currentMoney = roundedMoney;
        }
        else if (incorrectPredictions > 0)
        {
            currentMoney -= MONEY_LOST_PER_MISTAKE * incorrectPredictions;

            // cap money to 0
            currentMoney = currentMoney <= 0 ? 0 : currentMoney;
        }
        else
        {
            currentMoney += MONEY_GAINED_PER_GOOD_PREDICTION * correctPredictions;
        }

        commonPanelWidget.SetPlayerMoney(currentMoney);
    }
}
