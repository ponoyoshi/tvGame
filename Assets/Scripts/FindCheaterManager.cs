using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
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
    [SerializeField] private Sprite cheaterFoundSprite;
    [SerializeField] private Sprite cheaterNotFoundSprite;
    [SerializeField] private string cheaterFoundText1;
    [SerializeField] private string cheaterFoundText2;
    [SerializeField] private string cheaterNotFoundText1;
    [SerializeField] private string cheaterNotFoundText2;
    [SerializeField] private Image victoryBackgroundImage;
    [SerializeField] private TextMeshProUGUI victoryText1 = null;
    [SerializeField] private TextMeshProUGUI victoryText2 = null;
    [SerializeField] private Profile cheaterSOref = null;
    [SerializeField] private GameManager gameManagerRef = null;

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
            victoryBackgroundImage.sprite = cheaterFoundSprite;
            victoryText1.text = cheaterFoundText1;
            victoryText2.text = cheaterFoundText2;
            gameManagerRef.DoubleMoney();
        }
        else
        {
            victoryBackgroundImage.sprite = cheaterNotFoundSprite;
            victoryText1.text = cheaterNotFoundText1;
            victoryText2.text = cheaterNotFoundText2;
            cheaterSOref.money *= 2;
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