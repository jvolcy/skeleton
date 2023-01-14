using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ModelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        GameObject gameObject = args.interactableObject.transform.gameObject;

        Debug.Log("Entered " + gameObject.name);
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        GameObject gameObject = args.interactableObject.transform.gameObject;

        Debug.Log("Exited " + gameObject.name);
    }
}
