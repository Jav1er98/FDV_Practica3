using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{

    public Vector3 goal;
    public float speed= 0.1f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(goal.normalized * speed * Time.deltaTime);
    }
}
