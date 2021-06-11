using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class transition : MonoBehaviour
{
    // Start is called before the first frame update
    public string scenename;
    
    void Start()
    {
        StartCoroutine(transitions());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    IEnumerator transitions()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenename);
    }
    
}
