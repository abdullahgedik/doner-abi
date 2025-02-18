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

    private void Punch()
    {
        transform.DOKill();
        transform.localScale = Vector3.one;
        transform.DOPunchScale(Vector3.one * 0.1f, 0.25f);
    }
}
