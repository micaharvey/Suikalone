using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject player;
    public int speed;
    public Transform fruitDropLocation;
    public Transform nextFruitLocation;
    public Transform boardFruit;
    public GameObject cherry;
    public GameObject strawberry;
    public GameObject grape;
    public GameObject satsuma;
    public GameObject persimmon;
    public GameObject apple;
    public GameObject pear;


    // Don't touch my private parts
    private GameObject currentFruit;
    private GameObject nextFruit;


    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Spawn our first fruits
        currentFruit = Instantiate(cherry, fruitDropLocation);
        nextFruit = Instantiate(cherry, nextFruitLocation);
    }

    // Update is called once per frame
    void Update()
    {
        // Move left
        if (Input.GetKey(KeyCode.A) && transform.position.x >= -1.27)
        {
            player.transform.Translate(Vector3.left * Time.deltaTime * speed, Camera.main.transform);
        }

        // Move right
        if (Input.GetKey(KeyCode.D) && transform.position.x <= 2.2)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * speed, Camera.main.transform);
        }

        // Drop fruit
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            // switch parent
            currentFruit.transform.SetParent(boardFruit);

            // jump down hack if needed
            // currentFruit.transform.Translate(Vector3.down * 0.1f, Camera.main.transform);

            // turn on collision and modify rigid body
            Rigidbody2D body = currentFruit.gameObject.GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Dynamic;

            CircleCollider2D collider = currentFruit.gameObject.GetComponent<CircleCollider2D>();
            collider.enabled = true;

            // create a set of new fruits
            currentFruit = nextFruit;
            currentFruit.transform.SetPositionAndRotation(fruitDropLocation.transform.position, currentFruit.transform.rotation);
            currentFruit.transform.SetParent(fruitDropLocation);

            int fruitNumber = Random.Range(0, 5);
            switch (fruitNumber)
            {
                case 0: { nextFruit = Instantiate(cherry, nextFruitLocation); break; }
                case 1: { nextFruit = Instantiate(strawberry, nextFruitLocation); break; }
                case 2: { nextFruit = Instantiate(grape, nextFruitLocation); break; }
                case 3: { nextFruit = Instantiate(satsuma, nextFruitLocation); break; }
                case 4: { nextFruit = Instantiate(persimmon, nextFruitLocation); break; }
                default: { nextFruit = Instantiate(cherry, nextFruitLocation); break; }
            }

        }
    }
}
