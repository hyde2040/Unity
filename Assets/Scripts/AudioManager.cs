using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    //public AudioSource[] sfx;
    public AudioClip[] BGM;
    //public static AudioManager instance;

    private AudioSource source;

    //１つ前のシーン名
    private string beforeScene = "Title";
    // Start is called before the first frame update
    void Start()
    {
        //使用するAudioSource取得
        source = GetComponent<AudioSource>();

        //最初のBGM再生
        source.clip = BGM[0];
        source.Play();

        //シーンが切り替わった時に呼ばれるメソッドを登録
        SceneManager.activeSceneChanged += OnActiveSceneChanged;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnActiveSceneChanged(Scene prevScene, Scene nextScene)
    {
        //シーンがどう変わったかで判定

        if (beforeScene == "Introduction" && nextScene.name == "StartMap")
        {
            source.Stop();
            source.clip = BGM[1];    //流すクリップを切り替える
            source.Play();
        }

        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
    }
    //public void PlaySFX(int soundToPlay)
    //{
    //    if (soundToPlay < sfx.Length)
    //    {
    //        sfx[soundToPlay].Play();
    //    }
    //}
    //public void PlayBGM(int musicToPlay)
    //{
    //    Debug.Log("BGM");
    //    if (!bgm[musicToPlay].isPlaying)
    //    {
    //        StopMusic();
    //        if (musicToPlay < bgm.Length)
    //        {
    //            bgm[musicToPlay].Play();
    //        }
    //    }
    //}
    //public void StopMusic()
    //{
    //    for (int i = 0; i < bgm.Length; i++)
    //    {
    //        bgm[i].Stop();
    //    }
    //}
}