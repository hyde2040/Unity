using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour
{
    public void No()
    {
        Debug.Log("aaa");
        SceneManager.LoadScene("Title");
    }

    public void Yes()
    {
        SceneManager.LoadScene("OkScene");
    }
}
