using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

// ALTIN VE X2 OBJESİNİN TESPİTİ

public class CoinDetect : MonoBehaviour {

	PlayerMovement playerMov;
	Vector3 rotVec; // Altınların dönüş animasyonu için gerekli vektör

	public bool x2Coin; // x2 olayı kontrolü için gerekli bool
	

	Color transColor = new Color(1f, 1f, 1f, 0f); // Altınların toplanması durumunda geçeceği şeffaflık

	void Start () {

		rotVec = new Vector3(45, 45, 0);
		x2Coin = false;
		playerMov = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	void Update () {

		// x2 durumuna geçiren obje değilse dönüş animasyonunu başlat
		if (gameObject.name != "x2Item (1)")
		{
			transform.DORotate(rotVec, 0).SetLoops(-1, LoopType.Yoyo);
			rotVec.y = rotVec.y + 1f;
		}

	}

	// Obje alındıktan sonra objeyi sil
	void DestroyCoin()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			// x2 objesine temasında skor artırımı
			if(x2Coin==false) playerMov.coin++;
			else playerMov.coin = playerMov.coin + 2;

			//Altın objesine temasında yok olma animasyonunun başlaması
			gameObject.GetComponent<BoxCollider>().isTrigger = true;
			transform.DOMoveY(transform.position.y + 5f, 0.25f).SetLoops(1, LoopType.Incremental);
			GetComponent<Renderer>().material.DOColor(transColor, 0.25f).OnComplete(DestroyCoin);

		}

	}
}
