using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour
{
    private float timer = 5;
    private float seconds;

    private void Start()
    {

        IEnumerator routine1 = Coroutine1();
        IEnumerator routine2 = Coroutine2();

        routine1.MoveNext();

        // Запускаем обе корутины (ведущая корутина продолжит выполнение после запуска)
        StartCoroutine(routine1);
        StartCoroutine(routine2);
    }

    private IEnumerator Coroutine1()
    {
        while (true)
        {
            yield return null;
            timer -= Time.deltaTime;
            seconds = Mathf.FloorToInt(timer % 60);


            if (seconds > 0)
                print(seconds);

            else if (seconds < 0)
            { // передаем управление другой корутине
                Debug.Log("Coroutine1 finished");
                break;
            }
        }
        yield return null;
    }
    private IEnumerator Coroutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Coroutine2 executed");
        }
        yield return null;
    }
}