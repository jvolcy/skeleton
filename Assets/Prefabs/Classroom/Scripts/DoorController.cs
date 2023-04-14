using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    //bool doorOpen = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleDoor()
    {
        //doorOpen = !doorOpen;
        animator.SetBool("bOpen", !animator.GetBool("bOpen"));
    }
}
