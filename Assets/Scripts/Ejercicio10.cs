using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class Ejercicio10 : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Ejercicio10v2.score += 1;
        Debug.Log(" La puntuación del jugador es : " + Ejercicio10v2.score);
        Debug.Log("Ha colisionado con: " + gameObject.name);
        _meshRenderer.materials[0].color = Color.red;
    }
}