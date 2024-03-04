using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class slotControl : MonoBehaviour
{
    public GameObject[] icons;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Instantiate(icons[Random.Range(0, icons.Length)], new Vector3(-12.2f, -17, 72f), transform.rotation);
    }

    private void Start()
    {
        
    }
}
