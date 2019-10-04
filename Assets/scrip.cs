using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class scrip : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("yooo");

     
        EditorUtility.DisplayDialog("Premier message",
                "Attention vous venez de marcher sur une case piégée !", "Oui", "Non");

        if (other.gameObject.transform.tag == "Ground")
        {
            //Do what you want when it collided with the ground
        }
        else
        {
            //Do something else
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
