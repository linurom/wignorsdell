using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ControllObject;

    private IControllable cotrollableObject;

    private void Start()
    {
        if(ControllObject != null)
        cotrollableObject = ControllObject.GetComponent<IControllable>();
    }

    private void FixedUpdate()
    {
        cotrollableObject.Move();
    }
}
