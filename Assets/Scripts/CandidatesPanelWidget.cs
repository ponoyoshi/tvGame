using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandidatesPanelWidget : MonoBehaviour
{
    [SerializeField] private CandidateTileWidget[] currentCandidate = null;

    public void OnEndRoundButtonPressed()
    {
        for (int i = 0; i< currentCandidate.Length; i++)
        {
            currentCandidate[i].onRoundEnded();
        }
    }
}
