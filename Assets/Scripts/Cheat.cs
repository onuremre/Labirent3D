using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    public GameObject player;
    Transform transform;
    void Start()
    {
        transform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getCheat(string cheatCode)
    {
        if(cheatCode == "finishLevel")
        {
        }
    }
}
