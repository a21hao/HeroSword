using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthHandler : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public float depthPrecision;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        spriteRenderer.sortingOrder = (int)(-transform.position.y * depthPrecision); 
    }
}
