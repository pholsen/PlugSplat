using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlugSocket : MonoBehaviour
{
   
    void Start()
    {
        
    }


    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(69);
            SceneManager.LoadScene("WinScene");

        }

    }
}
