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

        if (beforeScene == "TowerFirst" && nextScene.name == "TowerSecond")
        {
            source.Stop();
            source.clip = BGM[2];    //流すクリップを切り替える
            source.Play();
        }

        if (beforeScene == "Map"|| beforeScene == "Map2" || beforeScene == "Map3" || beforeScene == "Map4" || beforeScene == "Map5"
            || beforeScene == "TowerFirst" || beforeScene == "TowerSecond" || beforeScene == "TowerTop")

        {
            if (nextScene.name == "Battle")
            {
                source.Stop();
                source.clip = BGM[3];    //流すクリップを切り替える
                source.Play();
            }
            else
            {
                return;
            }
        }

        if (beforeScene == "Battle")
        {
            if (nextScene.name == "Map" || nextScene.name == "Map2" || nextScene.name == "Map3" || nextScene.name == "Map4" || nextScene.name == "Map5"
            || nextScene.name == "TowerFirst" || nextScene.name == "TowerSecond" || nextScene.name == "TowerTop")
            {
                source.Stop();
                source.clip = BGM[1];    //流すクリップを切り替える
                source.Play();
            }
            else
            {
                return;
            }
        }

        //遷移後のシーン名を「１つ前のシーン名」として保持
        beforeScene = nextScene.name;
        Debug.Log(beforeScene);
    }
}