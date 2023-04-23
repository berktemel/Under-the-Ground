using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextOnScreen : MonoBehaviour
{
    
    public TextMeshPro tmp;

    private void Awake()
    {
        tmp = GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setText(string text)
    {
        tmp.SetText(text);
    }
}
