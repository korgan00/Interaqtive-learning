using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderInfo : MonoBehaviour
{

    public float value;

    // Update is called once per frame
    void Update()
    {
        value = Mathf.Clamp01((-transform.localPosition.x) + 0.5f);
        
    }
}
