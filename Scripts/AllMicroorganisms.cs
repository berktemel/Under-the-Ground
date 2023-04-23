using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMicroorganisms : MonoBehaviour
{
    [SerializeField]
    private GameObject[] microorganisms;

    private int count = 21;

    // Start is called before the first frame update
    void Start()
    {
        microorganisms = new GameObject[count];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getRandomMicroorganism()
    {
        int random = Random.Range(0, count);
        return microorganisms[random];
    }
}
