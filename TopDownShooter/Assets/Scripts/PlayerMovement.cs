using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

	[System.Serializable]
	public class controls
	{
		[SerializeField]
		public string horizontalAxis;
		[SerializeField]
		public string verticalAxis;
		[SerializeField]
		public KeyCode aimButton;
	}

	Rigidbody _playerRigidbody;
	Rigidbody playerRigidbody {

		get {
			if (_playerRigidbody == null)
				_playerRigidbody = GetComponent<Rigidbody> ();
			return _playerRigidbody;
			}
	}

	public controls playerControls;

	public float _speed;
	public float speed{
		get{ 
			if (Input.GetKey(playerControls.aimButton))
				return _speed / 2;
			else
				return _speed;
			}

	}

	// Update is called once per frame
	void Update () {

		Vector2 direction = new Vector2(Input.GetAxis(playerControls.horizontalAxis), Input.GetAxis(playerControls.verticalAxis));
		Move (direction);
		Aim ();
		
	}

	void Move (Vector2 movement) {
		playerRigidbody.velocity = new Vector3 (movement.x * speed, playerRigidbody.velocity.y, movement.y * speed);
		Debug.Log (movement);
	}


	void Aim(){
		Vector3 mouseScreenPosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y);
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (mouseScreenPosition);
		transform.LookAt (new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z));
	}
}
