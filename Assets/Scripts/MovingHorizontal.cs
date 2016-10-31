using UnityEngine;
using System.Collections;

public class MovingHorizontal : MonoBehaviour
{
    private float speed;
    public float dirSpeed = 9.0f;
    float origX;
    public float distance = 8.0f;
    // Use this for initialization
    void Start()
    {
        origX = transform.position.x;
        speed = -dirSpeed;
    }

    // Update is called once per frame
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

    void OnCollisionStay2D(Collision2D coll) {
        // Jos pelaaja katsoo vasemmalle, tarvitsee kertoa -1.
        if (coll.gameObject.tag == "Player")
        {
            Player player = coll.gameObject.GetComponent<Player>();

            if (player.facingRight)
            {
                player.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            
            else 
            {
                player.transform.Translate((speed * Time.deltaTime) * -1, 0, 0);
            }
        }
        else
        {
            coll.gameObject.transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
}
