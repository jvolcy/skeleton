using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasQuadAutoParent : MonoBehaviour
{
    public Camera MainCamera;
    public float DistanceFromCamera = 0.5f;
    public float Scale = 1f;

    // Start is called before the first frame update
    void Start()
    {
        bool CameraFound = false;

        if (MainCamera != null)
            //user has specified the camera to use
        {
            transform.parent = MainCamera.transform;
            CameraFound = true;
        }
            //user has not specified the camera to use... look for it
        else
        {
            //find allgame objects that are tagged as the main camera
            GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("MainCamera");

            //Here is the sequence we will follow: 1) verify that there is at
            //least one GO tagged as "MainCamera". 2)If there is only one GO,
            //parent to it.  3) If there are multiple candidates, parent to the
            //first enabled object.  4) If there are no enabled objects, parent
            //to the first found.

            //verify that there is at least one GO tagged as "MainCamera"
            if (gameObjects.Length == 0)
            {
                Debug.Log("No object tagged as 'MainCamera' found.");
            }
            //if there is only one GO, parent to it.
            else if (gameObjects.Length == 1)
            {
                transform.parent = gameObjects[0].transform;
                CameraFound = true;
            }
            else
            {
                //if there are multiple candidates, parent to the first enabled object
                foreach (var go in gameObjects)
                {
                    if (go.activeInHierarchy)
                    {
                        transform.parent = go.transform;
                        CameraFound = true;
                        break;
                    }
                }

                //if there are no enabled objects, parent to the first found
                if (!CameraFound)
                {
                    transform.parent = gameObjects[0].transform;
                }
            }
        } //else (if (MainCamera != null))

        //set the transform
        if (CameraFound)
        {
            transform.localPosition = new Vector3(0f, 0f, DistanceFromCamera);
            transform.localScale = new Vector3(Scale, Scale, 1);
        }
    } //Start()


}
