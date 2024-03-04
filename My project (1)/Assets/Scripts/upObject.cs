using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upObject : MonoBehaviour
{
    float initialRiseSpeed = 30; // Початкова швидкість підняття
    private float currentRiseSpeed;
    void Start()
    {
        currentRiseSpeed = initialRiseSpeed; // Встановлення початкової швидкості
    }

    void Update()
    {
        // Піднімання об'єкту вгору з поточною швидкістю
        transform.Translate(Vector3.up * currentRiseSpeed * Time.deltaTime);

        // Поступове зменшення швидкості підняття з часом
     /*   currentRiseSpeed -= Time.deltaTime + 0.001f; // Наприклад, можна зменшувати швидкість на 0.1 кожної секунди

        // Перевірка, чи швидкість підняття не стала меншою за 0
        if (currentRiseSpeed < 0f)
        {
            currentRiseSpeed = 0f; // Якщо швидкість стала меншою за 0, встановлюємо її в 0
        }*/
    }
}
