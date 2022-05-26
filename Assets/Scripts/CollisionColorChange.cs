using UnityEngine;
using System.Collections;
 
 public class CollisionColorChange : MonoBehaviour
{

    public Color redcolor;
    public Color bluecolor;

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("It's ALIVE and red");
            transform.GetComponent<Renderer>().material.color = Color.red;
        }

        if (other.gameObject.CompareTag("Paddle"))
        {
            Debug.Log("It's ALIVE and blue");
            transform.GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            transform.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}