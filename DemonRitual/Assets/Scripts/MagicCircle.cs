using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class MagicCircle : MonoBehaviour
{
	public float radius; //Size of the circle
	public List <GameObject> items; //List of items in the circle
	public bool player1;

	private int numOfItems; //Number of items in the circle
	private bool player1Touching;
	private bool player2Touching;

	void Start () 
	{
		numOfItems = 0;
		items = new List<GameObject>(); // Creates a list that stores all the items in the circle. 

	}

	void AddToCircle(GameObject newItem) // Adds a component to the component list.
	{	
		numOfItems++;
		items.Add(newItem);
		newItem.transform.parent = gameObject.transform;
		RepositionItems();


	}

	private void RepositionItems () // Puts the items in the circle.
	{
		float angle = 2*(Mathf.PI)/numOfItems;
		float posAngle = Mathf.PI/2;
		for(int i = 0; i < numOfItems; i++)
		{
			float posX = Mathf.Cos (posAngle)*radius;
			float posY = Mathf.Sin (posAngle)*radius;

			items[i].transform.localPosition = new Vector3 (posX, posY, 0);

			posAngle += angle; 

		}
	}

	private void Update ()
	{
		if (Input.GetButtonDown("Special1") && player1Touching && GameObject.FindWithTag("Player1").GetComponent<PlayerController>().carriedItem && player1)
		{
			GameObject newObject = GameObject.FindWithTag("Player1").GetComponent<PlayerController>().carriedItem;
			GameObject.FindWithTag ("Player1").GetComponent<PlayerController> ().carriedItem = null;
			newObject.transform.parent = gameObject.transform;
			newObject.SetActive (true);
			Destroy (newObject.GetComponent<CircleCollider2D> ());
			AddToCircle (newObject);
	
		} 
		else if (Input.GetButtonDown("Special2") && player2Touching && GameObject.FindWithTag("Player2").GetComponent<PlayerController>().carriedItem && !player1)
		{
			GameObject newObject = GameObject.FindWithTag("Player2").GetComponent<PlayerController>().carriedItem;
			GameObject.FindWithTag ("Player2").GetComponent<PlayerController> ().carriedItem = null;
			newObject.transform.parent = gameObject.transform;
			newObject.SetActive (true);
			Destroy (newObject.GetComponent<CircleCollider2D> ());
			AddToCircle (newObject);
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
