using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pile : MonoBehaviour
{
    public Transform player;
    public float throwForce = 10;

    public bool draggable = true;
    private bool hasPlayer = false;
    private bool beingCarried = false;
    private bool touched = false;

    public void OnCollisionEnter(Collision collide)
    {
        if (collide.gameObject.CompareTag("PilePad"))
        {
            Debug.Log("pause");
            draggable = false;
        }
    }
    
    void FixedUpdate()
    {
        
        // check distance entre objet et joueur
            float dist = Vector3.Distance(gameObject.transform.position, player.position);

            // si - ou = 1.9 unitÃ©s de distance = on peut ramasser
            if (dist <= 4f)
            {
                hasPlayer = true;
            }
            else
            {
                hasPlayer = false;
            }
            if (draggable) {
            // si on peut ramasser et qu'on appuie sur E = on porte l'objet
            if (hasPlayer)
            {
                Debug.Log("rigidbody");
                GetComponent< Rigidbody>().isKinematic = true;
                transform.parent = player;
                beingCarried = true;
            }

            // Si on porte l'objet
            if (beingCarried)
            {
                // si l'objet touche un mur / objet avec collider
                if (touched)
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                    touched = false;
                }

                // Clique gauche = on jette l'objet
                if (Input.GetMouseButtonDown(0))
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                    GetComponent<Rigidbody>().AddForce(player.forward * throwForce);
                }
                // clique droit on pose l'objet
                else if (Input.GetMouseButtonDown(1))
                {
                    GetComponent<Rigidbody>().isKinematic = false;
                    transform.parent = null;
                    beingCarried = false;
                }
            }
        }
    }
}
