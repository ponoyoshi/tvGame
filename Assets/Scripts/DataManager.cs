using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;


public class DataManager : MonoBehaviour
{
    public List<Profile> profiles = new List<Profile>();
    public Profile[] GetRandomProfiles(int number)
    {
        Profile[] returnedProfiles = new Profile[number];
        var rng = new System.Random();
        var values = Enumerable.Range(0, profiles.Count).OrderBy(x => rng.Next()).ToArray();
        for(int i = 0; i < number; i++)
            returnedProfiles[i] = profiles[values[i]];
            
        
        return returnedProfiles;
    }
}