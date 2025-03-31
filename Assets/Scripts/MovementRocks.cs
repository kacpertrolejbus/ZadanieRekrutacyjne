using UnityEngine;

public class MovementRocks : MonoBehaviour
{
    public float speed = 5f; 
    private float leftEdge;
    private float elapsedTime = 0f; 
    private int speedStage = 0; 

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        elapsedTime += Time.deltaTime;

        
        HandleSpeedIncrease();

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }

    private void HandleSpeedIncrease()
    {
        if (speedStage == 0 && elapsedTime > 30f) 
        {
            speed += 0.5f;
            speedStage++;
        }
        else if (speedStage == 1 && elapsedTime > 90f) 
        {
            speed += 1.5f;
            speedStage++;
        }
        else if (speedStage == 2 && elapsedTime > 120f) 
        {
            speed += 0.7f;
            speedStage++;
        }
        else if (speedStage == 3 && elapsedTime > 180f) 
        {
            speed += 3f;
            speedStage++;
        }
        else if (speedStage == 4 && elapsedTime > 240f) 
        {
            speed += 1f;
            speedStage++;
        }
        else if (speedStage == 5 && elapsedTime > 300f) 
        {
            speed += 2.5f;
            speedStage++;
        }
    }
}
