using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("Command");
    }
    
    public void Hands()
    {
        SceneManager.LoadScene("Hands");
    }
}
