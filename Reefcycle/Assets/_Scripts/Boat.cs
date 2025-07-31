using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    public Transform fan;
    public float fanSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), rb.velocity.y, Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = move * speed;
        fan.Rotate(Vector3.forward, fanSpeed * 360 * Time.deltaTime);
    }
}
