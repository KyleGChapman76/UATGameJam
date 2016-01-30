using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public bool player1; //if this player is player1 or not

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
        transform.rotation = Quaternion.identity;
    }
}
