using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HandChange : MonoBehaviour
{
    /// <summary>
    /// モンスター番号の取得
    /// </summary>
    int? n = null;
    int? HandChangeNum = null;

    string inputString;
    string HandSaveData;

    //ボタンの入れ物
    public GameObject Monstertext1;
    public GameObject Monstertext2;
    public GameObject Monstertext3;

    [Serializable]
    public class Monsters
    {
        public MonsterData[] Monster;
    }
    [Serializable]
    public class MonsterData
    {
        public string Name;
        public int Hp;
        public int Power;
        public int Speed;
    }

    [Serializable]
    public class Hands
    {
        public HandData[] Hand;
    }
    [Serializable]
    public class HandData
    {
        public string Name;
        public int Hp;
        public int Power;
        public int Speed;
    }

    Monsters monsters;
    Hands hands;


    void Start()
    {
        // Status.jsonをテキストファイルとして読み取り、string型で受け取る
        inputString = Resources.Load<TextAsset>("status").ToString();
        // 上で作成したクラスへデシリアライズ
        monsters = JsonUtility.FromJson<Monsters>(inputString);
        hands = JsonUtility.FromJson<Hands>(inputString);

        //モンスターのステータスをロード
        for (int i = 0; i < 3; i++)
        {
            hands.Hand[i].Name = PlayerPrefs.GetString("名前" + i);
            hands.Hand[i].Hp = PlayerPrefs.GetInt("HP"+i);
            hands.Hand[i].Power = PlayerPrefs.GetInt("攻撃力"+i);
            hands.Hand[i].Speed = PlayerPrefs.GetInt("スピード"+i);
        }

        Monstertext1.GetComponentInChildren<Text>().text = hands.Hand[0].Name;
        Monstertext2.GetComponentInChildren<Text>().text = hands.Hand[1].Name;
        Monstertext3.GetComponentInChildren<Text>().text = hands.Hand[2].Name;
    }

    public void Monster1()
    {
        n = 0;
        HandChangeNum = null;
    }
    public void Monster2()
    {
        n = 1;
        HandChangeNum = null;
    }
    public void Monster3()
    {
        n = 2;
        HandChangeNum = null;
    }
    public void Hand1()
    {
        if (n != null && HandChangeNum == null)

        {
            MonsterChange(0);
            //Handの1番目の名前をTextに表示
            Monstertext1.GetComponentInChildren<Text>().text = hands.Hand[0].Name;
            //1度に1回しか手持ちの変更はできない
            n = null;

            //モンスターのステータスを保存　１
            PlayerPrefs.SetString("名前"+0, hands.Hand[0].Name);
            PlayerPrefs.SetInt("HP"+0, hands.Hand[0].Hp);
            PlayerPrefs.SetInt("攻撃力"+0, hands.Hand[0].Power);
            PlayerPrefs.SetInt("スピード"+0, hands.Hand[0].Speed);
            PlayerPrefs.Save();
        }
        else if (HandChangeNum != null&&n==null)
        {
            HandsChange(0);
            Monstertext1.GetComponentInChildren<Text>().text = hands.Hand[0].Name;
            HandChangeNum = null;
        }
        else if (n == null&& HandChangeNum == null)
        {
            HandChangeNum = 0;
        }
    }

    public void Hand2()
    {
        if (n != null && HandChangeNum == null)
        {
            MonsterChange(1);
            //Handの2番目の名前をTextに表示
            Monstertext2.GetComponentInChildren<Text>().text = hands.Hand[1].Name;
            //1度に1回しか手持ちの変更はできない
            n = null;

            //モンスターのステータスを保存　２
            PlayerPrefs.SetString("名前"+1, hands.Hand[1].Name);
            PlayerPrefs.SetInt("HP"+1, hands.Hand[1].Hp);
            PlayerPrefs.SetInt("攻撃力"+1, hands.Hand[1].Power);
            PlayerPrefs.SetInt("スピード"+1, hands.Hand[1].Speed);
            PlayerPrefs.Save();
        }
        else if (HandChangeNum != null && n == null)
        {
            HandsChange(1);
            Monstertext2.GetComponentInChildren<Text>().text = hands.Hand[1].Name;
            HandChangeNum = null;
        }
        else if (n == null && HandChangeNum == null)
        {
            HandChangeNum = 1;
        }
    }

    public void Hand3()
    {
        if (n != null && HandChangeNum == null)
        {
            MonsterChange(2);
            //Handの3番目の名前をTextに表示
            Monstertext3.GetComponentInChildren<Text>().text = hands.Hand[2].Name;
            //1度に1回しか手持ちの変更はできない
            n = null;

            //モンスターのステータスを保存　３
            PlayerPrefs.SetString("名前"+2, hands.Hand[2].Name);
            PlayerPrefs.SetInt("HP"+2, hands.Hand[2].Hp);
            PlayerPrefs.SetInt("攻撃力"+2, hands.Hand[2].Power);
            PlayerPrefs.SetInt("スピード"+2, hands.Hand[2].Speed);
            PlayerPrefs.Save();
        }
        else if (HandChangeNum != null && n == null)
        {
            HandsChange(2);
            Monstertext3.GetComponentInChildren<Text>().text = hands.Hand[2].Name;
            HandChangeNum = null;
        }
        else if (n == null && HandChangeNum == null)
        {
            HandChangeNum = 2;
        }
    }

    public void ResetButton()
    {
        PlayerPrefs.DeleteAll();
    }

    /// <summary>
    /// Monsterのn番目の情報をHandのa番目に入れる
    /// </summary>
    /// <param name="a"></param>
    void MonsterChange(int a)
    {
        hands.Hand[a].Name = monsters.Monster[(int)n].Name;
        hands.Hand[a].Hp = monsters.Monster[(int)n].Hp;
        hands.Hand[a].Power = monsters.Monster[(int)n].Power;
        hands.Hand[a].Speed = monsters.Monster[(int)n].Speed;
    }

    void HandsChange(int a)
    {
        hands.Hand[a].Name = hands.Hand[(int)HandChangeNum].Name;
        hands.Hand[(int)HandChangeNum].Name = PlayerPrefs.GetString("名前" + a);
        hands.Hand[a].Hp = hands.Hand[(int)HandChangeNum].Hp;
        hands.Hand[(int)HandChangeNum].Hp = PlayerPrefs.GetInt("HP" + a);
        hands.Hand[a].Power = hands.Hand[(int)HandChangeNum].Power;
        hands.Hand[(int)HandChangeNum].Power = PlayerPrefs.GetInt("攻撃力" + a);
        hands.Hand[a].Speed = hands.Hand[(int)HandChangeNum].Speed;
        hands.Hand[(int)HandChangeNum].Speed= PlayerPrefs.GetInt("スピード" + a);

        if (HandChangeNum==0)
        {
            Monstertext1.GetComponentInChildren<Text>().text = hands.Hand[0].Name;
        }
        else if (HandChangeNum == 1)
        {
            Monstertext2.GetComponentInChildren<Text>().text = hands.Hand[1].Name;
        }
        else if (HandChangeNum == 2)
        {
            Monstertext3.GetComponentInChildren<Text>().text = hands.Hand[2].Name;
        }

        PlayerPrefs.SetString("名前" + a, hands.Hand[a].Name);
        PlayerPrefs.SetInt("HP" + a, hands.Hand[a].Hp);
        PlayerPrefs.SetInt("攻撃力" + a, hands.Hand[a].Power);
        PlayerPrefs.SetInt("スピード" + a, hands.Hand[a].Speed);
        PlayerPrefs.SetString("名前" + (int)HandChangeNum, hands.Hand[(int)HandChangeNum].Name);
        PlayerPrefs.SetInt("HP" + (int)HandChangeNum, hands.Hand[(int)HandChangeNum].Hp);
        PlayerPrefs.SetInt("攻撃力" + (int)HandChangeNum, hands.Hand[(int)HandChangeNum].Power);
        PlayerPrefs.SetInt("スピード" + (int)HandChangeNum, hands.Hand[(int)HandChangeNum].Speed);
        PlayerPrefs.Save();
    }
}