using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject lightningObject = null; 

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject chain = Instantiate(lightningObject, transform.position, Quaternion.identity);
            chain.GetComponent<Rigidbody>().AddForce(transform.forward * 1200);
        }
    }
}
