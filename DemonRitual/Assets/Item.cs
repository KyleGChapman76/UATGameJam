using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	private bool player1Touching;
	private bool player2Touching;

	private void Update ()
    {
        if (Input.GetButtonDown("Special1") && player1Touching)
        {
			Destroy(gameObject);
		} else if (Input.GetButtonDown("Special2") && player2Touching)
        {
			Destroy(gameObject);
		}
    }

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Equals("Player1"))
		{
			player1Touching = true;
		}
		else if (other.tag.Equals("Player2"))
		{
			player2Touching = true;
		}
	}

	private void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag.Equals("Player1"))
		{
			player1Touching = false;
		}
		else if (other.tag.Equals("Player2"))
		{
			player2Touching = false;
		}
	}
}
