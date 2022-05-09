using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentA : MonoBehaviour
{
    private void Awake()
    {
        Tools.Log(this, "Awake");
    }

    private void OnEnable()
    {
        Tools.Log(this, "OnEnable");
    }

    private void OnDisable()
    {
        Tools.Log(this, "OnDisable");
    }

    private void Start()
    {
        Tools.Log(this, "Start");
    }

    private void Update()
    {
        Tools.Log(this, "Update");
    }

    private void FixedUpdate()
    {
        Tools.Log(this, "FixedUpdate");
    }

    private void LateUpdate()
    {
        Tools.Log(this, "LateUpdate");
    }

    private void OnDestroy()
    {
        Tools.Log(this, "OnDestroy");
    }
}
