using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraControl cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
                cam.NextRoom(nextRoom);
        }
    }
}
