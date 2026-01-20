using UnityEngine;

public class TargetMove : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 5f;

    private Vector3 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float xposition = Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3(startPosition.x + xposition, startPosition.y, startPosition.z);
    }
}
