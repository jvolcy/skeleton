using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

//[RequireComponent(typeof(ActionBasedController))]
[RequireComponent(typeof(Animator))]

public class HandController : MonoBehaviour
{

    //boolean: true = right hand; false = left hand
    public bool RightHand = true;

    ActionBasedController controller;
    //public GameObject HandController;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Hand Start");
        animator = GetComponent<Animator>();
        controller = GetComponentInParent<ActionBasedController>();
        controller.activateAction.action.started += Activate;
        controller.selectAction.action.started += Select;
        controller.activateAction.action.canceled += DeActivate;
        controller.selectAction.action.started += Select;
        controller.selectAction.action.canceled += DeSelect;

        //scale x for left or right hand
        transform.localScale = new Vector3(transform.localScale.x * (RightHand ? 1f : -1f), transform.localScale.y, transform.localScale.z);
    }


/*    
    // Update is called once per frame
    void Update()
    {
    }
*/    

    private void Activate(InputAction.CallbackContext obj)
    {
        animator.SetBool("activate", true);
        //Debug.Log("Activated!!");
    }

    private void DeActivate(InputAction.CallbackContext obj)
    {
        animator.SetBool("activate", false);
        //Debug.Log("DeActivated!!");
    }

    private void Select(InputAction.CallbackContext obj)
    {
        animator.SetBool("select", true);
        //Debug.Log("Selected!!");
    }
    private void DeSelect(InputAction.CallbackContext obj)
    {
        animator.SetBool("select", false);
        //Debug.Log("DeSelected!!");
    }
}
