using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio3 : MonoBehaviour
{
    public Transform goal;
    public float speed = 1.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = goal.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }
}
