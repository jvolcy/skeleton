using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ModelController : MonoBehaviour
{
    public Material NormalBoneMaterial;
    public Material HighlightedBoneMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HighlightObject(GameObject gameObject)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = HighlightedBoneMaterial;
    }
    void UnHighlightObject(GameObject gameObject)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = NormalBoneMaterial;
    }
    public void OnHoverEnter(HoverEnterEventArgs args)
    {
        GameObject gameObject = args.interactableObject.transform.gameObject;

        //Debug.Log("Entered " + gameObject.name);
        HighlightObject(gameObject);
    }

    public void OnHoverExit(HoverExitEventArgs args)
    {
        GameObject gameObject = args.interactableObject.transform.gameObject;

        //Debug.Log("Exited " + gameObject.name);
        UnHighlightObject(gameObject);
    }
}
