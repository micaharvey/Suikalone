using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject evolutionFruit;
    // public Transform boardFruit;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Substring(0, 4) == gameObject.name.Substring(0, 4))
        {
            Debug.Log("Collision: " + gameObject.transform.GetSiblingIndex());

            // decide who is handling this
            if (collision.gameObject.transform.GetSiblingIndex() < gameObject.transform.GetSiblingIndex()) return;

            Debug.Log("Collision: " + gameObject.transform.GetSiblingIndex());

            // make new fruit
            Transform location = gameObject.transform;
            GameObject newFruit = Instantiate(evolutionFruit, location.position, location.rotation, null);
            newFruit.transform.position.Set(location.position.x, location.position.y, location.position.z);
            newFruit.transform.SetParent(GameObject.FindGameObjectWithTag("FruitTracker").transform);

            // turn on collision and modify rigid body
            Rigidbody2D body = newFruit.gameObject.GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Dynamic;
            CircleCollider2D collider = newFruit.gameObject.GetComponent<CircleCollider2D>();
            collider.enabled = true;

            // destroy old fruits
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

}