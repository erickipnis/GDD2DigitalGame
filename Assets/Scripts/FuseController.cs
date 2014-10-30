using UnityEngine;
using System.Collections;
using System.IO;

public class FuseController : MonoBehaviour {

	GameObject fuse;
	int state = 3;
	
	void Start () {
		fuse = GameObject.FindGameObjectWithTag("Fuse");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = fuse.transform.position;

		if(Application.loadedLevelName == "Level1")
		{
			if(state == 0)
			{
				position.y += .02f;
			}
			if(state == 1)
			{
				position.y -= .02f;
			}
			if(state == 2)
			{
				position.x -= .02f;
			}
			if(state == 3)
			{
				position.x += .02f;
			}
		}

		if(Application.loadedLevelName == "Level2")
		{
			if(state == 0)
			{
				position.y += .0195f;
			}
			if(state == 1)
			{
				position.y -= .0195f;
			}
			if(state == 2)
			{
				position.x -= .0195f;
			}
			if(state == 3)
			{
				position.x += .0195f;
			}
		}

		if(Application.loadedLevelName == "Level3")
		{
			if(state == 0)
			{
				position.y += .035f;
			}
			if(state == 1)
			{
				position.y -= .035f;
			}
			if(state == 2)
			{
				position.x -= .035f;
			}
			if(state == 3)
			{
				position.x += .035f;
			}

		}
		if(Application.loadedLevelName == "Level4")
		{
			if(state == 0)
			{
				position.y += .01f;
			}
			if(state == 1)
			{
				position.y -= .01f;
			}
			if(state == 2)
			{
				position.x -= .01f;
			}
			if(state == 3)
			{
				position.x += .01f;
			}
			
		}

			
		fuse.transform.position = position;

		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "TNT")
		{
			Destroy(coll.gameObject);
			Destroy(this.gameObject);
			Application.LoadLevel("GameOver");
		}
		if(coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Door")
		{
			Physics2D.IgnoreCollision(this.collider2D, coll.gameObject.collider2D, true);

		}
		if(coll.gameObject.tag == "GoUp")
		{
			state = 0; 
		}
		if(coll.gameObject.tag == "GoDown")
		{
			state = 1; 
		}
		if(coll.gameObject.tag == "GoLeft")
		{
			state = 2; 
		}
		if(coll.gameObject.tag == "GoRight")
		{
			state = 3; 
		}
	}
}
