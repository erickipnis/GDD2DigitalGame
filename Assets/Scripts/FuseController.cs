using UnityEngine;
using System.Collections;

public class FuseController : MonoBehaviour {

	GameObject fuse;
	
	void Start () {
		fuse = GameObject.FindGameObjectWithTag("Fuse");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = fuse.transform.position;

		position.x += .1f;

		fuse.transform.position = position;
	}
}
