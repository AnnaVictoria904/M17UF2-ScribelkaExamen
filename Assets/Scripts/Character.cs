using UnityEngine;

public class Character : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;

    // Method for moving the character
    public virtual void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // Method for the character to receive damage
    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    // Method to handle character's death
    protected void Die()
    {
        Debug.Log("Character has died.");
        Destroy(gameObject);
    }
}