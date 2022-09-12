using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SHIFT { 

public class PlayerHealth : HealthSystem
{
    private ThirdPersonController tpc;

    protected override void Awake()
    {
        base.Awake();
        tpc = GetComponent<ThirdPersonController>();
        
    }

    protected override void Dead()
    {
        base.Dead();
        tpc.enabled = false;
    }

}

}

