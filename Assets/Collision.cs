using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] float destroyDelay = .5f;
    [SerializeField] Color32 hasPackageColor = new(0, 0, 1, 1);
    [SerializeField] Color32 noPackageColor = new(0, 1, 0, 1);
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = noPackageColor;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision happened");
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up");
            Debug.Log("Package picked up");
           
            Destroy(other.gameObject, destroyDelay);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
        else
        {
            Debug.Log("No Package available");
        }

    }
}
