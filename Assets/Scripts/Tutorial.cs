using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public static int Flag = 0;
    [SerializeField] GameObject goal;
    Text text;
    private void Start()
    {
        text = goal.GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Flag==0)
        {
            text.text = "text1";
        }
        else if(Flag==1)
        {
            text.text = "text2";
        }
    }

    public void BottunFlag()
    {
        Flag++;
    }
}
