using System.Collections.Generic;

using UnityEngine;


public class SlotMachineLine : MonoBehaviour
{
        public Transform[] spritePos;
        public Sprite[] sprites;
        private List<GameObject> inScaneSprite = new List<GameObject>();
        private int i;
        private float speed= 0.2f; // Швидкість підйому
        
        private void Start()
        {
            foreach (Transform transformPos in spritePos)
            {
                createSprite(transformPos);
            }
        }
   

        void Update()
        {
            for (int j = inScaneSprite.Count - 1; j >= 0; j--)
            {
                GameObject transformPos = inScaneSprite[j];
                transformPos.transform.Translate(Vector3.up * speed * Time.deltaTime);
                if(transformPos.transform.position.y >16)
                {
                    Destroy(transformPos.gameObject);
                    inScaneSprite.RemoveAt(j);

                    // Зсуваємо всі інші елементи на один вперед
                    for (int k = j; k < inScaneSprite.Count; k++)
                    {
                        inScaneSprite[k].transform.position = new Vector3(inScaneSprite[k].transform.position.x, inScaneSprite[k].transform.position.y + 1, inScaneSprite[k].transform.position.z);
                    }
                }
            }
        }

        private void createSprite(Transform spawnTransform)
        {
            Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];

            // Створюємо новий GameObject з компонентом SpriteRenderer
            GameObject newSpriteObject = new GameObject("Sprite");
            SpriteRenderer spriteRenderer = newSpriteObject.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = randomSprite;
            
            // Встановлюємо позицію нового спрайта на задані координати
            newSpriteObject.transform.position = spawnTransform.position;
            newSpriteObject.transform.localScale = new Vector3(6, 6, 1);
            spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
            inScaneSprite.Add(newSpriteObject);

        }
}
