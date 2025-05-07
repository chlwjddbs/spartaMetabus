using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageHandler
{
    float Defence { get; }

    void TakeDamage(float damage) { }
}
