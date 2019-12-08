using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var passage = GameObject.Find("Passage1to2A").GetComponentsInChildren<MeshRenderer>();
        if (passage != null)
        {

            foreach (Component flame in passage)
            {
                flame.GetComponent<MeshRenderer>().enabled = true;
                if(flame.GetComponent<BoxCollider>() != null)
                    flame.GetComponent<BoxCollider>().enabled = true;
            }
        }

        GameObject.Find("Passage1to2A").GetComponent<BoxCollider>().enabled = true;

        var passage2 = GameObject.Find("Passage1to2B").GetComponentsInChildren<MeshRenderer>();
        if (passage2 != null)
        {

            foreach (Component flame in passage2)
            {
                flame.GetComponent<MeshRenderer>().enabled = false;
                if (flame.GetComponent<BoxCollider>() != null)    
                    flame.GetComponent<BoxCollider>().enabled = false;
            }
        }

        GameObject.Find("Passage1to2B").GetComponent<BoxCollider>().enabled = false;

        var bloc1 = GameObject.Find("Bloc1").GetComponentsInChildren<MeshRenderer>();
        if (bloc1 != null)
        {
            foreach (Component flame in bloc1)
            {
                flame.GetComponent<MeshRenderer>().enabled = false;
                if (flame.GetComponent<BoxCollider>() != null)
                    flame.GetComponent<BoxCollider>().enabled = false;
            }
        }

        var bloc2 = GameObject.Find("Bloc2").GetComponentsInChildren<MeshRenderer>();
        if (bloc2 != null)
        {
            foreach (Component flame in bloc2)
            {
                flame.GetComponent<MeshRenderer>().enabled = true;
                if(flame.GetComponent<BoxCollider>() != null)
                    flame.GetComponent<BoxCollider>().enabled = true;
            }
        }
  
    }

}

