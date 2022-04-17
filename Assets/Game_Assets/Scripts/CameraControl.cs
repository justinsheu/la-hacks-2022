using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentx;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentx, transform.position.y, transform.position.z), ref velocity, speed);

    }
    public void NextRoom(Transform _newRoom)
    {
        currentx = _newRoom.position.x;
    }
}
