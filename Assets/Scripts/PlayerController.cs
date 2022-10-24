using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
	private float movementX;
	private float movementY;
	public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
	private void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0f, movementY);
		rb.AddForce(movement * speed);
	}
	void OnMove(InputValue movementValue)
	{
        Vector2 movementVector = movementValue.Get<Vector2>();
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
}