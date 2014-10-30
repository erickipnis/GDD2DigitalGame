using UnityEngine;
using System.Collections;
using System.IO;
//using UnityEditor;

public class PlayerController : MonoBehaviour 
{
	GameObject player;

	private Animator anim;

	GameObject score;

	bool unlock = false;

	bool boostItUp = false;

	float speed = 0.1f;

	int addTo = 0;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");

		anim = player.GetComponent<Animator>();

		score = GameObject.FindGameObjectWithTag("Score");

		DontDestroyOnLoad(score);

	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 position = player.transform.position;

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			position.y += speed;
			player.transform.position = position;
			
			//anim.enabled = true;
			
			if(player.transform.rotation != Quaternion.Euler(0, 0, 0))
			{
				player.transform.rotation = Quaternion.Euler(0, 0, 0);
			}

			anim.enabled = true;

		}
		else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			position.y -= speed;
			player.transform.position = position;

			if(player.transform.rotation != Quaternion.Euler(0, 0, 180))
			{
				player.transform.rotation = Quaternion.Euler(0, 0, 180);
			}

			anim.enabled = true;
		}

		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			position.x -= speed;
			player.transform.position = position;
			
			//anim.enabled = true;
			
			if(player.transform.rotation != Quaternion.Euler(0, 0, 90))
			{
				player.transform.rotation = Quaternion.Euler(0, 0, 90);
			}
			
			anim.enabled = true;
		} 
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) 
		{
			position.x += speed;
			player.transform.position = position;
			
			//anim.enabled = true;
			
			if(player.transform.rotation != Quaternion.Euler(0, 0, 270))
			{
				player.transform.rotation = Quaternion.Euler(0, 0, 270);
			}
			
			anim.enabled = true;
		}

		if(Input.anyKey == false)
		{
				anim.enabled = false;
		}

		if(boostItUp)
		{
			if(addTo == 250)
			{
				boostItUp = false;
				addTo = 0;
			}
			
			speed = 0.2f;
			
			addTo++;
		}
		if(boostItUp == false)
		{
			speed = 0.1f;
		}

	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Fuse")
		{
			Destroy(coll.gameObject);

			//Score code

			TextMesh scoreTm = (TextMesh)score.GetComponent(typeof(TextMesh));

			//Get distance between fuse and TNT
			Vector3 fusePos = coll.gameObject.transform.position;
			GameObject tnt = GameObject.FindGameObjectWithTag("TNT");
			Vector3 tntPos = tnt.transform.position;
			float distance = Vector3.Distance(fusePos, tntPos);

			if(Application.loadedLevelName == "Level1")
			{
				Levels.totalScore = 0;
			}


			if(distance >= 20)
			{
				Levels.totalScore+= 500;
			}
			else if (distance < 20 && distance > 10)
			{
				Levels.totalScore+= 250;
			}
			else
			{
				Levels.totalScore+= 250;
			}

			scoreTm.text = Levels.totalScore.ToString();


			if (Levels.levelNum != Levels.totalLevels)
			{
				Levels.levelNum++;

				Application.LoadLevel("Level" + Levels.levelNum);
			}
			else
			{
				Application.LoadLevel("Titlescreen");
				Levels.levelNum = 1;
			}


		}
		if(coll.gameObject.tag == "GoUp" || coll.gameObject.tag == "GoDown" || coll.gameObject.tag == "GoLeft" || coll.gameObject.tag == "GoRight")
		{
			Physics2D.IgnoreCollision(this.collider2D, coll.gameObject.collider2D, true);
		}
		if(coll.gameObject.tag == "Locked")
		{
			if(unlock)
			{
				Destroy(coll.gameObject);
			}

		}
		if(coll.gameObject.tag == "Key")
		{
			Destroy(coll.gameObject);
			unlock = true;
		}
		if(coll.gameObject.tag == "Booster")
		{
			if(boostItUp)
			{
				//Physics2D.IgnoreCollision(this.collider2D, coll.gameObject.collider2D, true);

				coll.gameObject.collider.enabled = false;
			}
			else
			{
				boostItUp = true;
				Destroy(coll.gameObject);
			}

			coll.gameObject.collider.enabled = true;
		}
	}

}
