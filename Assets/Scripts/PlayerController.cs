using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	GameObject player;
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 position = player.transform.position;

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			position.x -= .1f;
			player.transform.position = position;
		} 
		else if (Input.GetKey(KeyCode.RightArrow)) 
		{
			position.x += .1f;
			player.transform.position = position;
		}
		
		if (Input.GetKey(KeyCode.UpArrow))
		{
			position.y += .1f;
			player.transform.position = position;
		}
		else if(Input.GetKey(KeyCode.DownArrow))
		{
			position.y -= .1f;
			player.transform.position = position;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Fuse")
		{
			Destroy(coll.gameObject);
		}
	}
}
