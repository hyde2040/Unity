using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCon : MonoBehaviour
{
    public Fungus.Flowchart flowchart = null;
    public String sendMessage = "";

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            flowchart.SendFungusMessage(sendMessage);
        }
    }
}