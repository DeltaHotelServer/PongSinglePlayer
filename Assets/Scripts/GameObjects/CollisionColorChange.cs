using UnityEngine;
using System.Collections;

public class CollisionColorChange : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            //Debug.Log("It's ALIVE and red");
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        if (collision.gameObject.CompareTag("ComputerPaddle"))
        {
            //Debug.Log("It's ALIVE and red");
            transform.GetComponent<Renderer>().material.color = Color.green;
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            //Debug.Log("Oal");
            transform.GetComponent<Renderer>().material.color = Color.white;
        }

    }
}