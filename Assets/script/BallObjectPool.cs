using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallObjectPool : MonoBehaviour
{


    public delegate void delegateHit(GameObject ball);
    public delegateHit OnHit;
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name.Contains("Plane")) {
            OnHit(gameObject);
       
        }

    }


}
