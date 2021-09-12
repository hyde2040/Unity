using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int musicToPlay;
    private bool musicStarted;
    void Start()
    {
        //if (!musicStarted)
        //{
        //    musicStarted = true;
        //    AudioManager.instance.PlayBGM(musicToPlay);
        //    Debug.Log("1");
        //}
        DontDestroyOnLoad(this.gameObject);
        //audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
