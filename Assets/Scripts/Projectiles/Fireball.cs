using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D projectileRb;
    public float speed;
    public float projectileLife;
    private float projectileCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0) 
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        projectileRb.linearVelocity = new Vector2(speed, projectileRb.linearVelocityY);
    }

}
