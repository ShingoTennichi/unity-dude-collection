using UnityEngine;
//using System;


public class NewBehaviourScript : MonoBehaviour
{
    [Header("Charctor Movement")]
    [SerializeField] private float speed;
    [SerializeField] private float moveRangeX;
    [SerializeField] private float moveRangeY;
    private float[] xBoundaries = { -8.6f, 8.5f };
    private float[] yBoundaries = { -3.6f, 4.6f };

    [Header("Charctor Life")]
    [SerializeField] private float lifeSpan;
    private float age = 0;

    private Animator animator;
    private Vector2 initialPosition = new Vector2(0.18f, 3.36f);
    private Vector2 targetPosition = new Vector2(0.09f, -2.03f);
    private bool initialMove = true;

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("move",true);
        transform.position = initialPosition;
    }

    private void Update()
    {
        if (this.gameObject)
        {
            if (initialMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (transform.position == (Vector3)targetPosition)
                {
                    initialMove = false;
                    targetPosition = GetRandomPosition();
                }

            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (transform.position == (Vector3)targetPosition)
                {
                    targetPosition = GetRandomPosition();
                }
            }

            age += Time.deltaTime;
            if (age > lifeSpan)
            {
                Destroy(this.gameObject);
            }
        }
    }


    Vector2 GetRandomPosition()
    {
        float randomX =
            System.Math.Clamp(transform.position.x + Random.Range(moveRangeX * -1, moveRangeX), xBoundaries[0], xBoundaries[1]);
        float randomY =
            System.Math.Clamp(transform.position.y + Random.Range(moveRangeY * -1, moveRangeY), yBoundaries[0], yBoundaries[1]);
        return new Vector2(randomX, randomY);
    }
}
