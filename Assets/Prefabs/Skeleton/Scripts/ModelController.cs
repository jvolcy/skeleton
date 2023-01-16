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
    Vector3 defaultPosition;
    Quaternion defaultRotation;
    Vector3 defaultLocalScale;

    //Create a default list of the pose animation clips.  This does not include the moving animations.
    //We need the list so we can cycle through the different poses.
    public string[] Poses = { "T-Pose", "stand", "action_pose1", "action_pose2", "action_pose3" };
    int CurrentPose;    //we will keep track of the currently selected pose

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        //create a copy of the current transform values
        SaveTransform();

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
    public void CycleThroughPoses()
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
        RestoreTransform();
        animator.Play(pose);
    }

    public void lookAround()
    {
        RestoreTransform();
        animator.Play("look_around");
    }

    public void walk()
    {
        RestoreTransform();
        animator.Play("walk");
    }

    public void run()
    {
        RestoreTransform();
        animator.Play("run");
    }

    public void SetAnimationSpeed(System.Single speed)
    {
        //Debug.Log("Speed = " + speed);
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


    /// <summary>
    /// We will save and restore the default Xform to prevent model drift.
    /// Each animation may introduce some root motion that should not be allowed
    /// to accumulate.  This function saves the default transform.  It should
    /// be called once in Start().
    /// </summary>
    void SaveTransform()
    {
        defaultPosition = transform.position;
        defaultRotation = transform.rotation;
        defaultLocalScale = transform.localScale;
    }

    /// <summary>
    /// We will save and restore the default Xform to prevent model drift.
    /// Each animation may introduce some root motion that should not be allowed
    /// to accumulate.  This function restores the default transform.  It
    /// should be called every time we change the pose or animation clip.
    /// </summary>
    void RestoreTransform()
    {
        transform.position = defaultPosition;
        transform.rotation = defaultRotation;
        transform.localScale = defaultLocalScale;
    }
}
