using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


// UI AYARLAMALARI


public class uiScript : MonoBehaviour {

	GameObject player, camera, panel, buttons, scorePanel, yourScore;
	Vector3 cam;

	void Start()
	{
		player = GameObject.Find("Player");
		camera = GameObject.Find("Main Camera");
		panel = GameObject.Find("Panel");
		buttons = GameObject.Find("Buttons");
		scorePanel = GameObject.Find("Score");
		yourScore = GameObject.Find("YourScore");

		cam = new Vector3(22.5f, 0, 0);

		//Oyun ekranında olma durumu
		if (SceneManager.GetActiveScene().name == "Main") {

			// Ekranların Kapatılması
			scorePanel.SetActive(false);
			yourScore.SetActive(false);

			// Açılıştaki Kamera animasyonu
			panel.GetComponent<Image>().DOColor(new Color(0, 0, 0, 0), 2f);
			camera.transform.DORotate(cam, 2f).SetEase(Ease.OutExpo).OnComplete(CanvasDelete);
		}
	}

	//---------Buton Etkileşimleri----------//
	public void Play()
	{
		SceneManager.LoadScene("Main");

	}

	public void Quit()
	{
		Application.Quit();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Opening");
	}

	//Ana açılış ekranının kapatılması
	void CanvasDelete()
	{
		scorePanel.SetActive(true);
		panel.SetActive(false);
		player.GetComponent<PlayerMovement>().canvasDelete = true;
	}


}
