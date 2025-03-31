using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float transitionSpeed = 10f;
    [SerializeField] public float normalGravityValue = 1f;
    [SerializeField] public float cooldownTime = 0.5f;

    private Rigidbody2D rb;
    private float targetGravityScale;
    private float currentCooldown = 0f;
    private bool canFlip = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetGravityScale = normalGravityValue;
    }

    void Update()
    {
        if (!canFlip)
        {
            currentCooldown -= Time.deltaTime;
            if (currentCooldown <= 0f)
            {
                canFlip = true;
            }
        }

        if (canFlip && Input.GetButtonDown("Jump"))
        {
            targetGravityScale *= -1;

            canFlip = false;
            currentCooldown = cooldownTime;
        }
    }

    void FixedUpdate()
    {
        rb.gravityScale = Mathf.Lerp(rb.gravityScale, targetGravityScale, transitionSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
