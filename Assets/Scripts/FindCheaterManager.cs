using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCheaterManager : MonoBehaviour
{
    [SerializeField]
    private GameObject RefCandidatesPanel;
    [SerializeField]
    private GameObject CheaterAsset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetCheaterPhase()
    {
        RefCandidatesPanel.SetActive(false);
        CheaterAsset.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
