using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    public float rotation;

    public float baseAcceleration = 4;
    public float backwardsAccelerationModifier;

    public Transform fan;
    public float fanSpeed;

    private float height;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        height = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E)) 
               
        {
            moveSpeed = 0;
        }

        // keep fixed height
        transform.position = new Vector3(transform.position.x, height, transform.position.z);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // adjust acceleration if moving backwards
        float acceleration = (vertical > 0)
            ? baseAcceleration
            : baseAcceleration * backwardsAccelerationModifier; 

        rb.velocity = rb.velocity + transform.forward * vertical * acceleration;
        rb.velocity = Vector3.Slerp(rb.velocity,
            transform.right * horizontal,
            rotation * Time.deltaTime * rb.velocity.magnitude);

        if (rb.velocity.magnitude > 0)
        {
            float dot = Vector3.Dot(rb.velocity, transform.forward);
            transform.forward = rb.velocity * (dot / Mathf.Abs(dot));
        }
        
        
        
        //transform.forward = rb.velocity * (vertical / Mathf.Abs(vertical));

        //transform.Rotate(Vector3.up, horizontal * rotationSpeed);

        fan.Rotate(Vector3.forward, fanSpeed * vertical * 360 * Time.deltaTime);

        //Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), rb.velocity.y, Input.GetAxisRaw("Vertical")).normalized;
        //rb.velocity = move * speed;
    }
}
