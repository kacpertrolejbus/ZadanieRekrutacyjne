using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    [SerializeField] bool scrollLeft;

    float textureWidth;

    private void Start()
    {
        SetupTexture();
        if (scrollLeft) moveSpeed = -moveSpeed;
    }

    void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);

    }

    void CheckReset()
    {
        if( (Mathf.Abs(transform.position.x) - textureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    private void Update()
    {
        Scroll();
        CheckReset();
    }

}