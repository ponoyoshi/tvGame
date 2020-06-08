using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<Profile> profiles = new List<Profile>();
    void Awake()
    {
        GetData();
    }
    public Profile GetProfile(int ID)
    {
        foreach(var profile in profiles)
            if(ID == profile.ID) return profile;

        return null;
    }
    private void GetData()
    {
        
    }
}
