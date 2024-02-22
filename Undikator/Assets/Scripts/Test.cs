using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Test : MonoBehaviour
{
    IEnumerator routine1;
    IEnumerator routine2;

    private void Start()
    {
        routine1 = Coroutine1(); 
        routine2 = Coroutine2();

        
            routine1.MoveNext();
            StartCoroutine(routine2);
        
        
    }
    private IEnumerator Coroutine1()
    {
        int timer = Random.Range(3,5);

        while (true)
        {
            yield return new WaitForSeconds(1);
            timer--;
            print(timer);

            if (timer == 0)
            {
                Debug.Log("Coroutine1 finished");
                
                break;
            }
        }

        yield return StartCoroutine(Coroutine2());
    }
    private IEnumerator Coroutine2()
    {
        yield return routine1;
        int timer = Random.Range(3, 7);

        while (true)
        {           
            yield return new WaitForSeconds(1f);

            timer--;
            print(timer);

            if(timer == 0)
            {
                Debug.Log("Coroutine2 executed");
                break;
            }
            
        }

        yield return StartCoroutine(Coroutine1());
    }
}