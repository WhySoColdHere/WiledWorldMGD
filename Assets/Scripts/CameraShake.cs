using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float returnSpeed = 5f; 
    public float direction = 1f; // Множитель направления (1 или -1)

    void Update()
    {
        // Плавный возврат камеры в исходное состояние (0,0,0)
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * returnSpeed);
    }

    public void RotateToZ(float angle) 
    {
        // Умножаем угол на направление (например, 30 * 1, потом 30 * -1)
        transform.Rotate(0, 0, angle * direction);
        
        // Инвертируем направление для следующего раза
        direction *= -1f; 
    }
}
