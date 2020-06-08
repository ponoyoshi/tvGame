using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandidatesPanelWidget : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;

    [SerializeField] private CandidateTileWidget[] currentCandidate = null;

    public void OnEndRoundButtonPressed()
    {
        int correctPredictions      = 0;
        int incorrectPredictions    = 0;

        for (int i = 0; i< currentCandidate.Length; i++)
        {
            if (currentCandidate[i].IsPredictionCorrect() == 1)
            {
                correctPredictions++;
            }
            else if (currentCandidate[i].IsPredictionCorrect() == 2)
            {
                incorrectPredictions++;
            }

            currentCandidate[i].onRoundEnded();

        }

        gameManager.OnRoundEnded(correctPredictions, incorrectPredictions);

    }
}
