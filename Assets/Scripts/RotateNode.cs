using UnityEngine;
using System.Collections;

public class RotateNode : MonoBehaviour
{

    public float base_speed = 1.5f;
    public float speed_increase = 0.05f;
    public float current_speed;
    public float rotate_speed = 20.0f;
    private float min;
    private float max;
    private float units = 1.5f;
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
        max = transform.position.y;
        min = transform.position.y - units;
        current_speed = base_speed;

        direction = Vector3.down;
        print(max);
        print(min);


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.y >= max)
        {
            current_speed = base_speed;
            direction = Vector3.down;
        }

        if (transform.position.y <= min)
        {
            current_speed = base_speed;
            direction = Vector3.up;
        }
        current_speed = current_speed + speed_increase;
        transform.Translate(direction * current_speed * speed_increase * Time.deltaTime);
        transform.Rotate(0, Time.deltaTime * rotate_speed, 0);     

    }
}
