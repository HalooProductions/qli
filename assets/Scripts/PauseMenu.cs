using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public Texture backgroundImage;
    public Texture pausedImage;
    public Texture resumeButton;
    public Texture restartButton;
    public Texture mainMenuButton;
    public Texture levelSelectButton;

    public Texture lvl1Button;
    public Texture lvl2Button;
    public Texture lvl3Button;
    public Texture lvl4Button;
    public Texture lvl5Button;
    public Texture backButton;

    public bool isPaused = false;
    public bool lvlSelect = false;

    public GameObject pauseMenuCanvas;
    public GameObject levelSelectCanvas;

    public float GUIPositionY1;
    public float GUIPositionY2;
    public float GUIPositionY3;
    public float GUIPositionY4;

    // Use this for initialization
    void Start () {
        levelSelectCanvas.gameObject.SetActive(false);
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
        if (lvlSelect == false)
        {
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

            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height * GUIPositionY3, 250, Screen.height * .1f), levelSelectButton, "") && isPaused)
            {
                lvlSelect = true;
                pauseMenuCanvas.gameObject.SetActive(false);
                levelSelectCanvas.gameObject.SetActive(true);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height * 0.9f, 250, Screen.height * .1f), mainMenuButton, ""))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("MainMenu");
            }
        }
        else if (lvlSelect == true)
        {
            // Menun tausta
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundImage);
            // Level nappulat
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.3f, 200, Screen.height * .1f), lvl1Button, ""))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("PalloScene1");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.45f, 200, Screen.height * .1f), lvl2Button, ""))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("PalloScene2");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.6f, 200, Screen.height * .1f), lvl3Button, ""))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("PalloScene3");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.75f, 200, Screen.height * .1f), lvl4Button, ""))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("PalloScene4");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.9f, 200, Screen.height * .1f), lvl5Button, ""))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene("PalloScene5");
            }
            if (GUI.Button(new Rect(Screen.width / 2 + 300, Screen.height * 0.9f, 200, Screen.height * .1f), backButton, ""))
            {
                lvlSelect = false;
                levelSelectCanvas.gameObject.SetActive(false);
                pauseMenuCanvas.gameObject.SetActive(true);
            }
        }
    }
}
