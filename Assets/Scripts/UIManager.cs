using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] UIObjects;


    // Start is called before the first frame update
    void Start()
    {
        SelectUI(0);
    }

    public void SelectUI(int index)
    {
        foreach(var go in UIObjects)
            go.SetActive(false);

        UIObjects[index].SetActive(true);
    }
}
