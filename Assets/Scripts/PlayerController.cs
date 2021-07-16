using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //入力キーを方向に変換
    float Xdirection ;
    float Ydirection ;

    //長押しの読み取り周期
    float HoldPress_Cycle = 0.0f;

    private Vector3 StartPos;
    public Vector3 EndPos;
    float elapsedTime; // 経過した時間
    public float duration = 0.2f; //移動に要する時間

    //最初の一歩用
    bool FirstWalk = false;

    public bool Menu = false;

    //走る用
    bool RunFlag = false;

    //Playerの歩数計算用
    int intSteps = 0;
    bool boolSteps;

    int i = 0;

    //Playerのアニメーション用
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        EndPos = transform.position;
    }

    //毎フレーム処理するもの
    void Update()
    {
        HoldPress_Cycle += Time.deltaTime;

        Xdirection = Input.GetAxisRaw("Horizontal");
        Ydirection = Input.GetAxisRaw("Vertical");

        if (transform.position == EndPos)
        {
            animator.SetBool("Idle", true);
            FirstWalk = false;
        }
        else
        {
            animator.SetBool("Idle", false);
            Move();
        }
        if (Xdirection != 0 && Ydirection == 0 || Ydirection != 0 && Xdirection == 0)
        {
            if (RunFlag == false)
            {
                duration = 0.3f;
                PlayerMoveMain();
            }
            else if (RunFlag == true)
            {
                duration = 0.16f;
                PlayerRun();
            }

        }
    }

    //プレイヤーの入力処理
    void PlayerInput()
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            RunFlag = true;
            animator.SetBool("Run", true);
        }
        else
        {
            RunFlag = false;
            animator.SetBool("Run", false);
        }
    }
    void MoveX(float Move)
    {
        StartPos = transform.position;
        EndPos = new Vector2(StartPos.x + Move, StartPos.y);
        elapsedTime = 0;
    }
    void MoveY(float Move)
    {
        StartPos = transform.position;
        EndPos = new Vector2(StartPos.x, StartPos.y + Move);
        elapsedTime = 0;
    }

    void Move()
    {

        elapsedTime += Time.deltaTime;
        float rate = elapsedTime / duration;
        //rateを0~1の範囲に収める
        rate = Mathf.Clamp(rate, 0f, 1f);
        //Lerp：StartPosを0,EndPosを1としたときに、rate(0~１)の位置を返してくれる
        transform.position = Vector3.Lerp(StartPos, EndPos, rate);
    }


    //プレイヤーの移動
    void PlayerMoveSub()
    {
        if (transform.position == EndPos && Menu == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //Ray生成
                Ray ray = new Ray(transform.position, Vector2.left);
                CollisionRay();
            }
            if (Input.GetKey(KeyCode.D))
            {
                //Ray生成
                Ray ray = new Ray(transform.position, Vector2.right);
                CollisionRay();
            }
            if (Input.GetKey(KeyCode.S))
            {
                //Ray生成
                Ray ray = new Ray(transform.position, Vector2.up);
                CollisionRay();
            }
            if (Input.GetKey(KeyCode.W))
            {
                //Ray生成
                Ray ray = new Ray(transform.position, Vector2.down);
                CollisionRay();
            }
        }
    }

    //Playerの移動
    void PlayerMoveMain()
    {

        if (FirstWalk == false)
        {
            intSteps++;
            FirstWalk = true;
        }

        while (HoldPress_Cycle >= 0.3f)
        {
            PlayerMoveSub();
            HoldPress_Cycle = 0.0f;
            if (i == 2)
            {
                intSteps++;
                i = 0;
            }
        }
    }

    //Playerの移動(ダッシュ)
    void PlayerRun()
    {
        if (FirstWalk == false)
        {
            intSteps++;
            FirstWalk = true;
        }

        while (HoldPress_Cycle >= 0.16f)
        {
            PlayerMoveSub();
            HoldPress_Cycle = 0.0f;
            //i++;
            //if (i == 2)
            //{
            //    intSteps++;
            //    i = 0;
            //}
        }
    }

    //衝突判定のための光線
    void CollisionRay()
    {
        //Ray生成
        Ray ray = new Ray(transform.position, new Vector2(Xdirection, Ydirection));

        //Rayの長さ
        float distance = 1f;

        //----------Debug用、Rayの可視化----------
        Debug.DrawRay(ray.origin, ray.direction * 1, Color.red, 1);

        //2DのRayのHit判定
        RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin,
            (Vector2)ray.direction, distance);

        //colliderに当たった際の処理
        if (hit2D.collider)
        {
            if (hit2D.collider.CompareTag("Tag01"))
            {
                SceneManager.LoadScene("Map");
            }
            else if (hit2D.collider.CompareTag("Tag02"))
            {
                SceneManager.LoadScene("Map2");
            }
            else if (hit2D.collider.CompareTag("Tag03"))
            {
                SceneManager.LoadScene("Map3");
            }
            else if (hit2D.collider.CompareTag("Tag04"))
            {
                SceneManager.LoadScene("Map4");
            }
            else if (hit2D.collider.CompareTag("Tag05"))
            {
                SceneManager.LoadScene("Map5");
            }
            else
            {
                MoveX(0);
                MoveY(0);
            }
        }
        else
        {
            if (transform.position == EndPos && Menu == false)
            {

                PlayerInput();
                intSteps++;
                //偶数
                if (intSteps % 2 == 0)
                {
                    animator.SetBool("Step", true);
                    if (Xdirection != 0 && Ydirection == 0)
                    {
                        MoveX(Xdirection);
                        animator.SetFloat("Xdirection", Xdirection);
                        animator.SetFloat("Ydirection", 0);
                    }
                    else if (Ydirection != 0 && Xdirection == 0)
                    {
                        MoveY(Ydirection);
                        animator.SetFloat("Ydirection", Ydirection);
                        animator.SetFloat("Xdirection", 0);
                    }
                }
                //奇数
                else if (intSteps % 2 != 0)
                {
                    animator.SetBool("Step", false);
                    if (Xdirection != 0 && Ydirection == 0)
                    {
                        MoveX(Xdirection);
                        animator.SetFloat("Xdirection", Xdirection);
                        animator.SetFloat("Ydirection", 0);
                    }
                    else if (Ydirection != 0 && Xdirection == 0)
                    {
                        MoveY(Ydirection);
                        animator.SetFloat("Ydirection", Ydirection);
                        animator.SetFloat("Xdirection", 0);
                    }
                }
            }
        }
    }
}