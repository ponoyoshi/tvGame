using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class ProfileButton : MonoBehaviour
{
    public string name = "test";
    public TextMeshProUGUI nameRef;
    public TextMeshProUGUI scoreRef;
    private FindCheaterManager cheaterManagereRef;

    // Start is called before the first frame update
    void Start()
    {
        cheaterManagereRef = GameObject.FindObjectOfType<FindCheaterManager>();
    }

    public void Click()
    {
        cheaterManagereRef.ChooseProfile(name);
    }
}
