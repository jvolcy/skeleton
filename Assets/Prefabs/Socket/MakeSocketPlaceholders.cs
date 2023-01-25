using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSocketPlaceholders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameObject = new GameObject("Socket");

        //GameObject gameObject = Instantiate(SocketPrefab, transform, true);
        gameObject.transform.position = GetComponent<MeshRenderer>().bounds.center;
        
        //go.name = "Socket";
        if (name.EndsWith(" R")) gameObject.name += " R";
        if (name.EndsWith(" L")) gameObject.name += " L";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
