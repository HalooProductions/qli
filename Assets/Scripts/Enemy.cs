using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public bool facingRight = true;
    public float speed;
    private float x;


	// Use this for initialization
	void Start () {
        x = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        x = 1;
        x *= speed;
        x *= Time.deltaTime;
	    if (!facingRight)
        {
            x *= -1;
        }
        transform.Translate(x, 0, 0);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "TurnAround" && facingRight)
        {
            TurnAround(0);
        }
        else if (coll.gameObject.tag == "TurnAround" && !facingRight)
        {
            TurnAround(1);
        }
    }

    public void TurnAround(int y)
    {
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
