using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// KAMERA HAREKETİ


public class CameraMovement : MonoBehaviour {

	public GameObject player;
	private Vector3 playerPos;
	public float camDistance; // Kameranın topa uzaklığı

	private void Start()
	{
		camDistance = 10f;
		playerPos = transform.position;
		
	}

	void Update () {

		//-------Player konumuna göre kameranın hareketi---------//
		playerPos.z = player.transform.position.z - camDistance;
		playerPos.x = player.transform.position.x/2.5f;
		transform.position = playerPos;
	}
}
