using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float minY, maxY;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();   
    }

    private void LateUpdate()
    {
        
    }

    private void moveCamera()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        transform.position += new Vector3(0, scroll * speed, 0);

        Vector3 position = transform.position;
        position.y = Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
