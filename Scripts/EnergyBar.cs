using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance;

    Slider slider;

    TextMeshProUGUI tmp;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        player = playerObject.GetComponent<Player>();

        slider = GetComponentInChildren<Slider>();
        Transform child = transform.Find("Fill/Text");
        tmp = child.GetComponent<TextMeshProUGUI>();

        changeEnergy(player.getEnergy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        int playersEnergy = player.getEnergy();
        changeEnergy(playersEnergy);
    }

    public void changeEnergy(int energy)
    {
        tmp.SetText(energy + "/20");
        slider.value = energy;
    }

}
