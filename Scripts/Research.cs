using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor.PackageManager.UI;
using UnityEditor.U2D.Animation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Research : MonoBehaviour
{
    Player player;

    List<Canvas> popups = new List<Canvas>();

    bool clickedOk;

    int popupCount;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        clickedOk = false;
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();

        if (!player.inventoryEmpty())
        {
            GameObject[] inventory = player.getMicroorganisms();
            for (int i = 0; i < player.getMicroorganismCount(); i++)
            {
                Canvas popup = Instantiate(Resources.Load<Canvas>("Prefabs/PopupMessage"));
                popup.worldCamera = Camera.main;

                Image img = popup.GetComponentInChildren<Image>();
                img.sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;

                TextMeshProUGUI text = popup.GetComponentInChildren<TextMeshProUGUI>();
                Microorganism microorganism = inventory[i].GetComponent<Microorganism>();
                text.SetText(microorganism.getInfo());

                player.changeEnergy(1);
                player.addCoin(microorganism.getCoin());

                popups.Add(popup);
            }
            popupCount = popups.Count;
            player.removeAllInventory();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (popups.Count > 0)
        {
            if (popupCount == popups.Count)
            {
                popups[0].gameObject.SetActive(true);
            }
            else
            {
                popups.RemoveAt(0);
            }
        }
    }

    public void decrementPopupCount()
    {
        Camera.main.gameObject.GetComponent<Research>().decrement();
    }

    public void decrement()
    {
        popupCount--;
    }

    public void changeClicked()
    {
        clickedOk = !clickedOk;
    }

    public void OnOkButtonClick()
    {
        
    }
}
