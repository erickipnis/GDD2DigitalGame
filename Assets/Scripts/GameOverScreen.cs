using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	
	private GUISkin skin;
	
	void Start()
	{
		skin = Resources.Load("TitleGUI") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 350;
		const int instrButtonWidth = 500;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2)+60, buttonWidth, buttonHeight), "Play Again?"))
		{
			Application.LoadLevel("Level" + Levels.levelNum);
		}
		
		if (GUI.Button(new Rect(Screen.width / 2 - (instrButtonWidth / 2), (2 * Screen.height / 3) - (buttonHeight / 2) + 140, instrButtonWidth, buttonHeight), "Return to Menu"))
		{
			Application.LoadLevel("TitleScreen");
		}
	}
}
