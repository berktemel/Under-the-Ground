using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tiles;

    private const string TILE_STATUS_KEY = "tile_status";

    public GameObject[] rocks;

    private const string ROCK_STATUS_KEY = "rock_status";

    private void Start()
    {
        string tileStatus = PlayerPrefs.GetString(TILE_STATUS_KEY);
        string rockStatus = PlayerPrefs.GetString(ROCK_STATUS_KEY);
        
        if (tileStatus != null && tileStatus.Length == tiles.Length)
        {
            for (int i = 0; i < tiles.Length; i++)
            {
                if (tileStatus[i] == '1')
                {
                    Destroy(tiles[i]);
                    if(i >= 56 && i <= 83)
                    {
                        Destroy(rocks[i - 56]);
                    }
                }
            }
        }

        if (rockStatus != null && rockStatus.Length == rocks.Length)
        {
            for (int i = 0; i < rocks.Length; i++)
            {
                if (rockStatus[i] == '1')
                {
                    BreakableTile breakableTile = rocks[i].GetComponent<BreakableTile>();
                    breakableTile.Hit = true;
                    breakableTile.changeSprite();
                }
            }
        }
    }

    public GameObject[] getTiles()
    {
        return tiles;
    }

    public string getKey()
    {
        return TILE_STATUS_KEY;
    }

    public GameObject[] getRocks()
    {
        return rocks;
    }

    public string getKeyRocks()
    {
        return ROCK_STATUS_KEY;
    }
}
