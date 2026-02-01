using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 10;
    private Rigidbody2D characterBody;
    private Vector2 velocity;
    private Vector2 inputMovement;
    private bool isFacingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity = new Vector2 (speed, speed);
        characterBody = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        // Проверяем: если идем влево, а смотрим вправо — поворачиваем
        if (inputMovement.x < 0 && isFacingRight)
        {
            Flip();
        }
        // Если идем вправо, а смотрим влево — поворачиваем
        else if (inputMovement.x > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Меняем состояние на противоположное при повороте
        isFacingRight = !isFacingRight;

        // флипаем на 180 градусов
        transform.Rotate(0f, 180f, 0f);
    }

    private void FixedUpdate()
    {
        // В FixedUpdate правильно использовать fixedDeltaTime
        Vector2 delta = inputMovement * velocity * Time.fixedDeltaTime;
        characterBody.MovePosition(characterBody.position + delta);
    }
}