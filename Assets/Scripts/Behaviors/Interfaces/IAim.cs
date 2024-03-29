using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAim
{
    /// <summary>
    /// Interface that implements a behavior class
    /// </summary>
    /// <param name="target"> The aim target </param>
    void Aim(Vector3 target);
}
