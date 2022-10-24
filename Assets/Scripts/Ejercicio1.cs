using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio1 : MonoBehaviour
{
    public Vector3 goal;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, goal, speed * Time.deltaTime);
        transform.Translate(goal.normalized * speed * Time.deltaTime);

        //Modo avión
        transform.position = transform.position + new Vector3 (1 * speed * Time.deltaTime, 1 * speed * Time.deltaTime, 0);
    }
}
