using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    public int maxJumps;
    public int jumps;
    private bool facingRight = true;



	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        jumps = 0;  
	}
	
	// Update is called once per frame
	void Update () {
        rb2d.freezeRotation = true;
        // Kamera seuraa pelaajaa
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
        // Liikkuminen
        float x = Input.GetAxis("Horizontal");
        x *= speed;
        x *= Time.deltaTime;
        if(!facingRight)
        {
            x *= -1;
        }
        transform.Translate(new Vector3(x, 0, 0));

        if (Input.GetKeyDown(KeyCode.LeftArrow) && facingRight)
        {
            facingRight = false;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale; 
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) && !facingRight)
        {
            facingRight = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps)
        {
            jumps++;
            Jump();
        }
	}

    public void Jump()
    {
        rb2d.AddForce(new Vector2(0, 300f));
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            jumps = 0;
        }
    }
}
