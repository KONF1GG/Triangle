using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // Ссылка на TextMeshProUGUI для отображения счёта
    public TriangleMovement playerMovement;  // Ссылка на скрипт TriangleMovement

    private float startTime;  // Время начала игры
    private bool speedIncreased_15 = false;  // Флаг для проверки увеличения скорости при 15 очках
    private bool speedIncreased_50 = false;  // Флаг для проверки увеличения скорости при 50 очках

    private int scoreMultiplier = 1;  // Множитель для очков

    void Start()
    {
        startTime = Time.time;  // Запоминаем время начала игры
        UpdateScoreText();
    }

    void Update()
    {
        UpdateScoreText();  // Обновляем текст каждую секунду
        CheckScore();  // Проверяем счёт
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            float elapsedTime = Time.time - startTime;
            int score = Mathf.FloorToInt(elapsedTime) * scoreMultiplier;  // Учитываем множитель
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void ResetScore()
    {
        startTime = Time.time;  // Сбросить время начала игры
        speedIncreased_15 = false;  // Сбросить флаг увеличения скорости
        speedIncreased_50 = false;
        scoreMultiplier = 1;  // Сбросить множитель очков

        // Сбросить скорость игрока
        if (playerMovement != null)
        {
            playerMovement.ResetSpeed();
        }
    }

    void CheckScore()
    {
        float elapsedTime = Time.time - startTime;
        int score = Mathf.FloorToInt(elapsedTime);  // Считаем очки как количество секунд

        // Увеличиваем скорость на 15 очках
        if (score >= 10 && !speedIncreased_15)
        {
            if (playerMovement != null)
            {
                playerMovement.IncreaseSpeed(4f);  // Увеличить скорость на 4
                speedIncreased_15 = true;  // Устанавливаем флаг, чтобы увеличить скорость только один раз
                scoreMultiplier = 3;  // Увеличить множитель очков в 3 раза
                Debug.Log("Speed increased at 5 points");  // Отладочное сообщение
            }
        }

        // Увеличиваем скорость на 50 очках
        if (score >= 20 && !speedIncreased_50)
        {
            if (playerMovement != null)
            {
                playerMovement.IncreaseSpeed(4f);  // Увеличить скорость на 10
                speedIncreased_50 = true;  // Устанавливаем флаг, чтобы увеличить скорость только один раз
                scoreMultiplier = 5;  // Увеличить множитель очков в 5 раз
                Debug.Log("Speed increased at 15 points");  // Отладочное сообщение
            }
        }
    }
}
