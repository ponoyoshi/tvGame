using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CheaterProfiles : MonoBehaviour
{
    [SerializeField] private DataManager dataManager;
    public GameObject goCheaterProfile;
    public void SetProfile()
    {
        foreach (var profile in dataManager.profiles)
        {
            GameObject go = Instantiate(goCheaterProfile);
            go.GetComponent<Image>().sprite = profile.image;
            go.transform.SetParent(this.transform);
            go.transform.localScale = new Vector3(1, 1, 1);
            go.name = profile.name;
            go.GetComponent<ProfileButton>().name = profile.name;
        }
    }

}
