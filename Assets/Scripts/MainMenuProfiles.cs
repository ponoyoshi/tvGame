using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenuProfiles : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;

    [SerializeField] private GameObject profileGO;
    private void Start()
    {
        foreach(var profile in dataManager.profiles)
        {
            var go = GameObject.Instantiate(profileGO);
            go.GetComponent<ProfileOption>().ModifyImage(profile.image);          
            go.transform.SetParent(this.transform);
            go.transform.localScale = new Vector3(1,1,1);
        }
    }
}