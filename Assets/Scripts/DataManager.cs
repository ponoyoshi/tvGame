using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Linq;


public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Profile> profiles = new List<Profile>();
    private Profile[] PickedProfiles = new Profile[10];
    public Profile[] GetRandomProfiles(int number)
    {
        Profile[] returnedProfiles = new Profile[number];
        var rng = new System.Random();
        var values = Enumerable.Range(0, profiles.Count).OrderBy(x => rng.Next()).ToArray();
        for(int i = 0; i < number; i++)
            returnedProfiles[i] = profiles[values[i]];
            
        
        return returnedProfiles;
    }
    public Profile[] GetRandomPickedProfiles(int number)
    {
        Profile[] returnedProfiles = new Profile[number];
        var rng = new System.Random();
        var values = Enumerable.Range(0, PickedProfiles.Length).OrderBy(x => rng.Next()).ToArray();
        for(int i = 0; i < number; i++)
            returnedProfiles[i] = PickedProfiles[values[i]];
            
        
        return returnedProfiles;
    }
    public void ShuffleProfiles() => PickedProfiles = GetRandomProfiles(10);
    private void Awake() => ShuffleProfiles();
}