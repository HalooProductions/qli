using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Texture backgroundImage;
    public Texture pausedImage;
    public Texture resumeButton;
    public Texture restartButton;
    public Texture mainMenuButton;

    public bool isPaused = false;

    public GameObject pauseMenuCanvas;

    public float GUIPositionY1;
    public float GUIPositionY2;
    public float GUIPositionY3;
    public float GUIPositionY4;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused == true)
            {
                Time.timeScale = 1.0f;
                pauseMenuCanvas.gameObject.SetActive(false);
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0.0f;
                pauseMenuCanvas.gameObject.SetActive(true);
                isPaused = true;
            }
        }
	}

    void OnGUI()
    {
        if(isPaused == false)
        {
            return;
        }
        // Menun tausta
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);
        // Paused
        GUI.DrawTexture(new Rect(Screen.width / 2 - 100, Screen.height * GUIPositionY4, 200, Screen.height * .1f), pausedImage);
        // Nappulat
        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height * GUIPositionY1, 250, Screen.height * .1f), resumeButton, ""))
        {
            isPaused = false;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height * GUIPositionY2, 250, Screen.height * .1f), restartButton, ""))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            isPaused = false;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height * GUIPositionY3, 250, Screen.height * .1f), mainMenuButton, ""))
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
