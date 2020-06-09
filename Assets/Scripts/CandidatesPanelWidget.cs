using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandidatesPanelWidget : MonoBehaviour
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private DataManager dataManager = null;

    [SerializeField] private CommonPanelWidget commonPanelWidget = null;

    [SerializeField] private GameObject endRoundButton = null;
    [SerializeField] private GameObject hideAnswersButton = null;

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

        endRoundButton.SetActive(false);

        SetRewardPopup();

        StartCoroutine(ShowHideAnswersButtonAfterDelay());
    }

    public void OnHideAnswersPressed()
    {
        StartCoroutine(UpdateMoneyAfterDelay());
    }

    private IEnumerator ShowHideAnswersButtonAfterDelay()
    {
        yield return new WaitForSeconds(4.4f);
        hideAnswersButton.SetActive(true);
    }

    private IEnumerator UpdateMoneyAfterDelay()
    {
        hideAnswersButton.SetActive(false);

        animator.SetTrigger("Reward");

        for (int i = 0; i < currentCandidate.Length; i++)
        {
            currentCandidate[i].HideTile();
        }

        yield return new WaitForSeconds(1.5f);

        commonPanelWidget.animator.SetTrigger("ShowNewQuestion");

        yield return new WaitForSeconds(1.2f);

        gameManager.OnRoundEnded(correctPredictions, incorrectPredictions);
        endRoundButton.SetActive(true);
    }

    public void SetCandidateTiles()
    {
        Profile[] profiles = dataManager.GetRandomProfiles(5);
        for (int i = 0; i < currentCandidate.Length; i++)
        {
            currentCandidate[i].SetCurrentCandidate(profiles[i]);
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
