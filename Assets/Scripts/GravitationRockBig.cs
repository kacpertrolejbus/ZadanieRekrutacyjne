using UnityEngine;

public class GravitationRockBig : MonoBehaviour
{
    
    [SerializeField] private float forwardSpeed = 3.0f;
    [SerializeField] private float fallSpeed = 3.0f;
    [SerializeField] private float returnSpeed = 2.5f;
    [SerializeField] private float destroyYPosition = -10.0f;

    
    [SerializeField] private float difficultyIncreaseRate = 0.1f;
    [SerializeField] private float maxSpeedMultiplier = 2.0f;
    [SerializeField] private float difficultyIncreaseInterval = 5.0f;

    private float originalYPosition;
    private bool isVisible = false;
    private bool isFalling = false;
    private Camera mainCamera;
    private float speedMultiplier = 1.0f;
    private float timeSinceLastIncrease = 0f;

    private void Start()
    {
        originalYPosition = transform.position.y;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        
        UpdateDifficulty();

        
        transform.Translate(Vector3.right * forwardSpeed * speedMultiplier * Time.deltaTime);

        
        CheckIfVisible();

        
        if (isVisible && Input.GetKeyDown(KeyCode.Space))
        {
            isFalling = !isFalling;
        }

        
        ManageVerticalMovement();

        
        if (transform.position.y <= destroyYPosition)
        {
            Destroy(gameObject);
        }
    }

    private void UpdateDifficulty()
    {
        
        timeSinceLastIncrease += Time.deltaTime;

        if (timeSinceLastIncrease >= difficultyIncreaseInterval)
        {
            timeSinceLastIncrease = 0f;

           
            speedMultiplier = Mathf.Min(speedMultiplier + difficultyIncreaseRate, maxSpeedMultiplier);
        }
    }

    private void CheckIfVisible()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        isVisible = (viewportPosition.x > 0 && viewportPosition.x < 1 &&
                     viewportPosition.y > 0 && viewportPosition.y < 1 &&
                     viewportPosition.z > 0);
    }

    private void ManageVerticalMovement()
    {
        if (isFalling)
        {
            
            transform.Translate(Vector3.down * fallSpeed * speedMultiplier * Time.deltaTime);
        }
        else if (transform.position.y < originalYPosition)
        {
            
            Vector3 targetPosition = new Vector3(
                transform.position.x,
                originalYPosition,
                transform.position.z
            );

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPosition,
                returnSpeed * speedMultiplier * Time.deltaTime
            );
        }
    }
}