using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


// ENGEL NESNESİNİN TESPİTİ

public class EnemyDetect : MonoBehaviour {

	public float endValue; // Engelin X ekseninde alacağı mesafe

	void Start () {

		StartAnimation();

	}

	// Ters yöne hareket
	void ResetAnimation()
	{
		endValue = endValue * -1; 
		StartAnimation();
	}

	// Hareket animasyonu
	void StartAnimation()
	{
		transform.DOMoveX(transform.position.x + endValue, 2f).OnComplete(ResetAnimation);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			col.gameObject.GetComponent<PlayerMovement>().move = false; // Topun hareketini durdur.

			// Çarpma sonrası topun animasyonu
			col.gameObject.transform.DOShakeScale(1f);
			col.gameObject.GetComponent<Renderer>().material.DOColor(Color.red, 1f);

			// Your Score Ekranının açılması
			col.gameObject.GetComponent<PlayerMovement>().yourScore.SetActive(true);
			GameObject.Find("YourScoreText").GetComponent<Text>().text = "Your Score: "
				+ GameObject.Find("Player").GetComponent<PlayerMovement>().coin;

			// Skor sayacının sıfırlanması
			GameObject.Find("ScoreText").GetComponent<Text>().text = "";


		}

	}
}
