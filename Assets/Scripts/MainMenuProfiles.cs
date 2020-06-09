using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuProfiles : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    private void Start()
    {
        foreach(var profile in dataManager.profiles)
        {
            GameObject go = new GameObject();      
            go.AddComponent(typeof(Image));
            go.GetComponent<Image>().sprite = profile.image;       
            go.transform.SetParent(this.transform);
            go.transform.localScale = new Vector3(1,1,1);
        }
    }
}