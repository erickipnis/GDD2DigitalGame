using UnityEngine;
using System.Collections;
using System.IO;

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

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			position.x -= .1f;
			player.transform.position = position;
		} 
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			position.x += .1f;
			player.transform.position = position;
		}
		
		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			position.y += .1f;
			player.transform.position = position;
		}
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
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

			//Random score code
			GameObject score = GameObject.FindGameObjectWithTag("Score");
			TextMesh scoreTm = (TextMesh)score.GetComponent(typeof(TextMesh));
			scoreTm.text += 100;
		}
	}
}
