using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menucontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jouer()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void quitter()
    {
        Application.Quit();
    }
}
