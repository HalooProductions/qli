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
    private GameObject scoreText;
	private bool GameOverStatus;
    private float dashMeter = 1f;
    private bool canRegenDash = false;
    float barDisplay = 0;
    Vector2 pos = new Vector2(10, 40);
    Vector2 size = new Vector2(60, 20);
    Texture2D progressBarEmpty;
    Texture2D progressBarFull;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        jumps = 0;
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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (dashMeter > 0f)
            {
                speed = 24;
                dashMeter -= 0.05f;
            }
            else
            {
                speed = 12;
                canRegenDash = true;
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 12;
            canRegenDash = true;
        }
    }

    void LateUpdate()
    {
        // Kamera seuraa pelaajaa
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);

        if (dashMeter < 1f && canRegenDash)
        {
            dashMeter += 0.005f;
        }
        else if (dashMeter >= 1f)
        {
            canRegenDash = false;
        }
    }

    void Awake()
    {
        // LevelManager tallentaa levelin
        LevelManager.setLastLevel(SceneManager.GetActiveScene().name);
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
				
        if (coll.gameObject.tag == "Level3Port")
        {
            SceneManager.LoadScene("PalloScene3");
        }
	
        if (coll.gameObject.tag == "Level4Port")
        {
            SceneManager.LoadScene("PalloScene4");
        }

        if (coll.gameObject.tag == "Key")
        {
            Destroy(GameObject.FindWithTag("Gate"));
            Destroy(GameObject.FindWithTag("Key"));
        }
    }

    public void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Water")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb2d.AddForce(new Vector2(0, -35f));
            }
		}

    }
    
    public void GameOver()
    {
		SceneManager.LoadScene("GameOverMenu");
    }

    public void UpdateScore(GameObject g)
    {
        Destroy(g);
        score++;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    public void OnGUI()
    {
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarEmpty);

        // draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * dashMeter, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), progressBarFull);
        GUI.EndGroup();

        GUI.EndGroup();
    }
}
