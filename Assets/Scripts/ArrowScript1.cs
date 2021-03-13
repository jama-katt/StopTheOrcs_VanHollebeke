using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript1 : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
