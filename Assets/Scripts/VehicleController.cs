using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    public float desired_acceleration;
    public float power;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(desired_acceleration * power, 0, 0));
    }

    void OnMove(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        desired_acceleration = movement.y;
    }
}