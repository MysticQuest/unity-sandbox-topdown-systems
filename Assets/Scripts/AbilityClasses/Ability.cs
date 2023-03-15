using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{
    public float manaCost;

    public virtual void DisplayInfo()
    {
        Debug.Log("Category: Ability");
    }
}
