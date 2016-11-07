using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public Texture NewGameButton;
	public Texture MainMenuButton;
	public Texture ExitGameButton;
	public Texture YouDied;

	public float GUIPositionY1;
	public float GUIPositionY2;
	public float GUIPositionY3;
	public float GUIPositionY4;
	public float GUIPositionX1;
	public float GUIPositionX2;
	public float GUIPositionX3;
	public float GUIPositionX4;

	void OnGUI(){
		//Menun tausta
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		// You Died
		GUI.DrawTexture(new Rect(Screen.width * GUIPositionX4, Screen.height * GUIPositionY4, Screen.width * .5f, Screen.height * .1f), YouDied);
		//Menun nappulat
		if (GUI.Button (new Rect (Screen.width * GUIPositionX1, Screen.height * GUIPositionY1, Screen.width * .5f, Screen.height * .1f), NewGameButton, "")) 
		{
			Application.LoadLevel (2);
		}
		if (GUI.Button (new Rect (Screen.width * GUIPositionX2, Screen.height * GUIPositionY2, Screen.width * .5f, Screen.height * .1f), MainMenuButton ,"")) 
		{
			Application.LoadLevel (0);
		}
		if (GUI.Button (new Rect (Screen.width * GUIPositionX3, Screen.height * GUIPositionY3, Screen.width * .5f, Screen.height * .1f),ExitGameButton ,"")) 
		{
			Application.Quit ();
		}
	}
}