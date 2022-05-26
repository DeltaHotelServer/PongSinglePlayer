using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rigidbody1;

    public Rigidbody2D Getrigidbody()
    {
        return rigidbody1;
    }

    private void Setrigidbody(Rigidbody2D value)
    {
        rigidbody1 = value;
    }

    private void Awake()
    {
        Setrigidbody(GetComponent<Rigidbody2D>());
    }

    public void ResetPosition()
    {
        Getrigidbody().velocity = Vector2.zero;
        Getrigidbody().position = new Vector2(Getrigidbody().position.x, 0f);

    }
}
