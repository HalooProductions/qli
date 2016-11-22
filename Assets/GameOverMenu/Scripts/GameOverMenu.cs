using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public Texture NewGameButton;
	public Texture MainMenuButton;
	public Texture ExitGameButton;
	public Texture YouDied;
    public Texture ContinueButton;

	public float GUIPositionY1;
	public float GUIPositionY2;
	public float GUIPositionY3;
	public float GUIPositionY4;
    public float GUIPositionY5;

    public float GUIPositionX1;
	public float GUIPositionX2;
	public float GUIPositionX3;
	public float GUIPositionX4;
    public float GUIPositionX5;

    private string previous = "";
    

    void Start () {
        previous = LevelManager.getLastLevel();
    }

	void OnGUI () {
		//Menun tausta
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		// You Died
		GUI.DrawTexture(new Rect(Screen.width * GUIPositionX4, Screen.height * GUIPositionY4, Screen.width * .3f, Screen.height * .1f), YouDied);
        //Menun nappulat
        if (GUI.Button(new Rect(Screen.width * GUIPositionX5, Screen.height * GUIPositionY5, Screen.width * .5f, Screen.height * .1f), ContinueButton, ""))
        {
            SceneManager.LoadScene(previous);
        }
        if (GUI.Button (new Rect (Screen.width * GUIPositionX1, Screen.height * GUIPositionY1, Screen.width * .5f, Screen.height * .1f), NewGameButton, "")) 
		{
            SceneManager.LoadScene("PalloScene1");
		}
		if (GUI.Button (new Rect (Screen.width * GUIPositionX2, Screen.height * GUIPositionY2, Screen.width * .5f, Screen.height * .1f), MainMenuButton ,"")) 
		{
			SceneManager.LoadScene("MainMenu");
		}
		if (GUI.Button (new Rect (Screen.width * GUIPositionX3, Screen.height * GUIPositionY3, Screen.width * .5f, Screen.height * .1f),ExitGameButton ,"")) 
		{
			Application.Quit();
		}
	}
}