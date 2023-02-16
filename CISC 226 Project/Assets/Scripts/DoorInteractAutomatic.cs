using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractAutomatic : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private Door _door;
    private float timer;
    
    private void Awake()
    {
        _door = doorGameObject.GetComponent<Door>();
    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                _door.Close();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GetComponent<Playermovement>() != null)
        {
            _door.Open();
            timer = 1f;
        }
    }
}
