using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Plane")) {
            Destroy(gameObject);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
