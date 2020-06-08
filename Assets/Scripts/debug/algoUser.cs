using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class algoUser : MonoBehaviour
{
    public int timeSeen = 0;
    private void Start()
    {
        
    }
    private void Update()
    {
        GetComponent<Text>().text = $"USER: {timeSeen}";
    }
}
