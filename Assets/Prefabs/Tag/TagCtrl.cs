using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class TagCtrl : MonoBehaviour
{
    public string Text
    {
        set
        {
            //set both the text in front and in back of the tag
            FrontText.text = value;
            RearText.text = value;
        }
        get
        {
            //return the text on the front of the tag.  Assume it is the same as the text on the back.
            return FrontText.text;
        }
    }

    bool isSelected = false;

    public bool Select
    {
        set
        {
            if (value) UnSelectAllOthers();
            isSelected = value;

            Debug.Log("Hand.SetActive(" + isSelected + ")");
            Hand.SetActive(isSelected);
        }
        get { return isSelected; }
    }
        

    public Transform LineAttachPoint;
    public MeshRenderer Target;
    LineRenderer lineRenderer;

    public TMP_Text FrontText;
    public TMP_Text RearText;
    public GameObject Ball;
    public GameObject Hand;

    // Start is called before the first frame update
    void Start()
    {
        //initialize both front and rear texts
        Text = "";

        //get a reference to the line renderer
        lineRenderer = GetComponent<LineRenderer>();

        //if the user didn't specify an attach point for the line,
        //use the tag object's transform as the attchment point
        if (LineAttachPoint == null) LineAttachPoint = transform;

        Hand.SetActive(isSelected);

        if (Target != null)
            Ball.GetComponent<BallCtrl>().Target = Target;
    }

    // Update is called once per frame
    void Update()
    {
        
        lineRenderer.SetPosition(0, LineAttachPoint.position);
        lineRenderer.SetPosition(1, Ball.transform.position);
        //lineRenderer.SetPosition(1, Target.bounds.center);
    }

    void UnSelectAllOthers()
    {
        TagCtrl[] tags = FindObjectsOfType<TagCtrl>();
        foreach (var tag in tags)
        {
            tag.Select = false;
        }
    }

    public void Selected(SelectEnterEventArgs args)
    { 
        //Debug.Log("Tag Selected");
        Select = true;

        //args.interactor.GetComponent<XRRayInteractor>().allowAnchorControl = true;
        args.interactorObject.transform.GetComponent<XRRayInteractor>().allowAnchorControl = true;

        //disable snap turning when we are holding a tag
        args.interactorObject.transform.GetComponentInParent<ActionBasedSnapTurnProvider>().enabled = false;
    }

    public void DeSelected(SelectExitEventArgs args)
    { 
        //Debug.Log("Tag DeSelected");
        Select = false;

        //args.interactor.GetComponent<XRRayInteractor>().allowAnchorControl = false;
        args.interactorObject.transform.GetComponent<XRRayInteractor>().allowAnchorControl = false;

        //enable snap turning when we are not holding a tag
        args.interactorObject.transform.GetComponentInParent<ActionBasedSnapTurnProvider>().enabled = true;
    }

    /*
    public void Activated(ActivateEventArgs args)
    { Debug.Log("Tag Activated"); }

    public void DeActivated(DeactivateEventArgs args)
    { Debug.Log("Tag DeActivated"); }
    */
}
