using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;

	private CharacterController player;
	public GameObject eyes;

	private bool isCrouched;

	public float moveY;
	public float moveX;
	public float rotateY;
	public float rotateX;

	// Use this for initialization
	void Start () {

		player = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

		moveY = Input.GetAxis ("Vertical") * speed;
		moveX = Input.GetAxis ("Horizontal") * speed;

		rotateX = Input.GetAxis ("Mouse X") * sensitivity;
		rotateY -= Input.GetAxis ("Mouse Y") * sensitivity;
		rotateY = Mathf.Clamp (rotateY, -60f, 60f);

		Vector3 movement = new Vector3 (moveX, 0, moveY);
		transform.Rotate (0, rotateX, 0);
		eyes.transform.localRotation = Quaternion.Euler(rotateY, 0, 0);
		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);

		if (Input.GetKeyDown (KeyCode.H)) {
			if (isCrouched == false) {
				player.height = 1.0f;
				isCrouched = true;
			} 

			else {
				player.height = 2.0f;
				isCrouched = false;
			}
		}

	}
}
