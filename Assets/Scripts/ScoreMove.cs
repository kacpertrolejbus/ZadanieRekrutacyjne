using UnityEngine;

public class ScoreSpawner : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float deadZone = -45f;

    private void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
