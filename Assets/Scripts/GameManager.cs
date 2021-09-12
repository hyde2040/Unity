using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    public AudioClip[] BGM;
    bool FeelBGM=false;
    public int BGMNum;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Manager);
        audioSource= GetComponent<AudioSource>();
        audioSource.clip = BGM[BGMNum];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!FeelBGM&&BGMNum==1)
        {
            audioSource.clip = BGM[BGMNum];
            audioSource.Play();
            FeelBGM = true;
        }
    }
}
