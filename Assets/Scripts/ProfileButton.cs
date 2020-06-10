using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileButton : MonoBehaviour
{
    public string name = "test";
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
