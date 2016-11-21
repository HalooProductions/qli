using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public bool facingRight = true;
    public float speed;
    private float x;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start () {
        x = 1;
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb2d.freezeRotation = true;
        x = 1;
        x *= speed;
        x *= Time.deltaTime;
        transform.Translate(new Vector3(x, 0, 0));
    }

    public void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "TurnAround" && facingRight)
        {
            TurnAround(0);
        }
        else if (coll.gameObject.tag == "TurnAround" && !facingRight)
        {
            TurnAround(1);
        }
    }

    public void TurnAround(int y) {
        if(y == 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            facingRight = false;
        }
        else if(y == 1)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
           transform.localScale = theScale;
            facingRight = true;
        }
    }
}
