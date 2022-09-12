using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SHIFT { 

public class LookAtCamera : MonoBehaviour
{


        private Transform traCamera;


        private void Awake()
        {
            traCamera = Camera.main.transform;

        }
 

    // Update is called once per frame
    void Update()
    {
            LookAt();
    }

        private void LookAt() {

            transform.LookAt(traCamera);
        
        }

}

}

