using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private List<Profile> profiles = new List<Profile>();
    void Awake()
    {
        
    }
    public Profile GetProfile(int ID)
    {
        return profiles[ID];
    }
}
