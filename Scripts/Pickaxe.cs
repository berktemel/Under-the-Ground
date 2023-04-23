using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    private Animator animator;

    private const string BREAKING_ANIMATION = "breaking";

    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite goldenPick;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startAnim()
    {
        animator.SetBool(BREAKING_ANIMATION, true);
    }

    public void stopAnim()
    {
        animator.SetBool(BREAKING_ANIMATION, false);
    }

    public void changeSprite()
    {
        spriteRenderer.sprite = goldenPick;
    }
}
