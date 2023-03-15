using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveVector
{
    /// <summary>
    /// Interface that implements a behavior class
    /// </summary>
    /// <param name="direction"> The direction vector of the movement </param>
    void SetVector(Vector3 direction);
}
