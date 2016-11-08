using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	public Texture PlayGameButton;
	public Texture ExitGameButton;

	public float GUIPositionY1;
	public float GUIPositionY2;
	public float GUIPositionX1;
	public float GUIPositionX2;

	void OnGUI(){
		//Menun tausta
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		//Menun nappulat
		if (GUI.Button (new Rect (Screen.width * GUIPositionX1, Screen.height * GUIPositionY1, Screen.width * .5f, Screen.height * .1f), PlayGameButton, "")) 
		{
			Application.LoadLevel (2);
		}
		if (GUI.Button (new Rect (Screen.width * GUIPositionX2, Screen.height * GUIPositionY2, Screen.width * .5f, Screen.height * .1f),ExitGameButton ,"")) 
		{
			Application.Quit ();
		}

	}
}
