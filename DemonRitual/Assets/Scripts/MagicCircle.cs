using UnityEngine;
using System.Collections.Generic;

public class MagicCircle : MonoBehaviour
{
	public float radius;
	public GameObject testObject;

	private int numOfItems;
	public List <GameObject> items;

	// Use this for initialization
	void Start () 
	{
		numOfItems = 0;
		items = new List<GameObject>();
	}

	void AddToCircle(GameObject newItem) // Adds a component to the component list
	{	
		numOfItems++;
		items.Add(newItem);
		newItem.transform.parent = gameObject.transform;
		RepositionItems();


	}

	private void RepositionItems () // Puts the items in the circle
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

	void Update() {
		if (Input.GetKeyDown ("space"))
		{
			GameObject circleItem = Instantiate(testObject, new Vector3(0,0,0), Quaternion.identity) as GameObject;
			AddToCircle (circleItem);
		}

	}
}
