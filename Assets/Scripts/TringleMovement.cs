using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    public float speed = 5f; // начальная скорость движения
    private float initialSpeed; // исходная скорость
    private Vector2 direction; // текущее направление движения
    private bool movingRight = true; // флаг для отслеживания направления

    void Start()
    {
        initialSpeed = speed;  // Сохраняем исходное значение скорости
        SetDirection(Vector2.right + Vector2.up);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (movingRight)
            {
                SetDirection(Vector2.left + Vector2.up);
            }
            else
            {
                SetDirection(Vector2.right + Vector2.up);
            }
            movingRight = !movingRight;
        }
    }

    void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void IncreaseSpeed(float amount)
    {
        speed += amount;
        Debug.Log("Speed increased to: " + speed);
    }

    // Метод для сброса скорости
    public void ResetSpeed()
    {
        speed = initialSpeed;
        Debug.Log("Speed reset to: " + speed);
    }
}
