using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBGM : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Obj;
    GameManager gameManager;
    void Start()
    {
        gameManager = Obj.GetComponent<GameManager>();
        gameManager.BGMNum =1;
        Debug.Log("OK");
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
