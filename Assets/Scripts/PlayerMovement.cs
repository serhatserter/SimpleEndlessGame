using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// TOP OBJESİNİN HAREKETLERİ


public class PlayerMovement : MonoBehaviour {

	//Topun fizik nesneleri
	public Rigidbody rb;
	private RigidbodyConstraints originalConstraints;

	//Hareket için gerekli değişkenler
	private Vector3 movement;
	public float moveX, moveZ;

	//Hareket ve UI ve skor kontrolleri için
	public bool move;
	public bool canvasDelete;
	public bool resetX2Coin;

	// Üretilen nesneler ve Your Score ekranı
	public GameObject startFloor;
	GameObject[] deleting;
	public GameObject yourScore;

	public int coin; // Skor değişkeni
	

	void Start ()
	{

		rb = GetComponent<Rigidbody>();
		originalConstraints = rb.constraints;

		//Başlangıç hareket hızları
		moveZ = 15f;
		moveX = 15f;

		canvasDelete = false;
		move = false;

		movement = new Vector3(0, -5f, 0);
		rb.constraints = RigidbodyConstraints.FreezePositionY;

		resetX2Coin = false;

	}
	
	void Update ()
	{
		// Anlık skor sayımı
		if (canvasDelete == true)
		{
			rb.constraints = originalConstraints;
			GameObject.Find("ScoreText").GetComponent<Text>().text = coin.ToString();
		}

		//Zeminden temasın kesilmesi durumu
		if (transform.position.y < 0.7f)
		{
			movement.x = 0;
			movement.y = rb.velocity.y - 2f;
			movement.z = 0;
			rb.velocity = movement;		
		}

		//Aşağı düşmenin tamlanması durumu
		if (transform.position.y < -10f) {

			rb.constraints = RigidbodyConstraints.FreezeAll;

			GameObject.Find("ScoreText").GetComponent<Text>().text = "";

			yourScore.SetActive(true);
			GameObject.Find("YourScoreText").GetComponent<Text>().text = "Your Score: " + coin;

		}
	
		// Hareket yönlerinin kontrolü
		if (move == true)
		{
			rb.velocity = movement;

			if (Input.GetKey("right")) movement.x = moveX;
			else if (Input.GetKey("left")) movement.x = -moveX;
			else movement.x = 0;
		}

		//---------Performans için geride kalan zeminlerin temizlenmesi------//

		deleting = GameObject.FindGameObjectsWithTag("LevelFloor");
		foreach(GameObject delete in deleting)
		{
			if (delete.transform.position.z < gameObject.transform.position.z - 45f)
			{
				Destroy(delete);
				
			}
		}


	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Start")
		{
			move = true;
			movement.z = moveZ;
		}
		
		// Yeni zemin üretimi
		if (col.gameObject.tag == "Floor" || col.gameObject.tag == "Start")
		{
			startFloor.GetComponent<FloorCreate>().CreateFloor(startFloor);
			col.gameObject.tag = "Untagged";
			
		}

}
}
