using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pileSupportTrigger : MonoBehaviour
{
    [SerializeField] private GameObject pile;

    public void OnTriggerEnter(Collider collide)
    {
        Debug.Log("stop pad");
        if (collide.gameObject.CompareTag("Pile"))
        {
            pile.gameObject.GetComponent<Pile>().draggable = false;
            pile.gameObject.GetComponent< Rigidbody>().isKinematic = false;
            pile.gameObject.transform.parent = null;
            Debug.Log(pile.gameObject.GetComponent<Pile>().draggable);
        }
    }
}
