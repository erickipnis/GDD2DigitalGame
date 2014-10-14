using UnityEngine;
using System.Collections;
using System.IO;

public class FuseController : MonoBehaviour {

	GameObject fuse;
	
	void Start () {
		fuse = GameObject.FindGameObjectWithTag("Fuse");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = fuse.transform.position;

		position.x += .05f;

		fuse.transform.position = position;

		
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "TNT")
		{
			Destroy(coll.gameObject);
			Destroy(this.gameObject);
		}
	}
}
