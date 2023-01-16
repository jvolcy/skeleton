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

    public TMP_Text FrontText;
    public TMP_Text RearText;

    // Start is called before the first frame update
    void Start()
    {
        //initialize both front and rear texts
        Text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
