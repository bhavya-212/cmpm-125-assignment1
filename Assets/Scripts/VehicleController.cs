using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.Rendering;

public class VehicleController : MonoBehaviour
{
    public TextMeshProUGUI time_label;
    public float desired_acceleration;
    public float power;
    public CheckpointController next;
    public CheckpointController target;
    public float start_time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start_time = Time.time;
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
        time_label.text = (Time.time - start_time).ToString() + " seconds";
    }

    void OnMove(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        desired_acceleration = movement.y;
    }
}