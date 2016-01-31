using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	public GameObject followingPlayer;

	void Update ()
	{
		transform.position = new Vector3(followingPlayer.transform.position.x, followingPlayer.transform.position.y, -10);
	}
}
