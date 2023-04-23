using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    protected bool haveMicroorganism;

    protected GameObject microorganism;

    [SerializeField]
    protected GameObject textOnScreen;

    [SerializeField]
    protected GameObject allMicroorganisms;

    protected TextMeshPro tmp;

    protected float collisionMaxTime = 0.7f;

    protected float currentCollisionTime = 0f;

    protected bool isColliding = false;

    [SerializeField]
    protected Slider slider;

    private void Awake()
    {
        tmp = textOnScreen.GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        float chanceOfMicroorganism = Random.value * 100;
        haveMicroorganism = chanceOfMicroorganism < 45;
        if(haveMicroorganism)
        {
            microorganism = allMicroorganisms.GetComponent<AllMicroorganisms>().getRandomMicroorganism();
        }

    }

    // Update is called once per frame
    void Update()
    {
        calculateSliderValue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        startDigging(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopDigging(collision);
    }

    protected void calculateSliderValue()
    {
        if(isColliding)
        {
            currentCollisionTime += Time.deltaTime;

            if(currentCollisionTime >= collisionMaxTime)
            {
                GameObject playerObject = GameObject.FindWithTag("Player");
                Player player = playerObject.GetComponent<Player>();

                player.changeEnergy(-1);

                if (haveMicroorganism)
                {
                    player.addMicroorganism(microorganism);
                }

                Destroy(gameObject);
            }

            slider.value = currentCollisionTime / collisionMaxTime;
        }
    }

    protected void startDigging(Collider2D collision)
    {
        GameObject playerObject = GameObject.FindWithTag("Player");
        Player player = playerObject.GetComponent<Player>();

        if (!player.inventoryFull())
        {
            if (collision.CompareTag("Shovel"))
            {
                collision.gameObject.GetComponent<Shovel>().startAnim();

                Vector3 pos = transform.position;

                slider = Instantiate(Resources.Load("Prefabs/Slider", typeof(GameObject))).GetComponent<Slider>();
                slider.transform.SetParent(GameObject.Find("Canvas").transform, false);
                slider.transform.position = pos;

                isColliding = true;
            }
        }
        else
        {
            tmp.SetText("Inventory Full! Go to Lab.");
            if (GameObject.FindWithTag("WarningMessage") == null)
            {
                Vector3 pos = GameObject.FindWithTag("MainCamera").transform.position;
                pos.y += 4f;
                pos.z = 0;
                GameObject warning = Instantiate(textOnScreen, pos, Quaternion.identity);
                Destroy(warning, 3f);
            }
        }
    }

    protected void stopDigging(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            collision.gameObject.GetComponent<Shovel>().stopAnim();
            if(slider != null)
            {
                Destroy(slider.gameObject);
            }
            isColliding = false;
            currentCollisionTime = 0f;
            slider.value = 0f;
        }
    }
}
