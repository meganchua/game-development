using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    // Start is called before the first frame update
    Text value;
    void Start()
    {
        value = GetComponent<Text>();
    }

    // Update is called once per frame
    public void valueUpdate(float val)
    {
        value.text = Mathf.RoundToInt(val * 100) + "";   
    }
}
