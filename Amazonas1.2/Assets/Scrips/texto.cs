using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texto : MonoBehaviour
{
    public Canvas text;
  
    // Start is called before the first frame update
    void Start()
    {
        text.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "mixamorig:Spine1")
        {
            text.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "mixamorig:Spine1")
        {
            text.enabled = false;
        }
    }

}
