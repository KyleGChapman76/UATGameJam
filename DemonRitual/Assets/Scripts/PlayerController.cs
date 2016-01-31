using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public bool player1; //if this player is player1 or not
	public GameObject carriedItem; //which item the player is carrying

    private void Update ()
    {
        //get the input for each player
        float inputX = Input.GetAxis("Horizontal" + (player1 ? 1 : 2));
        float inputY = Input.GetAxis("Vertical" + (player1 ? 1 : 2));

        //reduce the players total input to avoid making diagonal velocities faster than straight ones
        float movementReduction = 1f;
        if (Mathf.Abs(inputX) > 0 && Mathf.Abs(inputY) > 0)
            movementReduction = .707f;

        //calculate the players new velocity
        float velX = inputX * movementSpeed * movementReduction;
        float velY = inputY * movementSpeed * movementReduction;

        //set the players velocity and reset any rotation (kindof hackish)
        GetComponent<Rigidbody2D>().velocity = new Vector2(velX, velY);
       
		if (Mathf.Abs (inputX) != 0 && Mathf.Abs(inputY) != 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, Mathf.Atan2 (inputY,inputX) * 180/Mathf.PI));
			GetComponent<Rigidbody2D> ().angularVelocity = 0f;
		}
		else if (Mathf.Abs (inputX) > 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, inputX > 0 ? 0 : 180));
			GetComponent<Rigidbody2D> ().angularVelocity = 0f;
		}
		else if (Mathf.Abs (inputY) > 0)
		{
			transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, inputY > 0 ? 90 : 270));
			GetComponent<Rigidbody2D> ().angularVelocity = 0f;
		}
    }
}
