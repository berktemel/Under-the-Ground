using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSceneToField()
    {
        SceneManager.LoadScene(0);
        GameObject playerObject = GameObject.FindWithTag("Player");
        playerObject.transform.position = new Vector3(2.5f, 2.7f, 0);

        /*if(shovelBought)
        {
            Debug.Log(GameObject.FindWithTag("Shovel"));
            GameObject.FindWithTag("Shovel").GetComponent<Shovel>().changeSprite();
        }

        if (pickBought)
        {
            GameObject.FindWithTag("Pickaxe").GetComponent<Pickaxe>().changeSprite();
        }*/
    }

    public void changeSceneToLab()
    {
        TileManager tileManager = GameObject.FindWithTag("TileManager").GetComponent<TileManager>();
        GameObject[] tiles = tileManager.getTiles();
        string tileStatus = "";
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == null)
            {
                tileStatus += '1';
            }
            else
            {
                tileStatus += '0';
            }
        }
        PlayerPrefs.SetString(tileManager.getKey(), tileStatus);

        GameObject[] rocks = tileManager.getRocks();
        string rockStatus = "";
        for (int i = 0; i < rocks.Length; i++)
        {
            if (rocks[i] == null || rocks[i].GetComponent<BreakableTile>().Hit)
            {
                rockStatus += '1';
            }
            else
            {
                rockStatus += '0';
            }
        }
        PlayerPrefs.SetString(tileManager.getKeyRocks(), rockStatus);

        SceneManager.LoadScene(1);
        GameObject playerObject = GameObject.FindWithTag("Player");
        playerObject.transform.position = new Vector3(-4.11f, -3.04f, 0);

    }
}
