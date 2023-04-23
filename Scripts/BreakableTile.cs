using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BreakableTile : Tile
{ 
    private bool hit = false;
    public bool Hit
    {
        get { return hit; }
        set { hit = value; }
    }

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite hitStone;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        calculateSliderValue2();
    }

    protected void calculateSliderValue2()
    {
        if (isColliding)
        {
            currentCollisionTime += Time.deltaTime;

            if (currentCollisionTime >= collisionMaxTime)
            {
                GameObject playerObject = GameObject.FindWithTag("Player");
                Player player = playerObject.GetComponent<Player>();

                if (hit)
                {
                    player.changeEnergy(-1);
                    if (haveMicroorganism)
                    {
                        player.addMicroorganism(microorganism);
                    }

                    Destroy(gameObject);
                } else
                {
                    spriteRenderer.sprite = hitStone;
                    hit = true;
                    player.changeEnergy(-2);
                    Destroy(slider.gameObject);
                    isColliding = false;
                    currentCollisionTime = 0f;
                    slider.value = 0f;
                }

            }

            slider.value = currentCollisionTime / collisionMaxTime;
        }
    }

    public void changeSprite()
    {
        spriteRenderer.sprite = hitStone;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(hit)
        {
            startDigging(collision);
        } else
        {
            if (collision.CompareTag("Pickaxe"))
            {
                collision.gameObject.GetComponent<Pickaxe>().startAnim();

                Vector3 pos = transform.position;

                slider = Instantiate(Resources.Load("Prefabs/Slider", typeof(GameObject))).GetComponent<Slider>();
                slider.transform.SetParent(GameObject.Find("Canvas").transform, false);
                slider.transform.position = pos;

                isColliding = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(hit)
        {
            stopDigging(collision);
            GameObject.FindWithTag("Pickaxe").GetComponent<Pickaxe>().stopAnim();
        } else
        {
            stopBreaking(collision);
        }
    }

    protected void stopBreaking(Collider2D collision)
    {
        if (collision.CompareTag("Pickaxe"))
        {
            collision.gameObject.GetComponent<Pickaxe>().stopAnim();
            Destroy(slider.gameObject);
            isColliding = false;
            currentCollisionTime = 0f;
            slider.value = 0f;
        }
    }
}
