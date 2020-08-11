using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformBump : MonoBehaviour
{
	//public float speed = 10f;
	Vector3 temp;
	private int growFlag;

    void Start()
	{
		growFlag = 0;
	}

    // Update is called once per frame
    void Update()
    {
		temp = transform.localScale;
        if(temp.y >= 4)
		{
			growFlag = 1;
		}
        if(temp.y <= 1)
		{
			growFlag = 0;
		}

        if(temp.y < 5 && growFlag == 0)
        {
			temp.y += Time.deltaTime * 3;
		}
        else if(temp.y > 1 && growFlag == 1)
		{
			temp.y -= Time.deltaTime * 3;
		}
	    else
		{
			growFlag = 0;
		}

		transform.localScale = temp;
    }
}
