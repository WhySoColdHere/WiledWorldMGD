using UnityEngine;

public class EnemyAI : MonoBehaviour
{   
    public int health = 100;
    public float speed = 2f; // Скорость врага
    private Transform player;
    public GameObject deathEffect;

    void Start()
    {
        // Находим игрока по тегу "Player" (убедитесь, что у игрока стоит этот тег)
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Двигаем врага к позиции игрока
            transform.position = Vector2.MoveTowards(
                transform.position, 
                player.position, 
                speed * Time.deltaTime
            );

            // Опционально: поворот врага лицом к игроку
            // Vector2 direction = player.position - transform.position;
            // transform.right = direction; 
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Kunai"))
            {
                TakeDamage(KunaiThrow.damage); // Значение пока берётся не из скрипта куная
                Destroy(collision.gameObject); // Уничтожаем кунай при столкновении
            }
        }

        void TakeDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }

        void Die()
        {
            // Логика смерти врага (например, анимация, звуки и т.д.)
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
}
