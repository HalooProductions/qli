using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Congratulate : MonoBehaviour {

    public Texture backgroundTexture;

    public Texture mainMenuButton;
    public Texture exitGameButton;

	// Use this for initialization
	void Start () {
	
	}

    void OnGUI ()
    {
        //Menun tausta
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        //Nappulat
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.55f, 200, Screen.height * .1f), mainMenuButton, ""))
        {
            SceneManager.LoadScene("MainMenu");
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height * 0.7f, 200, Screen.height * .1f), exitGameButton, ""))
        {
            Application.Quit();
        }
    }
}
