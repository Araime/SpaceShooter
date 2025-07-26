using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().DealDamage(damage, transform.position);

            if (GetComponent<Renderer>())
            {
                GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GetComponentInChildren<Renderer>().enabled = false;
            }

            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
