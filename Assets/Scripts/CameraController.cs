
using UnityEngine;

public class CameraController : MonoBehaviour {
    public GameObject ball;

    public float dampTime = 0.15f;

    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        Vector3 point = Camera.main.WorldToViewportPoint(ball.transform.position);
        Vector3 delta = ball.transform.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        delta.y = 0.0f;
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
