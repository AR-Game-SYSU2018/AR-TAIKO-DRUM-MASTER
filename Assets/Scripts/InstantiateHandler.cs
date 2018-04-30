using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ARGameTaiko
{
    public class InstantiateHandler : DDOLSingleton<InstantiateHandler>
    {
        private int[,] array;

        private bool isPlaying;

        private System.DateTime startGameTime;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        int[,] CreateRandomArray()
        {
            int[,] array = new int[100, 2];
            System.Random rd = new System.Random();
            for (int i = 0; i < 100; i++)
            {
                array[i, 0] = rd.Next(800, 2501);
                array[i, 1] = rd.Next(1, 4);
            }
            return array;
        }

        public int[,] GetRandomArray()//为保证获取的数组不为空，先调用StartInstantiate()
        {
            return array;
        }

        public System.DateTime GetStartGameTime()
        {
            return startGameTime;
        }

        public void StartInstantiate()
        {
            StopInstantiate();
            isPlaying = true;
            startGameTime = System.DateTime.Now;
            array = CreateRandomArray();
            InstantiatePrefabs(array, 0);
        }

        public void StopInstantiate()
        {
            isPlaying = false;
            array = null;
            StopAllCoroutines();
        }

        public bool IsPlaying()
        {
            return isPlaying;
        }

        IEnumerator GameOver()
        {
            yield return new WaitForSeconds(3.0f);//最后一个对象生成后1.5秒执行
            FindObjectOfType<ShowScoreText>().ShowText();
            AudioSource aud = GameObject.Find("ImageTarget").GetComponent<AudioSource>();
            aud.Stop();
        }

        IEnumerator InstantiatePrefab(int[,] array, int currentIndex)
        {
            if (currentIndex < array.GetLength(0))
            {
                yield return new WaitForSeconds(((float)array[currentIndex, 0]) / 1000);
                FindObjectOfType<SpawnerController>().spawnOn(array[currentIndex, 1]);
                currentIndex++;
                InstantiatePrefabs(array, currentIndex);
            }
        }

        void InstantiatePrefabs(int[,] array, int currentIndex)
        {
            if (currentIndex < array.GetLength(0))
            {
                StartCoroutine(InstantiatePrefab(array, currentIndex));
            }
            else
            {
                StartCoroutine(GameOver());
            }
        }
    }
}
