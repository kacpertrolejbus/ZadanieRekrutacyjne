using UnityEngine;

public class BatMove : MonoBehaviour
{
    public float minY = -2f;
    public float maxY = 2f;
    public float speed = 0.1f;
    public float accelaration = 0.05f;

    private float direction = 1f;

    void Update()
    {
        speed += accelaration * Time.deltaTime;

        transform.position += new Vector3(0, speed * direction * Time.deltaTime, 0);

        if(transform.position.y >= maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
            direction = -1f;
        }    
        else if(transform.position.y <= minY) 
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
            direction = 1f;
        }
    }
}
