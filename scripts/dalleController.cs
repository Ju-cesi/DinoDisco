using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dalleController : MonoBehaviour
{
    [SerializeField]
    public GameObject cage;
    
    private bool isActive = false;
    private float activatedOffset = 0.1f;

    private float positionY;
    
    public void OnTriggerEnter(Collider collide)
    {
        if (collide.gameObject.CompareTag("Trice"))
        {
            isActive = true;
            transform.position = new Vector3 (transform.position.x, transform.position.y - activatedOffset, transform.position.z);
            //cage.GetComponent<Animator>().GetParameter(0);
            cage.GetComponent<Animator>().SetBool("Open", true);
            Debug.Log("contact");
        }
    }

    public void OnTriggerExit(Collider collide)
    {
        if (collide.gameObject.CompareTag("Trice"))
        {
            isActive = false;
            transform.position = new Vector3 (transform.position.x, transform.position.y + activatedOffset, transform.position.z);
        }
    }
}
