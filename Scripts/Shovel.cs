using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    //public static Shovel instance;

    private Animator animator;

    private const string DIGGING_ANIMATION = "digging";

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite goldenShovel;

    private bool upgraded = false;
    public bool Upgraded
    {
        get { return upgraded; }
        set { upgraded = value; }
    }

    private void Awake()
    {
        /*if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        
        DontDestroyOnLoad(gameObject);*/

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(upgraded)
        {
            changeSprite();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAnim()
    {
        animator.SetBool(DIGGING_ANIMATION, true);
    }

    public void stopAnim()
    {
        animator.SetBool(DIGGING_ANIMATION, false);
    }

    public void changeSprite()
    {
        spriteRenderer.sprite = goldenShovel;
    }
}
