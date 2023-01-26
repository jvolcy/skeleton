using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCtrl : MonoBehaviour
{
    public bool AutoHide = true;   //set to true to auto-hide the socket
    public Color color = Color.white;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<MeshRenderer>().material.color = color;
        GetComponent<MeshRenderer>().enabled = !AutoHide;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
