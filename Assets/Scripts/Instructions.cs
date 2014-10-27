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
		const int buttonWidth = 450;
		const int buttonHeight = 65;
		
		GUI.skin = skin;
		
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2), Screen.height - 80, buttonWidth, buttonHeight), "Return to Title"))
		{
			Application.LoadLevel("TitleScreen");
		}
	}
}