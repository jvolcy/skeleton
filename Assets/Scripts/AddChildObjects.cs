using UnityEngine;
using UnityEditor;
using System.Collections;

// This is a modification of the script ReplaceWithPrefabs.cs found here:
// https://forum.unity.com/threads/replace-game-object-with-prefab.24311/
// This script adds a child object to the selected objects.  The child's
// transform is set to the bounds of each target object's mesh.

// CopyComponents - by Michael L. Croswell for Colorado Game Coders, LLC
// March 2010

//Modified by Kristian Helle Jespersen
//June 2011

public class AddChildObjects : ScriptableWizard
{
    public GameObject ChildPrefab;
    public GameObject[] TargetObjects;

    [MenuItem("Custom/Add Child GameObjects")]
    static void CreateWizard()
    {
        var addChildGameObjects = ScriptableWizard.DisplayWizard<AddChildObjects>("Add Child GameObjects", "Add Children");
        addChildGameObjects.TargetObjects = Selection.gameObjects;
    }

    void OnWizardCreate()
    {

        foreach (GameObject go in TargetObjects)
        {
            GameObject newObject;
            newObject = (GameObject)EditorUtility.InstantiatePrefab(ChildPrefab);

            newObject.transform.parent = go.transform;

            newObject.transform.localPosition = go.transform.localPosition;
            newObject.transform.localRotation = go.transform.localRotation;
            newObject.transform.localScale = go.transform.localScale;

            //set the newObject's transform to the bounds of the target's mesh renderer
            newObject.transform.position = go.GetComponent<MeshRenderer>().bounds.center;

            //append an "R" or "L" to the socket name if the target object has a trailing "R" or "L"
            newObject.name = "Socket";
            if (go.name.EndsWith(" R")) newObject.name += " R";
            if (go.name.EndsWith(" L")) newObject.name += " L";

            //comment out the following line to not destroy the target object
            //DestroyImmediate(go);
        }
    }

}