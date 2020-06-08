using System.Collections;
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
    [SerializeField] private Profile currentCandidate = null;

    private int currentUpvoteScore = 0; //0 = null, 1 = downvote, 2 = upvote

    [Header("Colors")]
    [SerializeField] private Color UPVOTE_COLOR = Color.blue;
    [SerializeField] private Color DOWNVOTE_COLOR = Color.red;

    private void Start()
    {
        SetCurrentCandidate(currentCandidate);
    }

    public void SetCurrentCandidate (Profile scriptableObject)
    {
        currentCandidate = scriptableObject;
        SetTile(currentCandidate.image, currentCandidate.fullName, currentCandidate.interest, currentCandidate.score);
    }

    private void SetTile(Sprite picture, string name, string preferences, int score = 0)
    {
        profilePicture.sprite   = picture;
        nameText.text           = name;
        preferencesText.text    = preferences;
        scoreText.text          = score.ToString();
    }

    private void SetUpdvotedVisual()
    {
        background.color = UPVOTE_COLOR;
    }

    private void SetDownvotedVisual()
    {
        background.color = DOWNVOTE_COLOR;
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

    public void onRoundEnded()
    {
        switch (currentUpvoteScore)
        {
            case (0):

                break;
        }
    }
}
