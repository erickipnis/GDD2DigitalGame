using UnityEngine;

public class Instructions : MonoBehaviour
{
	private GUISkin skin;
	
	void Start()
	{
		skin = Resources.Load("TitleGUI") as GUISkin;
	}
	
	void OnGUI()
	{
		const int buttonWidth = 200;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), Screen.height - 80, buttonWidth, buttonHeight), "PLAY"))
		{
			Application.LoadLevel("Level1");
		}
	}
}