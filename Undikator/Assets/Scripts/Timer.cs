using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Caller))]
public class Timer : MonoBehaviour
{
    private float timeri;
    private int seconds;

    private void Start()
    {
        IEnumerator routine1 = Coroutine1();
        IEnumerator routine2 = Coroutine2();
        routine1.MoveNext();
        StartCoroutine(routine1);
        StartCoroutine(routine2);
    }
    private IEnumerator Coroutine1()
    {
        float time = 20;

        while (true)
        {         
            yield return null;

            time -= Time.deltaTime;
            seconds = Mathf.FloorToInt(time % 60);
            //print(seconds);

            float currentTime = 20;

            if (currentTime > seconds)
            {
                
                //currentTime--;
                currentTime = seconds;
                print(currentTime);
                
            }

            

            if (time < 0)
            {
                // передаем управление другой корутине
                Debug.Log("Coroutine1 finished");
                break;
            }
        }

    }
    private IEnumerator Coroutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("Coroutine2 executed");
        }

    }

    private void SetTimer()
    {
        float currentTime = 20;

        if (currentTime < seconds)
        {
            currentTime = seconds;
        }

        print(currentTime);
    }
}
