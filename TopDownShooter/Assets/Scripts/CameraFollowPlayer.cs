using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour {

	Transform _player;
	Transform player{
		get{ 
			if (_player == null)
				_player = FindObjectOfType<PlayerMovement> ().transform;
			return _player;
		}

	}


	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x, transform.position.y, player.position.z);
		
	}
}
