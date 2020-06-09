﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CandidateTileWidget : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private Image profilePicture = null;
    [SerializeField] private Image background = null;
    [SerializeField] private TextMeshProUGUI nameText = null;
    [SerializeField] private TextMeshProUGUI preferencesText = null;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI moneyText = null;
    [SerializeField] private TextMeshProUGUI answerText = null;
    [SerializeField] private Profile currentCandidate = null;
    [SerializeField] private Animator animator = null;

    [HideInInspector] public int currentUpvoteScore = 0; //0 = null, 1 = downvote, 2 = upvote
    [SerializeField] private GameManager gameManager = null;

    [Header("Colors")]
    [SerializeField] private Color UPVOTE_COLOR = Color.blue;
    [SerializeField] private Color DOWNVOTE_COLOR = Color.red;
    [SerializeField] private Color DEFAULT_COLOR = Color.grey;

    private const int MONEY_LOST_PER_MISTAKE = 1000;
    private const int MONEY_GAINED_PER_SUCCESS = 1000;

    private void Start()
    {
        SetFakeCurrentCandidate();
    }

    public void SetFakeCurrentCandidate()
    {
        SetCurrentCandidate(currentCandidate);
    }

    public void SetCurrentCandidate(Profile scriptableObject)
    {
        currentCandidate = scriptableObject;
        SetTile(currentCandidate.image, currentCandidate.fullName, currentCandidate.interest, currentCandidate.answers[gameManager.currentQuestion].answer, currentCandidate.score, currentCandidate.money);
    }

    private void SetTile(Sprite picture, string name, string preferences, string answer, int score, int money)
    {
        profilePicture.sprite   = picture;
        nameText.text           = name;
        preferencesText.text    = preferences;
        scoreText.text          = score.ToString();
        moneyText.text          = money.ToString();
        answerText.text         = answer;

        currentUpvoteScore = 0;
        ResetDefaultVisual();

        StartCoroutine(PlayAnimationAfterDelay(transform.GetSiblingIndex() * 0.2f, "Appear"));
    }

    private IEnumerator PlayAnimationAfterDelay(float delay, string animationName)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger(animationName);
    }

    public void ShowAnswer()
    {
        StartCoroutine(PlayAnimationAfterDelay(transform.GetSiblingIndex() * 0.8f, "ShowAnswer"));
    }

    private void SetUpdvotedVisual()
    {
        background.color = UPVOTE_COLOR;
    }

    private void SetDownvotedVisual()
    {
        background.color = DOWNVOTE_COLOR;
    }

    private void ResetDefaultVisual()
    {
        background.color = DEFAULT_COLOR;
    }

    public void OnUpvotePressed()
    {
        currentUpvoteScore = 2;
        SetUpdvotedVisual();
    }

    public void OnDownvotePressed()
    {
        currentUpvoteScore = 1;
        SetDownvotedVisual();
    }

    public void OnCancelPressed()
    {
        currentUpvoteScore = 0;
        ResetDefaultVisual();
    }

    public void onRoundEnded()
    {

    }

    public void OnShowAnswerAnimationEnded()
    {

    }

    public void HideTile()
    {
        StartCoroutine(PlayAnimationAfterDelay(transform.GetSiblingIndex() * 0.1f, "Hide"));
    }

    // 0 = no prediction, 1 = correct, 2 = incorrect
    public int IsPredictionCorrect()
    {
        //correct answer from candidate
        if (currentCandidate.answers[gameManager.currentQuestion].isTrue)
        {
            currentCandidate.score += 1;
            currentCandidate.money += MONEY_GAINED_PER_SUCCESS;

            if (currentUpvoteScore == 2)
            {
                return 1;
            }
            else if (currentUpvoteScore == 1)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }

        //wrong answer from candidate
        else
        {
            currentCandidate.money -= MONEY_LOST_PER_MISTAKE;

            if (currentCandidate.money < 0)
            {
                currentCandidate.money = 0;
            }

            if (currentUpvoteScore == 2)
            {
                return 2;
            }
            else if (currentUpvoteScore == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
