using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TestInteractableObject : FoodObjectBase
{
    public override void Interact()
    {
        Punch();
    }
}
