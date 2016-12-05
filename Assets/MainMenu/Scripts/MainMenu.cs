using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public Texture PlayGameButton;
	public Texture ExitGameButton;
    public Texture levelSelectButton;

    public Texture lvl1Button;
    public Texture lvl2Button;
    public Texture lvl3Button;
    public Texture lvl4Button;
    public Texture lvl5Button;
    public Texture backButton;

    public GameObject levelSelectCanvas;

    public bool lvlSelect = false;

	public float GUIPositionY1;
	public float GUIPositionY2;
	public float GUIPositionX1;
	public float GUIPositionX2;

    void Start ()
    {
        levelSelectCanvas.gameObject.SetActive(false);
    }

	void OnGUI(){
        if(lvlSelect == false)
        {
            //Menun tausta
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
            //Menun nappulat
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * GUIPositionY1, 200, Screen.height * .1f), PlayGameButton, ""))
            {
                SceneManager.LoadScene("PalloScene1");
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 125, Screen.height * GUIPositionY2, 250, Screen.height * .1f), levelSelectButton, ""))
            {
                lvlSelect = true;
                levelSelectCanvas.gameObject.SetActive(true);
            }
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.72f, 200, Screen.height * .1f), ExitGameButton, ""))
            {
                Application.Quit();
            }
        }
        else if (lvlSelect == true)
        {
            // Menun tausta
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
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
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
