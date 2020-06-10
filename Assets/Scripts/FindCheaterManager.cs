using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindCheaterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RefCandidatesPanel;
    [SerializeField]
    private GameObject CheaterAsset;
    [SerializeField] private string cheaterPhaseText = "Trouvez le tricheur !";
    [SerializeField] private TextMeshProUGUI questionText = null;
    [SerializeField] private TextMeshProUGUI questionNumText = null;
    [SerializeField] private TextMeshProUGUI questionNumTileText = null;
    [SerializeField] private CheaterProfiles cheaterProfilesRef = null;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetCheaterPhase()
    {
        questionText.text = cheaterPhaseText;
        questionNumText.text = "";
        questionNumTileText.text = "";
        RefCandidatesPanel.SetActive(false);
        CheaterAsset.SetActive(true);
        cheaterProfilesRef.SetProfile();
    }

    public void ChooseProfile(string name)
    {
        Debug.Log("Choose");
    }
}