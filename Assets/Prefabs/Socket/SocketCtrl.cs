using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketCtrl : MonoBehaviour
{
    public GameObject SocketPrefab;

    //set to true to auto-calculate the socket transform from the mesh bounds.
    //set to false to use the currently specified transform values
    public bool AutoCalculateXform = true;
    public bool AutoHide = false;   //set to true to auto-hide the socket
    public Color color = Color.white;


    // Start is called before the first frame update
    void Start()
    {
        //we need to do the following
        //1) instantiante a Socket object
        //2) auto-compute its transform from our bounds, if AutoCalculateXform is true
        //3) set its color
        //4) hide it if AutoHide is true
        /*
        GameObject go = Instantiate(SocketPrefab, transform, true);
        go.transform.position = GetComponent<MeshRenderer>().bounds.center;
        
        go.name = "Socket";
        if (name.EndsWith(" R")) go.name += " R";
        if (name.EndsWith(" L")) go.name += " L";
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
