using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneScript : MonoBehaviour
{
	public List<GameObject> playObj;

	private GameObject king;
	private GameObject jurate;
	private GameObject black1;
	private GameObject black2;
	private GameObject black3;
	private GameObject textTalk;
	private GameObject textDeath;

	public bool anim = false;
	public bool death = false;

	private int talk;

	void Start ()
	{
		king = GameObject.Find("king");
		jurate = GameObject.Find("jurate");
		black1 = GameObject.Find("black1");
		black2 = GameObject.Find("black2");
		black3 = GameObject.Find("black3");
		textTalk = GameObject.Find("TalkingText");
		textDeath = GameObject.Find("EndingText");

		SetUI(false);

		// play start
	}
	
	void Update ()
	{
		// if no life??? -> play death
		//////
		if (Input.GetKey(KeyCode.Escape))
			Application.Quit();

		if (anim)
		{
			//StartCoroutine(PlayStart());
			talk = 1;
			AnimTalk();
			anim = false;
		}
		else if (death)
		{
			PlayDeath();
			death = false;
		}
		if (Input.GetMouseButtonDown(0) && talk > 0 && talk < 5)
		{
			AnimTalk();
		}
	}

	private void AnimTalk()
	{
		switch (talk)
		{
			case 1:
				{
					foreach (GameObject g in playObj)
						g.SetActive(false);
					king.SetActive(true);
					jurate.SetActive(true);
					black1.SetActive(true);
					black3.SetActive(true);
					textTalk.SetActive(true);
					jurate.GetComponent<SpriteRenderer>().color = Color.red;
					textTalk.GetComponent<TextMesh>().text = "You foolish people! You have offended all\n of old sea gods by not burning enough\n sacrifices!";
					talk++;
					break;
				}
			case 2:
				{
					jurate.GetComponent<SpriteRenderer>().color = Color.white;
					king.GetComponent<SpriteRenderer>().color = Color.red;
					textTalk.GetComponent<TextMesh>().text = "Oh no! Where are we now? \nWhy every corner of Lithuania \nis surrounded by the sea?";
					talk++;
					break;
				}
			case 3:
				{
					jurate.GetComponent<SpriteRenderer>().color = Color.red;
					king.GetComponent<SpriteRenderer>().color = Color.white;
					textTalk.GetComponent<TextMesh>().text = "We are sea gods, so you will \ndie in your beloved Baltic waters with \nall land you live on!";
					talk++;
					break;
				}
			case 4:
				{
					foreach (GameObject g in playObj)
						g.SetActive(true);
					SetUI(false);
					talk++;
					break;
				}
		}
	}

	IEnumerator PlayStart()
	{
		foreach (GameObject g in playObj)
			g.SetActive(false);
		king.SetActive(true);
		jurate.SetActive(true);
		black1.SetActive(true);
		black3.SetActive(true);
		textTalk.SetActive(true);
		jurate.GetComponent<SpriteRenderer>().color = Color.red;
		textTalk.GetComponent<TextMesh>().text = "You foolish people! You have offended all\n of old sea gods by not burning enough\n sacrifices!";
		yield return new WaitForSeconds(4f);
		jurate.GetComponent<SpriteRenderer>().color = Color.white;
		king.GetComponent<SpriteRenderer>().color = Color.red;
		textTalk.GetComponent<TextMesh>().text = "Oh no! Where are we now? \nWhy every corner of Lithuania \nis surrounded by the sea?";
		yield return new WaitForSeconds(4f);
		jurate.GetComponent<SpriteRenderer>().color = Color.red;
		king.GetComponent<SpriteRenderer>().color = Color.white;
		textTalk.GetComponent<TextMesh>().text = "We are sea gods, so you will \ndie in your beloved Baltic waters with \nall land you live on!";
		yield return new WaitForSeconds(4f);
		foreach (GameObject g in playObj)
			g.SetActive(true);
		SetUI(false);
		//start game
	}

	private void PlayDeath()
	{
		foreach (GameObject g in playObj)
			g.SetActive(false);
		black2.SetActive(true);
		textDeath.SetActive(true);
		textDeath.GetComponent<TextMesh>().text = "You Lost!";
		StartCoroutine(EndGame());
	}

	IEnumerator EndGame()
	{
		yield return new WaitForSeconds(5f);
		SceneManager.LoadScene(0);
	}

	private void SetUI (bool set)
	{
		king.SetActive(set);
		jurate.SetActive(set);
		black1.SetActive(set);
		black2.SetActive(set);
		black3.SetActive(set);
		textTalk.SetActive(set);
		textDeath.SetActive(set);
	}
}
