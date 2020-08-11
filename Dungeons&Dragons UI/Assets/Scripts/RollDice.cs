using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RollDice : MonoBehaviour
{
    static int d1, d2, d3, d4, d5;
    static int top1, top2, top3, sum;
    public GameObject TextBox;

    
    public void ClickButton()
    {
        d1 = UnityEngine.Random.Range(1, 7);
        d2 = UnityEngine.Random.Range(1, 7);
        d3 = UnityEngine.Random.Range(1, 7);
        d4 = UnityEngine.Random.Range(1, 7);
        d5 = UnityEngine.Random.Range(1, 7);

        int[] arr1 = { d1, d2, d3, d4, d5 };
        top1 = top2 = top3 = 0;
        for (int i = 0; i < 5; i++)
        {
            if (arr1[i] > top1)
            {
                top3 = top2;
                top2 = top1;
                top1 = arr1[i];
            }

            else if (arr1[i] > top2)
            {
                top3 = top2;
                top2 = arr1[i];
            }

            else if (arr1[i] > top3)
            {
                top3 = arr1[i];
            }

        }

        sum = top1 + top2 + top3;

        TextBox.GetComponent<Text>().text = "First roll: " + d1 + " Second Roll: " + d2 + "\nThird Roll: " + d3 + " Fourth Roll: "
            + d4 + "\nFifth Roll: " + d5 + "\nTop three values: " + top1 + " " + top2 + " " + top3 + " " + "\nFinal value: " + sum;
        
    }

    public void Sum()
    {
        TextBox.GetComponent<Text>().text = sum + "";

    }


}
