using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


// BLOK ZEMİN ÜRETİMİ

public class FloorCreate : MonoBehaviour {


	public GameObject[] floors; //Kullanılacak blokların bulunduğu liste
	private float floorStart = 40f; //Her blok 40f uzunlukta. 40f ekleyerek yeni zeminin konumu bulunuyor.
	public GameObject player;

	private void Start()
	{
		player = GameObject.Find("Player");

		// Liste Floor0 objesinde tutuluyor
		floors = GameObject.Find("Floor0").GetComponent<FloorCreate>().floors;

	}


	public void CreateFloor(GameObject startObj)
	{
		//Yeni zemini belirlemek için üretilen sayı
		int rand = Random.Range(0, floors.Length);

		// Yeni zeminin üretimi ve konumunun belirlenmesi
		GameObject x = Instantiate(floors[rand]);
		x.transform.position = new Vector3(0, -25f, startObj.transform.position.z + floorStart);

		// Yeni zeminin oluşum animasyonu
		x.transform.DOMoveY(0, 1f).SetEase(Ease.OutExpo);
		player.GetComponent<PlayerMovement>().startFloor = x;

		
	}
}
