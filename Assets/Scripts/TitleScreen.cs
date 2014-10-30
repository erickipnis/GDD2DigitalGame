using UnityEngine;
//using UnityEditor;

public class TitleScreen : MonoBehaviour
{
	private GUISkin skin;
	
	void Start()
	{
		skin = Resources.Load("TitleGUI") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 200;
		const int instrButtonWidth = 400;
		const int buttonHeight = 65;

		GUI.skin = skin;

		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2), buttonWidth, buttonHeight), "START"))
		{
			Levels.totalScore = 0;
			Application.LoadLevel("Level1");

		}

		if (GUI.Button(new Rect(Screen.width / 2 - (instrButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2) + 80, instrButtonWidth, buttonHeight), "HOW TO PLAY"))
		{
			Levels.totalScore = 0;

			Application.LoadLevel("Instructions");
		}
	}
}