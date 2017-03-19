using UnityEngine;
using System;
using UnityUtilities.ObjectPool;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private EnemyType type;
    [SerializeField]
    private int points = 1;
    [SerializeField]
    private float movementSpeed = 1f;

    private void Update()
    {
        if(transform.position != Vector3.zero)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, (movementSpeed + Mathf.Sign(GameManager.Current.Points)) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag != "Segment") return;
        if (collider.name == Enum.GetName(typeof(EnemyType), type))
        {
            GameManager.Current.Points += points;
            ScrollingPopup.Create("+1 Point!", transform.position);
        }
        else
        {
            GameManager.Current.Lives -= 1;
            ScrollingPopup.Create("-1 Life!", transform.position);
        }

        ObjectPool.Destroy(gameObject);
    }
}
