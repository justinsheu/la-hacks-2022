using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Pedometer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputSystem.EnableDevice(StepCounter.current);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stepCounter);
    }

    public IntegerControl stepCounter { get; }

}
