using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
	private float movementX;
	private float movementY;
	public float speed;

	private int count = 0;
	public TextMeshProUGUI countText;
	public GameObject winTextObject;

	GameObject[] gameObjects;

	void Start()
    {
        rb = GetComponent<Rigidbody>();
		SetCountText();
		winTextObject.SetActive(false);
    }
	private void FixedUpdate()
	{
		Vector3 movement = new Vector3(movementX, 0f, movementY);
		rb.AddForce(movement * speed);
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Collectable"))
		{
			Destroy(other.gameObject);
			count++;
			SetCountText();
		}
	}
	void OnMove(InputValue movementValue)
	{
		Vector2 movementVector = movementValue.Get<Vector2>();
		movementX = movementVector.x;
		movementY = movementVector.y;
	}
	void SetCountText()
	{
		countText.text = "Gold: " + count.ToString();
		if(count >= 10)
		{
			winTextObject.SetActive(true);
			DestroyAllObjects();
		}
	}
	void DestroyAllObjects()
	{
		gameObjects = GameObject.FindGameObjectsWithTag("Collectable");
		CancelInvoke();
		for (var i = 0; i < gameObjects.Length; i++)
		{
			Destroy(gameObjects[i]);
		}
	}
}
