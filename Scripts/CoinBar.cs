using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class CoinBar : MonoBehaviour
{
    public static CoinBar instance;

    TextMeshProUGUI tmp;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();

        Transform child = transform.Find("Fill/Text");
        tmp = child.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        int playersCoin = player.getTotalCoin();
        changeText(playersCoin);
    }

    public void changeText(int coin)
    {
        tmp.SetText(coin.ToString());
    }
}
