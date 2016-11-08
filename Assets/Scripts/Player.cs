using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float speed;
    private Rigidbody2D rb2d;
    public int maxJumps;
    private int jumps;
    private int score;
    public bool facingRight = true;
    private GameObject gameOver;
    private GameObject scoreText;
    private bool canDash = true;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        jumps = 0;
        gameOver = GameObject.FindGameObjectWithTag("GameOver");
        gameOver.GetComponent<Text>().enabled = false;
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        score = 0;
        scoreText.GetComponent<Text>().text = "Score: 0";

    }
	
	// Update is called once per frame
	void Update () {
        rb2d.freezeRotation = true;
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

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Dash();
        }
        
	}

    void LateUpdate()
    {
        // Kamera seuraa pelaajaa
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);
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
        
        if (coll.gameObject.tag == "FallCollider")
        {
            GameOver();
        }

        if (coll.gameObject.tag == "ScoreObject")
        {
            UpdateScore(coll.gameObject);
        }

		if(coll.gameObject.tag == "Boulder")
		{
			GameOver();
		}

		if (coll.gameObject.tag == "Boulder")
		{
			GameOver();
		}
    }

	public void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "ScoreObject") 
		{
			UpdateScore (coll.gameObject);
		}

        if (coll.gameObject.tag == "Level2Port")
        {
            SceneManager.LoadScene("PalloScene2");
        }
	}
    
    public void GameOver()
    {
        Destroy(gameObject);
        gameOver.GetComponent<Text>().enabled = true;
    }

    public void UpdateScore(GameObject g)
    {
        Destroy(g);
        score++;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    private void Dash()
    {
        if (canDash)
        {
            speed = 24;
            canDash = false;
            StartCoroutine(EndDash());
        }
    }

    IEnumerator EndDash()
    {
        yield return new WaitForSeconds(1);
        speed = 12;
        StartCoroutine(RegenDash());
    }

    IEnumerator RegenDash()
    {
        yield return new WaitForSeconds(10);
        canDash = true;
    }
}
