using UnityEngine;
using System.Collections;

public class MovingHorizontal : MonoBehaviour
{
    private float speed;
    public float dirSpeed = 9.0f;
    float origX;
    public float distance = 8.0f;
    private Transform playerOriginalTransform;
    // Use this for initialization
    void Start()
    {
        origX = transform.position.x;
        speed = -dirSpeed;
    }

    void Update()
    {
        if (origX - transform.position.x > distance)
        {
            speed = dirSpeed;
        }
        else if (origX - transform.position.x < -distance)
        {
            speed = -dirSpeed;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.gameObject.GetComponent<Player>();
            playerOriginalTransform = player.transform.parent;
        }
    }

    void OnCollisionStay2D(Collision2D coll) {
        // Jos pelaaja katsoo vasemmalle, tarvitsee kertoa -1.
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.transform.parent = transform;
        }
        else
        {
            coll.gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionExit2D(Collision2D coll) {
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.gameObject.GetComponent<Player>();
            player.transform.parent = playerOriginalTransform;
        }
    }
}
