using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(Manager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
