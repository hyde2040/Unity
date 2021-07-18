using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public void FadeScene()
    {
        SceneManager.LoadScene("StartMap");
    }
}
