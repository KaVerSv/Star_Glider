using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    public float boundary = 90f;

    private void Update()
    {
        if (transform.position.z > boundary)
        {
            MoveDown();
        }
    }

    private void MoveDown()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}