using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public Transform LineAttachPoint;
    public MeshRenderer Target;
    LineRenderer lineRenderer;

    public TMP_Text FrontText;
    public TMP_Text RearText;

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
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, LineAttachPoint.position);
        lineRenderer.SetPosition(1, Target.bounds.center);
    }

}
