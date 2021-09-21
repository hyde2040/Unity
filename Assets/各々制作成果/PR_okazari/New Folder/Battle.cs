using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tooltip;
    public Animator animator;
    public info info;
    public Text myHPtext;
    public Text myMPtext;
    public Text enemyHPtext;
    public Text enemyMPtext;
    public Text text;


    public int enemyNo;
    public string enemyName = "バリウド";
    [SerializeField] Image enemyImage;
    public int enemyHP = 110;
    public int enemyHPmax = 110;
    public int enemyMP = 100;
    public int enemySp = 5;
    public int enemyAt = 10;
    public int enemyUseS = 0;
    int[] enemySkill = { 8, 8, 8, 8 };
    int enemyCapture = 50;
    int ebuff = 0;
    int ebuffd = 0;

    int edebuff = 0;
    int edebuffd = 5;
    int edebuffT = 0;

    int tend = 0;

    public int myNo;
    public string myName = "アッチャ";
    [SerializeField] Image myImage;
    public int myHP = 250;
    public int myHPmax = 100;
    public int myMP = 100;
    public int mySp = 10;
    public int myAt = 12;
    public int myUseS = 0;
    public int[] mySkill = { 0, 2, 4, 3 };
    int buff = 0;
    int buffd = 0;


    [SerializeField] Sprite[] monsImage_F;
    [SerializeField] Sprite[] monsImage_B;
    [SerializeField] Text[] buttan;
    [SerializeField] GameObject[] hide;
    [SerializeField] Button[] buttons;

    int debuff = 0;
    int debuffd = 5;
    int debuffT = 0;

    [SerializeField] Slider[] sliders;
    int debagNo = 0;
    int debagNo2 = 6;

    int[] HPsave = { 25, 0, 0, 0, 30, 0, 70 };
    int[] MPsave = { 100, 0, 0, 0, 100, 0, 100 };


    void Start()
    {
        myHP = int.Parse(info.a[myNo, 1]);
        myHPmax = int.Parse(info.a[myNo, 1]);
        mySp = int.Parse(info.a[myNo, 2]);
        myAt = int.Parse(info.a[myNo, 3]);



        sliders[0].maxValue = myHPmax;
        sliders[1].maxValue = myMP;


        debagNo = enemyNo;
        myHP = HPsave[6];
        respn_E();
        respn_my();
        //自キャラ読み込み
        myHPtext.text = myHP.ToString();
        myMPtext.text = myMP.ToString();

        //敵読み込み
        enemyImage.sprite=monsImage_F[enemyNo];
        enemyHPtext.text = enemyHP.ToString();
        enemyMPtext.text = enemyMP.ToString();

        for (int i = 0; i < 4; i++)
        {
            buttan[i].text = info.skill[mySkill[i], 0];
        }
        text.text = myName+"はどうする？";

    }

    // Update is called once per frame
    void Update()
    {
        myHPtext.text = myHP.ToString();
        myMPtext.text = myMP.ToString();
        enemyHPtext.text = enemyHP.ToString();
        enemyMPtext.text = enemyMP.ToString();


        sliders[0].value = myHP;
        sliders[1].value = myMP;
        sliders[2].value = enemyHP;
        sliders[3].value = enemyMP;

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    respn_E();
        //}
        //if (Input.GetKeyDown(KeyCode.Tab))
        //{
        //    respn_my();
        //}

        //雑
        if (enemyHP <= 0)
        {
            enemyHP = 0;
        }
        if (HPsave[0] <= 0&&HPsave[4] <= 0&&HPsave[6] <= 0) {

            myHP = 0;
            text.text = ( "あなたは負けてしまった...");
            Invoke("SceneC", 2f);
        }
        else if (myHP <= 0)
        {
            myHP = 0;
            text.text = (myName + "は倒れてしまった...");
            //for (int i = 0; i < buttons.Length; i++)
            //{
            //    buttons[i].enabled = true;
            //}
            
        }
        HPsave[debagNo2] = myHP;
    }
    public void respn_E()
    {
        enemyName = info.a[debagNo, 0];
        enemyHP = int.Parse(info.a[debagNo, 1]);
        enemyHPmax = int.Parse(info.a[debagNo, 1]);
        enemySp = int.Parse(info.a[debagNo, 2]);
        enemyAt = int.Parse(info.a[debagNo, 3]);

        sliders[2].maxValue = enemyHP;
        enemyMP= 100;
        sliders[3].maxValue = enemyMP;
        enemyImage.sprite = monsImage_F[debagNo];
        for (int i = 0; i < 4; i++)
        {
            enemySkill[i]=info.MonsSkill[debagNo,i];
        }

        debagNo++;
        if (debagNo >= monsImage_F.Length)
        {
            debagNo = 0;
        }
    }
    public void respn_my()
    {
        HPsave[debagNo2] = myHP;
        MPsave[debagNo2] = myMP;
        if (debagNo2 == 4)
        {
            debagNo2 = 6;
        }
        else if (debagNo2 == 6)
        {
            debagNo2 = 0;
        }
        else if (debagNo2 == 0)
        {
            debagNo2 = 4;
        }
        myHP = HPsave[debagNo2];
        myMP = MPsave[debagNo2];

        myName = info.a[debagNo2, 0];
        myHP = HPsave[debagNo2];



        myHPmax = int.Parse(info.a[debagNo2, 1]);
        mySp = int.Parse(info.a[debagNo2, 2]);
        myAt = int.Parse(info.a[debagNo2, 3]);

        sliders[0].maxValue = myHPmax;

        myImage.sprite = monsImage_B[debagNo2];
        for (int i = 0; i < 4; i++)
        {
            mySkill[i] = info.MonsSkill[debagNo2, i];
            buttan[i].text = info.skill[mySkill[i], 0];
        }

        resetText();
    }

    public void Escape()
    {
        if (Random.Range(0, 4)==3)
        {
            text.text = ("上手く逃げ切れた！");
            Invoke("SceneC", 1f);
            return;
        }
        tend++;
        text.text = ("逃げられなかった…！");
        Invoke("EnemyAttack", 1f);
    }
    public void Capture()
    {
        if (Random.Range(0, 100) <= enemyCapture)
        {
            text.text = (enemyName+"を捕まえた！" + enemyCapture + "%");
            Invoke("SceneC", 1f);
            return;
        }
        tend++;
        text.text = ("捕まえられなかった…！"+enemyCapture+"%");
        Invoke("EnemyAttack", 1f);
    }

        
    void SceneC()
    {
        SceneManager.LoadScene("GameOver");
    }
    void SceneC2()
    {
        SceneManager.LoadScene("GameClear");
    }
        //==================================================================
        public void attackPriority()
    {


        if (mySp == enemySp)
        {

        }

        if (mySp >= enemySp)
        {
            text.text = ("自分の先制");
            Invoke( "myAttack",1f);
            //myAttack();

        }
        else
        {
            text.text = ("相手の先制");
            Invoke("EnemyAttack", 1f);
        }
    }
    public void EnemyAttack()
    {
                animator.SetTrigger("Enemy");//追加

        if (0 > (enemyMP - int.Parse(info.skill[enemySkill[enemyUseS], 4])))
        {
            enemyUseS = 0;
        }

        enemyMP -= int.Parse(info.skill[enemySkill[enemyUseS], 4]);
        text.text = (enemyName + "の攻撃：" + info.skill[enemySkill[enemyUseS], 0] + "\n");
        if (int.Parse(info.skill[enemySkill[enemyUseS], 1]) == 0)
        {

            if (debuffT > 0 && debuff == 2)
            {
                text.text = (enemyName + "はスタンしている。");
                debuffT--;
                tend++;
                Debug.Log("" + tend);
                if (tend == 2)
                {
                    Invoke("resetText", 2f);
                    tend = 0;
                    return;
                }
            }
            
            for (int i = 0; i < int.Parse(info.skill[enemySkill[enemyUseS], 3]); i++)
            {
                int d = enemyAt + int.Parse(info.skill[enemySkill[enemyUseS], 2]);
                if (d < 5) d = 5;
                text.text += (d + "ダメージ　");
                myHP -= d;
            }
        }
        else if (int.Parse(info.skill[enemySkill[enemyUseS], 1]) == 1)
        {
            buffs_E();
        }
        else if (int.Parse(info.skill[enemySkill[enemyUseS], 1]) == 3)
        {
            demerit_E();
        }
        else
        {
            //debuff = int.Parse(info.skill[mySkill[myUseS], 2]);
            //debuffT = int.Parse(info.skill[mySkill[myUseS], 3]);
        }

        if (myHP <= 0)
        {
            myHP = 0;
            text.text = (myName + "は倒れてしまった...");

        }
        else if(enemyHP <= 0)
        {
            enemyHP = 0;
            text.text = ("キミの勝ち！");
            Invoke("SceneC2", 1f);
        }

        //ターン処理
        tend++;
        Debug.Log("" + tend);
        if (tend == 2)
        {
            Invoke("resetText", 2f);
            tend = 0;
            return;
        }
        if (myHP > 0)
        {
            Invoke("myAttack", 2f);
        }

    }
    public void myAttack()
    {
        animator.SetTrigger("My");//追加
        myMP -= int.Parse(info.skill[mySkill[myUseS], 4]);

        text.text = (myName+"の攻撃：" + info.skill[mySkill[myUseS], 0]+"\n");
        if (int.Parse(info.skill[mySkill[myUseS], 1]) == 0)
        {

            for (int i = 0; i < int.Parse(info.skill[mySkill[myUseS], 3]); i++)
            {
                int d = myAt +  int.Parse(info.skill[mySkill[myUseS], 2]);

                    d += buffd;


                if (d < 5) d = 5;

                text.text+=(d + "ダメージ　");
                enemyHP -= d;
            
            }

        }
        else if (int.Parse(info.skill[mySkill[myUseS], 1]) == 1)
        {
            buffs();
        }
        else if (int.Parse(info.skill[mySkill[myUseS], 1]) == 2)
        {
            debuffs();
        }
        else if (int.Parse(info.skill[mySkill[myUseS], 1]) == 3)
        {
            demerit();
        }
        else
        {
            debuff = int.Parse(info.skill[mySkill[myUseS], 2]);
            debuffT = int.Parse(info.skill[mySkill[myUseS], 3]);
        }

      
            if (enemyHP <= 0)
            {
                enemyHP = 0;
                text.text = ("キミの勝ち！");
            Invoke("SceneC2", 1f);
        }
            else if (myHP <= 0)
            {
                myHP = 0;
            text.text = (myName + "は倒れてしまった...");
        }
        //ターン処理
        tend++;
        Debug.Log(""+tend);
        if (tend == 2)
        {
            Invoke("resetText", 2f);
            tend = 0;
            return;
        }
        if (enemyHP > 0)
        {
            Invoke("EnemyAttack", 2f);
        }

    }
    public void Attack(int HP, int At)
    {
        HP -= At;


        //ターン処理
        tend++;
        Debug.Log("" + tend);
        if (tend == 2)
        {
            Invoke("resetText", 2f);
            tend = 0;
            return;
        }
        if (enemyHP > 0)
        {
            Invoke("EnemyAttack", 2f);
        }


    }
    public void myUseningAttack(int UseS)
    {
        //ボタンオフ
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }



        if (enemyHP > 0 && myHP > 0)
        {
            myUseS = UseS;
            if (0 > (myMP - int.Parse(info.skill[mySkill[myUseS], 4])))
            {
                Debug.Log(myMP - int.Parse(info.skill[mySkill[myUseS], 4]));
                text.text = ("MPが足りません");
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].enabled = true;
                }
                return;
            }

            enemyUseS = Random.Range(0, 4);
            attackPriority();
        }
        else if (myHP <= 0)
        {
            text.text = (myName + "は動けない...!");
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = true;
            }
            return;

        }
        else
        {
            text.text = ("もういいだろ...!\n........そいつは死んでる...。");
        }
    }
    
    void resetText()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = true;
        }
        text.text = (myName+"はどうする？");

    }
    //===バフ==============================
  void buffs()
    {
        if (mySkill[myUseS] == 4)
        {
            enemyCapture += 50;
            return;
        }

        if (mySkill[myUseS] == 5)
        {
            buffd += 5;
            Debug.Log(buffd + "のチャージ");
        }
        if (mySkill[myUseS] == 6)
        {
            myHP += 150;
            if (myHP > myHPmax)
            {
                myHP = myHPmax;
            }
        }
        if (mySkill[myUseS] == 11)
        {
            myHP += 200;
            if (myHP > myHPmax)
            {
                myHP = myHPmax;
            }
        }
        if (mySkill[myUseS] == 16)
        {
            buffd += int.Parse(info.skill[mySkill[myUseS], 2]);
            Debug.Log(buffd + "のチャージ");
        }

        buff = int.Parse(info.skill[mySkill[myUseS], 2]);
    }
    void buffs_E()
    {
        if (enemySkill[enemyUseS] == 4)
        {
            enemyCapture += 50;
            return;
        }

        if (enemySkill[enemyUseS] == 5)
        {
            ebuffd += 5;
            Debug.Log(ebuffd + "のチャージ");
        }
        if (enemySkill[enemyUseS] == 6)
        {
            enemyHP += 150;
            if (enemyHP > enemyHPmax)
            {
                enemyHP = enemyHPmax;
            }
        }
        if (enemySkill[enemyUseS] == 11)
        {
            enemyHP += 200;
            if (enemyHP > enemyHPmax)
            {
                enemyHP = enemyHPmax;
            }
        }
        if (enemySkill[enemyUseS] == 16)
        {
            ebuffd += int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            Debug.Log(ebuffd + "のチャージ");
        }

        ebuff = int.Parse(info.skill[enemySkill[enemyUseS], 2]);

    }

    //===デバフ==============================
    void debuffs()
    {
        if (mySkill[myUseS] == 13)
        {
            enemyAt -= int.Parse(info.skill[mySkill[myUseS], 2]);
            if (enemyAt < 0) enemyAt = 0;
        }
        if (mySkill[myUseS] == 14)
        {
            enemySp -= int.Parse(info.skill[mySkill[myUseS], 2]);
        }
    }
    void debuffs_E()
    {
        if (enemySkill[enemyUseS] == 13)
        {
            myAt -= int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            if (myAt < 0) myAt = 0;
        }
        if (enemySkill[enemyUseS] == 14)
        {
            mySp-= int.Parse(info.skill[enemySkill[enemyUseS], 2]);
        }

    }
    //===デメリット付き==============================
    void demerit()
    {
        if (mySkill[myUseS] == 8)
        {
            int d = myAt + int.Parse(info.skill[mySkill[myUseS], 2]);

                d += buffd;

            text.text += (d + "ダメージ　" + myName + "は反動をうけた");
            enemyHP -= d;
            myHP -= int.Parse(info.skill[mySkill[myUseS], 3]);//デメリット部分
        }

        if (mySkill[myUseS] == 9)
        {
            int d = myAt + int.Parse(info.skill[mySkill[myUseS], 2]);

                d += buffd;
                
            
            text.text += (d + "ダメージ　" + myName + "は攻撃力が下がった");
            enemyHP -= d;
            myAt -= int.Parse(info.skill[mySkill[myUseS], 3]);//デメリット部分
            if (myAt < 0)
            {
                myAt = 0;
            }


        }
        if (mySkill[myUseS] == 10)
        {
            int d = myAt + int.Parse(info.skill[mySkill[myUseS], 2]);

                d += buffd;

            text.text += (d + "ダメージ　" + myName + "は体力を削り攻撃力が上げた");
            enemyHP -= d;
            myHP -= int.Parse(info.skill[mySkill[myUseS], 3]);//デメリット部分
            myAt += 15;//メリット部分

        }
        if (mySkill[myUseS] == 12)
        {
            int d = myAt + int.Parse(info.skill[mySkill[myUseS], 2]);
            
                d += buffd;
                
            text.text += (d + "ダメージ　" + myName + "は反動をうけた");
            enemyHP -= d;
            myHP -= int.Parse(info.skill[mySkill[myUseS], 3]);//デメリット部分
        }
        if (mySkill[myUseS] == 15)
        {
            int d = myAt + int.Parse(info.skill[mySkill[myUseS], 2]);
            
                d += buffd;
                
            text.text += (d + "ダメージ　" + myName + "は反動をうけた");
            enemyHP -= d;
            myHP -= int.Parse(info.skill[mySkill[myUseS], 3]);//デメリット部分
        }

    }
    void demerit_E()
    {

        if (enemySkill[enemyUseS] == 8)
        {
            int d = enemyAt + int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            
                d += ebuffd;
                
            text.text += (d + "ダメージ　" + enemyName + "は反動をうけた");
            myHP -= d;
            enemyHP -= int.Parse(info.skill[enemySkill[enemyUseS], 3]);//デメリット部分
        }

        if (enemySkill[enemyUseS] == 9)
        {
            int d = enemyAt + int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            
                d += ebuffd;
               
            text.text += (d + "ダメージ　"+enemyName+"は攻撃が下がった");
            myHP -= d;
            enemyAt -= int.Parse(info.skill[enemySkill[enemyUseS], 3]);//デメリット部分
            if (enemyAt<0)
            {
                enemyAt = 0;
            }

        }
        if (enemySkill[enemyUseS] == 10)
        {
            int d = enemyAt + int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            
                d += ebuffd;
            
            text.text += (d + "ダメージ　" + enemyName + "は体力を削り攻撃力を上げた");
            myHP -= d;
            enemyHP -= int.Parse(info.skill[enemySkill[enemyUseS], 3]);    //デメリット部分
            enemyAt +=15;//メリット部分

        }
        if (enemySkill[enemyUseS] == 12)
        {
            int d = enemyAt + int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            
                d += ebuffd;
            
            text.text += (d + "ダメージ　" + enemyName + "は反動をうけた");
            myHP -= d;
            enemyHP -= int.Parse(info.skill[enemySkill[enemyUseS], 3]);//デメリット部分
        }
        if (enemySkill[enemyUseS] == 15)
        {
            int d = enemyAt + int.Parse(info.skill[enemySkill[enemyUseS], 2]);
            
                d += ebuffd;
                
            text.text += (d + "ダメージ　" + enemyName + "は反動をうけた");
            myHP -= d;
            enemyHP -= int.Parse(info.skill[enemySkill[enemyUseS], 3]);//デメリット部分
        }
    }
    //===メニュー========================
    public void Menu()
    {
        hide[0].gameObject.SetActive(true);
        hide[1].gameObject.SetActive(true);
    }
    public void ReturnMenu()
    {
        tooltip.gameObject.SetActive(false);
        hide[0].gameObject.SetActive(false);
        hide[1].gameObject.SetActive(false);
    }
}