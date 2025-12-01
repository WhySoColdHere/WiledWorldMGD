using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, lenght;
    [SerializeField] GameObject cam;
    public float paralaxEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * paralaxEffect;
        float movement = cam.transform.position.x * (1 - paralaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + lenght)
        {
            startPos += lenght;
        }
        //else if (movement < startPos + lenght) 
        //{
        //    startPos -= lenght;
        //}

    }
}
