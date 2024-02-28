using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Character
{
    [SerializeField] private float protection;
    public override void TakeDamage(float amount)
    {
        if (protection > 0)
        {
            protection -= amount;
        }
        else
        {
            base.TakeDamage(amount);
        }
    }
}
