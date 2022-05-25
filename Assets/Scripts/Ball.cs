using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public float speed = 200f;
    private Rigidbody2D rigidbody1;

    public Rigidbody2D Rigidbody { get => rigidbody1; private set => rigidbody1 = value; }

    public Ball(Rigidbody2D rigidbody)
    {
        this.Rigidbody = rigidbody;
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    public void ResetPosition()
    {
        Rigidbody.velocity = Vector2.zero;
        Rigidbody.position = Vector2.zero;
    }

    public void AddStartingForce()
    {
        // Flip a coin to determine if the ball starts left or right
        float x = Random.value < 0.5f ? -1f : 1f;

        // Flip a coin to determine if the ball goes up or down. Set the range
        // between 0.5 -> 1.0 to ensure it does not move completely horizontal.
        float y = Random.value < 0.5f ? Random.Range(-1f, -0.5f)
                                      : Random.Range(0.5f, 1f);

        Vector2 direction = new Vector2(x, y);
        Rigidbody.AddForce(direction * speed);
    }

}
