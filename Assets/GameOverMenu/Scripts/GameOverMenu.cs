using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public Texture NewGameButton;
	public Texture MainMenuButton;
	public Texture ExitGameButton;
	public Texture YouDied;
    public Texture RestartButton;

	public float GUIPositionY1;
	public float GUIPositionY2;
	public float GUIPositionY3;
	public float GUIPositionY4;
    public float GUIPositionY5;

    private string previous = "";
    

    void Start () {
        previous = LevelManager.getLastLevel();
    }

	void OnGUI () {
		//Menun tausta
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		// You Died
		GUI.DrawTexture(new Rect(Screen.width / 2 - 120, Screen.height * GUIPositionY4, 240, Screen.height * .1f), YouDied);
        //Menun nappulat
        if (GUI.Button(new Rect(Screen.width / 2 - 120, Screen.height * GUIPositionY5, 240, Screen.height * .1f), RestartButton, ""))
        {
            SceneManager.LoadScene(previous);
        }
        if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * GUIPositionY1, 200, Screen.height * .1f), NewGameButton, "")) 
		{
            SceneManager.LoadScene("PalloScene1");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * GUIPositionY2, 200, Screen.height * .1f), MainMenuButton ,"")) 
		{
			SceneManager.LoadScene("MainMenu");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * GUIPositionY3, 200, Screen.height * .1f),ExitGameButton ,"")) 
		{
			Application.Quit();
		}
	}
}