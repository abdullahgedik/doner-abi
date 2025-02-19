using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f;
    [SerializeField] private float moveDuration = 1.0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 targetPosition = rb.position + new Vector2(speed * Time.deltaTime, 0);
            rb.DOMove(targetPosition, moveDuration).SetEase(Ease.Linear);
        }
    }
}
