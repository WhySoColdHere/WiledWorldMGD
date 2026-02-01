using UnityEngine;

public class KunaiMovement : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public AudioSource audioSource;
    private CameraShake _cameraShakeScript; // Сделаем приватным, чтобы не путать
    public float angle; // Угол для тряски камеры

    void Start()
    {
        // Находим объект камеры по имени (убедитесь, что имя "Main Camera" правильное в иерархии!)
        GameObject cameraObject = GameObject.Find("Main Camera");

        // Получаем компонент CameraShake с объекта камеры
        _cameraShakeScript = cameraObject.GetComponent<CameraShake>();
 
        rb.linearVelocity = transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "Player")
        {
            // Теперь вызываем функцию на скрипте, который находится на реальной камере
            if (_cameraShakeScript != null)
            {
                _cameraShakeScript.RotateToZ(angle); 
            }
            
            Debug.Log("Столкнулись с объектом:" + collision.gameObject.name);
            Destroy(gameObject);
        }
    }
}
