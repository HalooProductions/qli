using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour {

    public AudioClip heroDeath;
    public AudioSource efxSource;
    public Texture backgroundTexture;

	public Texture NewGameButton;
	public Texture MainMenuButton;
	public Texture ExitGameButton;
	public Texture YouDied;
    public Texture RestartButton;

    private string previous = "";
    

    void Start () {
        efxSource = GetComponent<AudioSource>();
        previous = LevelManager.getLastLevel();
        PlaySingle(heroDeath);
    }

	void OnGUI () {
		//Menun tausta
		GUI.DrawTexture(new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		// You Died
		GUI.DrawTexture(new Rect(Screen.width / 2 - 120, Screen.height * 0.3f, 240, Screen.height * .1f), YouDied);
        //Menun nappulat
        if (GUI.Button(new Rect(Screen.width / 2 - 120, Screen.height * 0.44f, 240, Screen.height * .1f), RestartButton, ""))
        {
            SceneManager.LoadScene(previous);
        }
        if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * 0.55f, 200, Screen.height * .1f), NewGameButton, "")) 
		{
            SceneManager.LoadScene("PalloScene1");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * 0.65f, 200, Screen.height * .1f), MainMenuButton ,"")) 
		{
			SceneManager.LoadScene("MainMenu");
		}
		if (GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height * 0.75f, 200, Screen.height * .1f),ExitGameButton ,"")) 
		{
			Application.Quit();
		}
	}

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        efxSource.Play();
    }
}