using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        TileManager tileManager = GameObject.FindWithTag("TileManager").GetComponent<TileManager>();
        PlayerPrefs.DeleteKey(tileManager.getKey());
        PlayerPrefs.DeleteKey(tileManager.getKeyRocks());
    }
}
