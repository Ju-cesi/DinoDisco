using System;
using System.Net.Cache;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class interupteurPorteController : MonoBehaviour
{
    [SerializeField] public GameObject door;
    private bool isActive = false;
    private float activatedOffset = 0.18f;
    
    private float positionY;

    private CharacterController controller;

    [SerializeField]
    private Renderer renderer;

    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
            transform.position = new Vector3(transform.position.x, transform.position.y,
                transform.position.z - activatedOffset);
        }
    }

}
