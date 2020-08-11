using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRemover : MonoBehaviour
{
    public float destroyTime = 3.0f;
    public float rotationSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
