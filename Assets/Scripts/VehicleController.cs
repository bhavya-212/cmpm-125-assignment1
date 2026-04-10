using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class VehicleController : MonoBehaviour
{
    public float desired_acceleration;
    public float power;
    public CheckpointController next;
    public CheckpointController target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(desired_acceleration * power, 0, 0));
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / 200;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        desired_acceleration = movement.y;
    }
}