using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFeedin : MonoBehaviour
{
    [SerializeField] GameObject flower;
    [SerializeField] GameObject grass;

    Vector3 FStartpos;
    Vector3 GStartpos;


    float Timer;
    float a;

    Vector3 n;
    Vector3 Gpos;
    // Start is called before the first frame update
    void Start()
    {
        n = new Vector3(0, 0,0);
        GStartpos=grass.transform.position;
        FStartpos = flower.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        Transform flowerTS = flower.transform;
        Transform grassTS = grass.transform;
        if (Timer <= 1f)
        {
            flowerTS.position = Vector3.Lerp(FStartpos, n, Timer);
            grassTS.position = Vector3.Lerp(GStartpos, n, Timer);
        }
    }
}
