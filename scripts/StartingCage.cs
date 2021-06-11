using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCage : MonoBehaviour
{

    [SerializeField]
    public GameObject cage;
    // Start is called before the first frame update
    void Start()
    {

        if(cage == null){
        cage = GameObject.FindWithTag("StartingCage");

        }
        cage.GetComponent<Animator>().SetBool("Open", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
