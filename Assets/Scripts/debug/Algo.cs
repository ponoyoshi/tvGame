using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Algo : MonoBehaviour
{
    public GameObject user;
    public List<GameObject> users = new List<GameObject>();
    int n = 0;
    void Start()
    {
        AddUser();
        AddUser();
        AddUser();
        AddUser();
        AddUser();
        AddUser();
        AddUser();
        AddUser();
        AddUser();
        AddUser();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up")) Iterate();
    }

    private void Iterate()
    {
        Debug.Log($"iteration {n}");

        var rng = new System.Random();
        var values = Enumerable.Range(0, users.Count).OrderBy(x => rng.Next()).ToArray();
        
        for(int i = 0; i < 5; i++)
            users[values[i]].GetComponent<algoUser>().timeSeen++;

        n++;
    }

    private void AddUser()
    {
        GameObject go = Instantiate(user);
        go.transform.SetParent(transform);
        go.transform.localScale = new Vector3(1,1,1);
        users.Add(go);
    }
}
