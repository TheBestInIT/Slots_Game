using System.Collections;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public Transform[] reels; // Масив барабанів
    public GameObject[] symbols; // Масив символів
    float spinDuration = 10f; // Тривалість обертання барабанів
    int symbolsPerReel = 9; // Кількість символів, які відображаються на одному барабані

    private bool isSpinning = false; // Прапорець, що показує, чи відбувається обертання

    void Update()
    {
        // Починаємо обертання, якщо натиснута клавіша Space і не відбувається обертання в даний момент
        if (Input.GetKeyDown(KeyCode.Space) && !isSpinning)
        {
            StartCoroutine(SpinReels());
        }
    }

    IEnumerator SpinReels()
    {
        isSpinning = true; // Встановлюємо прапорець обертання

        foreach (Transform reel in reels)
        {
            // Випадково вибираємо символ, який буде відображатися на барабані
            int randomSymbolIndex = Random.Range(0, symbols.Length);

            // Прокручуємо барабан до випадкового символу впродовж spinDuration секунд
            float timer = 0f;
            while (timer < spinDuration)
            {
                // Обчислюємо нову позицію барабану
                float newY = Mathf.Repeat(timer * 10f, symbols.Length);
                reel.localPosition = new Vector3(-12f, newY, -5f);

                timer += Time.deltaTime;
                yield return null;
            }

            // Фінальне встановлення позиції барабану для відображення вибраного символу
            reel.localPosition = new Vector3(-12f, randomSymbolIndex, -5f);
        }

        isSpinning = false; // Закінчили обертання
    }
}