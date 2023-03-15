using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPerformAbility
{
    /// <summary>
    /// Interface that implements a behavior class
    /// </summary>
    /// <param name="target"> Ability target </param>
    void PerformAbility(Vector3 target);
}
