using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class interupteurController : MonoBehaviour
{
    [SerializeField]
    public GameObject cage;
    
    private bool isActive = false;
    private float activatedOffset = 0.1f;

    private float positionY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Diplo") || collide.gameObject.CompareTag("Trice"))
        {
            isActive = true;
            transform.position = new Vector3 (transform.position.x, transform.position.y - activatedOffset, transform.position.z);
            //cage.GetComponent<Animator>().GetParameter(0);
            cage.GetComponent<Animator>().SetBool("Open", true);
        }
    }

    public void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.CompareTag("Diplo") || collide.gameObject.CompareTag("Trice"))
        {
            isActive = false;
            transform.position = new Vector3 (transform.position.x, transform.position.y + activatedOffset, transform.position.z);
        }
    }
}
