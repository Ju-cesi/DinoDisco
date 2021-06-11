using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour
{
    private float activatedOffset = 0.18f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionStay(Collision collide)
    {
        if (collide.gameObject.CompareTag("Trice"))
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
        }
    }
    
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10;

    private bool hasPlayer = true;
    private bool beingCarried = false;
    private bool touched = false;

    void Update()
    {
        // check distance entre objet et joueur
        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        // si - ou = 1.9 unitÃ©s de distance = on peut ramasser
        if (dist <= 1.9f)
        {
            hasPlayer = true;
            Debug.Log("hasPlayer");
        }
        else
        {
            //hasPlayer = false;
            Debug.Log("no hasPlayer");
        }

        // si on peut ramasser et qu'on appuie sur E = on porte l'objet
        if (hasPlayer)
        {
            GetComponent< Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            beingCarried = true;
        }

        // Si on porte l'objet
        if (beingCarried)
        {
            // si l'objet touche un mur / objet avec collider
            if (touched)
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                touched = false;
            }

            // Clique gauche = on jette l'objet
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
                GetComponent< Rigidbody>().AddForce(playerCam.forward * throwForce);
            }
            // clique droit on pose l'objet
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }

    // DÃ©tection de contact grace au collider is trigger
    void OnTriggerEnter()
    {
        if (beingCarried)
        {
            touched = true;
        }
    }
}
