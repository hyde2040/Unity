using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menumanager : MonoBehaviour
{

	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject pauseUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject pauseUIInstance;
	[SerializeField] GameObject Player;
	PlayerController playerController;

    void Start()
    {
		playerController = Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)&&Player.transform.position==playerController.EndPos)
		{
			if (pauseUIInstance == null)
			{
				pauseUIInstance = GameObject.Instantiate(pauseUIPrefab) as GameObject;
				playerController.Menu = true;
				Time.timeScale = 0f;
			}
			else
			{
				playerController.Menu = false;
				Destroy(pauseUIInstance);
				Time.timeScale = 1f;
			}
		}
	}
}
