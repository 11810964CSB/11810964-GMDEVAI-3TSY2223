using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] agent;
    public float allCivilians; 
    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.FindGameObjectsWithTag("agent");
        allCivilians = agent.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (allCivilians== 0)
        {
            print("ENDING");
        }
    }
}
