using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    GameObject[] inventory;

    int microorganismCount;

    int energy;

    int totalCoin;

    private const int MAX_MICROORGANISM = 3;

    public float speed = 5f;

    private Vector3 destination;

    private Animator animator;

    private const string RUNNING_ANIMATION = "running";

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);

        microorganismCount = 0;
        inventory = new GameObject[MAX_MICROORGANISM];
        energy = 20;
        totalCoin = 0;
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    private void movement()
    {

        if (Input.GetMouseButtonDown(0))
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            destination.z = transform.position.z;
        }

        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        animator.SetBool(RUNNING_ANIMATION, transform.position != destination);
    }

    public void changeEnergy(int amount)
    {
        energy = energy + amount;
        Debug.Log("energy = " + energy);
    }

    public int getEnergy()
    {
        return energy;
    }

    public void addCoin(int amount)
    {
        totalCoin = totalCoin + amount;
        Debug.Log("coin = " + totalCoin);
    }

    public void addMicroorganism(GameObject microorganism)
    {
        if(microorganismCount < MAX_MICROORGANISM)
        {
            inventory[microorganismCount] = microorganism;
            microorganismCount++;
        }
    }

    public bool inventoryFull()
    {
        return microorganismCount == MAX_MICROORGANISM;
    }

    public bool inventoryEmpty()
    {
        return microorganismCount == 0;
    }

    public GameObject[] getMicroorganisms()
    {
        return inventory;
    }

    public int getMicroorganismCount()
    {
        return microorganismCount;
    }

    public int getTotalCoin()
    {
        return totalCoin;
    }

    public void removeAllInventory()
    {
        for(int i = 0; i < microorganismCount; i++)
        {
            inventory[i] = null;
        }
        microorganismCount = 0;
    }
}
