﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandidatesPanelWidget : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private CommonPanelWidget commonPanelWidget = null;

    [SerializeField] private CandidateTileWidget[] currentCandidate = null;
    [SerializeField] private Animator animator = null;
    [SerializeField] private Image rewardPopupBackground = null;
    [SerializeField] private TextMeshProUGUI rewardPopupTitle = null;
    [SerializeField] private TextMeshProUGUI rewardPopupDescription = null;

    [SerializeField] private Color POSITIVE_COLOR = Color.green;
    [SerializeField] private Color NEGATIVE_COLOR = Color.red;

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

        SetRewardPopup();

        StartCoroutine(UpdateMoneyAfterDelay());
    }

    private IEnumerator UpdateMoneyAfterDelay()
    {
        yield return new WaitForSeconds(5.5f);

        animator.SetTrigger("Reward");

        for (int i = 0; i < currentCandidate.Length; i++)
        {
            currentCandidate[i].HideTile();
        }

        yield return new WaitForSeconds(1.5f);

        commonPanelWidget.animator.SetTrigger("ShowNewQuestion");

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

    private void SetRewardPopup()
    {
        int gain = 0;

        if (incorrectPredictions > 0 && correctPredictions == 0)
        {
            rewardPopupTitle.enabled = false;
            rewardPopupBackground.color = NEGATIVE_COLOR;
            rewardPopupDescription.text = "Gains divisés par deux";
        }
        else if (incorrectPredictions > 0)
        {
            rewardPopupTitle.enabled = true;
            rewardPopupBackground.color = NEGATIVE_COLOR;
            rewardPopupTitle.text = "Vous perdez :";

            gain = gameManager.MONEY_LOST_PER_MISTAKE * incorrectPredictions;

            rewardPopupDescription.text = gain.ToString();
        }
        else
        {
            rewardPopupTitle.enabled = true;
            rewardPopupBackground.color = POSITIVE_COLOR;
            rewardPopupTitle.text = "Vous gagnez :";

            gain = gameManager.MONEY_GAINED_PER_GOOD_PREDICTION * correctPredictions;

            rewardPopupDescription.text = gain.ToString();
        }
    }
}
