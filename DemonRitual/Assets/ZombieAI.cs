using UnityEngine;
using System.Collections;

public class ZombieAI : MonoBehaviour
{
	public float movementSpeed;
	public float aggroRange;

	private Vector3 originalPosition;
	private GameObject target;

	void Start ()
	{
	
	}
	
	void Update ()
	{
		if (target)
		{
			Vector3 direction = target.transform.position - transform.position;
			Vector3 velocity = direction.normalized * movementSpeed;
			GetComponent<Rigidbody2D>().velocity = velocity;
		}
		else
		{
			Vector3 direction = originalPosition - transform.position;
			Vector3 velocity = direction.normalized * movementSpeed;
			GetComponent<Rigidbody2D>().velocity = velocity;

			GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
			GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
			float dist1 = Vector3.Distance(player1.transform.position, transform.position);
			float dist2 = Vector3.Distance(player1.transform.position, transform.position);

			if (dist1 < aggroRange)
			{
				if (dist2 < aggroRange)
					target = dist1 < dist2 ? player1 : player2;
				else
					target = player1;
			}
			else if (dist2 < aggroRange)
				target = player2;
			else
				target = null;
		}
	}
}
