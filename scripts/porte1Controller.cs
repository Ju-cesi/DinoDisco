using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porte1Controller : MonoBehaviour
{
    [SerializeField] public GameObject door;
    
    private bool isActive = false;
    private float activatedOffset = 0.18f;
    
    private float positionY;

    private CharacterController controller;

    [SerializeField]
    private Renderer renderer;

    private Color color;
    
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            door.transform.Translate(new Vector3(0,-0.5f, 0));
        }
        
    }
    
    public void OnTriggerEnter(Collider collide)
    {
        
        color = renderer.material.color;
            GameObject dino = collide.gameObject;
            if (dino.CompareTag("Diplo") & dino.GetComponent<playerController>().activated)
            {
                Debug.Log("action1");
                isActive = true;
                transform.position = new Vector3(transform.position.x, transform.position.y,
                    transform.position.z + activatedOffset);
                renderer.material.color = Color.green;

                //controller = dino.GetComponent<CharacterController>();
            }
    }

    public void OnTriggerStay(Collider collide)
    {
          color = renderer.material.color;
            GameObject dino = collide.gameObject;
            if (dino.CompareTag("Diplo") & dino.GetComponent<playerController>().activated)
            {
                Debug.Log("action2");
                isActive = true;
                transform.position = new Vector3(transform.position.x, transform.position.y,
                    transform.position.z + activatedOffset);
                renderer.material.color = Color.green;
                //controller = dino.GetComponent<CharacterController>();
            }
    }

    public void OnTriggerExit(Collider collide)
    {
        GameObject dino = collide.gameObject;
        isActive = false;
        if (dino.CompareTag("Diplo"))
        {
            Debug.Log("action3");
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z - activatedOffset);
        }
    }
}
