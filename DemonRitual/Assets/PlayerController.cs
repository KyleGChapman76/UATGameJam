using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public bool player1;

    private void Start ()
    {
    }

    private void Update ()
    {
        float inputX = Input.GetAxis("Horizontal" + (player1 ? 1 : 2));
        float inputY = Input.GetAxis("Vertical" + (player1 ? 1 : 2));

        float movementReduction = 1f;
        if (Mathf.Abs(inputX) > 0 && Mathf.Abs(inputY) > 0)
            movementReduction = .707f;

        float movementX = inputX * movementSpeed * movementReduction;
        float movementY = inputY * movementSpeed * movementReduction;

        GetComponent<Rigidbody2D>().velocity = new Vector2(movementX, movementY);
        transform.rotation = Quaternion.identity;
    }
}
