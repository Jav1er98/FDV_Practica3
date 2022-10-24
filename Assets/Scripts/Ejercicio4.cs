using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio4 : MonoBehaviour
{
    public Transform goal;
    public float speed;
    public float accuracy = 0.01f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        if (direction.magnitude > accuracy)
            transform.Translate(direction.normalized * speed * Time.deltaTime);
        }
}
