using UnityEngine;

public class TimeTravelTestPlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * speed * Time.deltaTime;
    }
}
