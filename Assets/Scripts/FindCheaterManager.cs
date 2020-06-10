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
    [SerializeField]private string CheaterNamet = "p_Paul";
    [SerializeField] private Animator AnimRevealRef;
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
        StartCoroutine(SetProfiles());
    }

    public void ChooseProfile(string name)
    {
        AnimRevealRef.gameObject.SetActive(true);
        StartCoroutine(SetResult());
        if(name == CheaterNamet)
        {
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Loose");
        }   
    }

    private IEnumerator SetProfiles ()
    {
        yield return new WaitForSeconds(2.2f);
        cheaterProfilesRef.SetProfile();
    }
    private IEnumerator SetResult()
    {
        yield return new WaitForSeconds(0.1f);
        AnimRevealRef.SetBool("Reveal", true);
    }
}