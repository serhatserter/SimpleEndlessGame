using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


//X2 DURUMU ETKİLEŞİMLERİ


public class x2CoinItem : MonoBehaviour {

	GameObject parentObj;
	public Text text;

	void Start()
	{
		text = GameObject.Find("x2Text").GetComponent<Text>(); // x2 Mode yazısı

	}

	void OnCollisionEnter(Collision col)
	{
		// Sadece bulunduğu zemindeki altınları x2 yapmak için ana objeye erişildi
		parentObj = transform.parent.gameObject; 

		if (col.gameObject.tag == "Player")
		{
			text.DOColor(Color.white, 1f).SetLoops(2, LoopType.Yoyo); // x2 Mode yazısı animasyonu

			// x2 Nesnesine temas sonrası, etiketi Coin olan tüm nesnelerin yeşil rengine dönüp x2 puan vermesi
			foreach (Transform coin in parentObj.transform)
			{
				if(coin.gameObject.tag == "Coin") { 
					coin.gameObject.GetComponent<CoinDetect>().x2Coin = true;
					coin.gameObject.GetComponent<Renderer>().material.color = Color.green;
					Destroy(gameObject);
				}
			}

		}

	}
}
