using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private List<Profile> profiles = new List<Profile>();
    public Profile[] GetRandomProfiles()
    {
        Profile[] returnedProfiles = new Profile[5];
        var rng = new System.Random();
        var values = Enumerable.Range(0, users.Count).OrderBy(x => rng.Next()).ToArray();
        for(int i = 0; i < 5; i++)
            returnedProfiles[i] = profiles[values[i]]; 
    }
}
