using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandidatesPanelWidget : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;

    [SerializeField] private CandidateTileWidget[] currentCandidate = null;

    private int correctPredictions = 0;
    private int incorrectPredictions = 0;

    public void OnEndRoundButtonPressed()
    {
        correctPredictions = 0;
        incorrectPredictions = 0;

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

            currentCandidate[i].ShowAnswer();
            currentCandidate[i].onRoundEnded();

        }

        StartCoroutine(UpdateMoneyAfterDelay());
    }

    private IEnumerator UpdateMoneyAfterDelay()
    {
        yield return new WaitForSeconds(1.2f);
        gameManager.OnRoundEnded(correctPredictions, incorrectPredictions);
    }

    public void SetCandidateTiles()
    {
        for (int i = 0; i < currentCandidate.Length; i++)
        {
            currentCandidate[i].SetFakeCurrentCandidate();
        }
    }
}
