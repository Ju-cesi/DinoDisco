using UnityEngine;

public class interupteurPorteController : MonoBehaviour
{
    
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
            if (collide.gameObject.CompareTag("Diplo"))
            {
                isActive = true;
                transform.position = new Vector3 (transform.position.x, transform.position.y - activatedOffset, transform.position.z);
            }
        }
}
