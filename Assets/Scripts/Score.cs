using System.Threading;
using UnityEngine;

public class Score : MonoBehaviour
{
    public GameObject score;
    public float spawnRate = 2.0f;
    private float timer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnScore();
            timer = 0;
        }
    }

    private void spawnScore()
    {
        Instantiate(score, transform.position, transform.rotation);
    }
}
