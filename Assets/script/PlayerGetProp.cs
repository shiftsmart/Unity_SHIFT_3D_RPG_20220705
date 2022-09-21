using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetProp : MonoBehaviour
{

    private ObjectPoolRock objectPoolRock;
    private string propRock = "Shield05 Variant";
    private void Awake()
    {

        objectPoolRock = FindObjectOfType<ObjectPoolRock>();

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.name.Contains(propRock)) {
            objectPoolRock.ReleasePoolObject(hit.gameObject);
        
        }
    }



}
