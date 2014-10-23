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

			//Score code
			GameObject score = GameObject.FindGameObjectWithTag("Score");
			TextMesh scoreTm = (TextMesh)score.GetComponent(typeof(TextMesh));

			//Get distance between fuse and TNT
			Vector3 fusePos = coll.gameObject.transform.position;
			GameObject tnt = GameObject.FindGameObjectWithTag("TNT");
			Vector3 tntPos = tnt.transform.position;
			float distance = Vector3.Distance(fusePos, tntPos);

			//Change score based on distance
			int scoreInt = 0;

			if(distance >= 20)
			{
				scoreInt = 500;
			}
			else if (distance < 20 && distance > 10)
			{
				scoreInt = 250;
			}
			else
			{
				scoreInt = 100;
			}

			scoreTm.text = scoreInt.ToString();

			if (Levels.levelNum != Levels.totalLevels)
			{
				Levels.levelNum++;
			}
			else
			{
				Levels.levelNum = 1;
			}

			Application.LoadLevel("Level" + Levels.levelNum);
		}
		if(coll.gameObject.tag == "GoUp" || coll.gameObject.tag == "GoDown" || coll.gameObject.tag == "GoLeft" || coll.gameObject.tag == "GoRight")
		{
			Physics2D.IgnoreCollision(this.collider2D, coll.gameObject.collider2D, true);
		}
	}
}
