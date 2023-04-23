using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField]
    private GameObject textOnScreen;

    private TextMeshPro tmp;

    private Player player;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        tmp = textOnScreen.GetComponent<TextMeshPro>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        parent = GameObject.FindWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void close()
    {
        this.gameObject.SetActive(false);
    }

    public void open()
    {
        this.gameObject.SetActive(true);
    }

    public void buyShovel()
    {
        if(player.getTotalCoin() < 50)
        {
            tmp.SetText("Not enough coin");
            if (GameObject.FindWithTag("WarningMessage") == null)
            {
                Vector3 pos = GameObject.FindWithTag("MainCamera").transform.position;
                pos.y += 4f;
                pos.z = 0;
                GameObject warning = Instantiate(Resources.Load("Prefabs/WarningCanvas"), pos, Quaternion.identity) as GameObject;
                Destroy(warning, 3f);
            }
        } else
        {
            /*GameObject shovelObj = GameObject.FindWithTag("Shovel");
            Shovel shovel = shovelObj.GetComponent<Shovel>();
            shovel.changeSprite();*/
            //Shovel.instance.Upgraded = true;
        }
    }

    public void buyPick()
    {

    }
}
