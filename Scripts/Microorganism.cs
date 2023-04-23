using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Microorganism : MonoBehaviour
{
    [SerializeField]
    private int coin;
    [SerializeField]
    private string info;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getCoin()
    {
        return coin;
    }

    public string getInfo()
    {
        return info;
    }
}
