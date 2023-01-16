using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class ModelController : MonoBehaviour
{
    public Material NormalBoneMaterial;
    public Material HighlightedBoneMaterial;
    public TMP_Text PartName;
    Animator animator;

    //create a list of the Animator trigger strings corresponding to the poses in the animation controller.
    string[] Poses = { "T-pose", "stand", "pose1", "pose2", "pose3" };
    int CurrentPose;    //we will keep track of the currently selected pose

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //set the default pose to pose 0
        CurrentPose = 0;
        SetPose(Poses[CurrentPose]);
    }

    // Update is called once per frame
    void Update()
    {
    }

    /// <summary>
    /// function that selects poses in a round-robin fashion.
    /// </summary>
    public void TogglePose()
    {
        CurrentPose = (CurrentPose + 1) % Poses.Length;
        SetPose(Poses[CurrentPose]);
    }

    /// <summary>
    /// fuction that sets the animator pose based on the trigger string.
    /// </summary>
    /// <param name="pose"></param>
    void SetPose(string pose)
    {
        animator.SetTrigger(pose);
    }

    /*
    void TPose()
    {
        animator.SetTrigger("T-pose");
    }

    void stand()
    {
        animator.SetTrigger("stand");
    }

    void pose1()
    {
        animator.SetTrigger("pose1");
    }

    void pose2()
    {
        animator.SetTrigger("pose2");
    }

    void pose3()
    {
        animator.SetTrigger("pose3");
    }
    */

    public void lookAround()
    {
        animator.SetTrigger("look_around");
    }

    public void walk()
    {
        animator.SetTrigger("walk");
    }

    public void run()
    {
        animator.SetTrigger("run");
    }

    public void SetAnimationSpeed(float speed)
    {
        animator.speed = speed;
    }

    void HighlightObject(GameObject gameObject)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = HighlightedBoneMaterial;
        PartName.text = gameObject.name;
    }
    void UnHighlightObject(GameObject gameObject)
    {
        MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = NormalBoneMaterial;
        PartName.text = "---";
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
