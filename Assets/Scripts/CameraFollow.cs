using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на игрока
    public float smoothTime = 0.25f; // Время сглаживания(наведения)
    private Vector3 velocity = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null) {
            // Рассчитываем целевую позицию (сохраняем Z камеры)
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            // Плавно перемещаем камеру
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
