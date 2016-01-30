using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour
{
	public float maxWanderRange;
	public float movementSpeed;
	public float timeForAlphaChange;

	private Vector3 initialPosition;
	private float angle;
	private float timer;

	// Use this for initialization
	void Start ()
	{
		initialPosition = transform.position;
		timer = 0;
		angle = Random.Range(0, 2*Mathf.PI);
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > timeForAlphaChange)
			timer = 0;

		float alphaAmount = .7f * Mathf.Sin(2 * Mathf.PI * (timer / timeForAlphaChange)) + .3f;
		GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, alphaAmount); ;

		Vector3 velocity = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0);
		transform.position += velocity * movementSpeed * Time.deltaTime;

		if (Vector3.Distance(transform.position, initialPosition) > maxWanderRange)
			ChangeDirection();
	}

	private void ChangeDirection ()
	{
		angle = angle + Mathf.PI + Random.Range(-Mathf.PI/6, Mathf.PI / 6);
	}
}
