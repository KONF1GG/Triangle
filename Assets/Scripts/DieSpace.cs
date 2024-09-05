using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject respawn;
    public ScoreManager scoreManager;  // Ссылка на скрипт ScoreManager

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = respawn.transform.position;
             FindObjectOfType<ScoreManager>().ResetScore();  // Сброс очков и скорости после смерти
        }
    }
}
