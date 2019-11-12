using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter(Collider col)
    {
        //verificacion de lo que entro
        if (col.name == "KOB (1)")
        {
            //col.GetComponent<Movimineto>().life = col.GetComponent<Movimineto>().life - 25f;

        }
    }
}
