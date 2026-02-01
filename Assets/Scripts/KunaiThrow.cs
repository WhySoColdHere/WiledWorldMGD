using UnityEngine;

public class KunaiThrow : MonoBehaviour
{
    public static int damage;
    public int damageInspector = 25;
    public Transform FirePoint;
    public GameObject KunaiPrefab;

    void Start()
    {
    }

    void Update()
    {
        //Зеркало дамага для отображения в инспекторе
        damage = damageInspector;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(KunaiPrefab, FirePoint.position, FirePoint.rotation);
        // cameraScript.RotateToZ(angle); 
    }
}