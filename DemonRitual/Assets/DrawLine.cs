using UnityEngine;
using System.Collections;

public class DrawLine : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public LineRenderer renderer;

	void Update () {
		renderer.SetWidth(0.2F, 0.2F);
		renderer.SetPosition(0, player1.transform.position);
		renderer.SetPosition(1, player2.transform.position);
	}
}
