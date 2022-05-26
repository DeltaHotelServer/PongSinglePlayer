using UnityEngine;
using System.Collections;

public class CollisionColorChange : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("It's ALIVE and red");
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}