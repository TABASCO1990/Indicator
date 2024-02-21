using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Caller))]
public class Timer : MonoBehaviour
{
    private const int MinValue = 10;
    private const int MaxValue = 21;
    private const int EndValue = 0;

    [SerializeField] private TMP_Text _textIndicatorFirst;
    [SerializeField] private TMP_Text _textIndicatorSecond;

    [SerializeField] private Image _colorIndicatorFirst;
    [SerializeField] private Image _colorIndicatorSecond;

    private Caller _call;

    private void Awake()
    {
        _call = GetComponent<Caller>();
        SetDefaultValues();
    }

    private void OnEnable()
    {
        _call.PressedButton += OnPressedButton;

    }

    private void OnDisable()
    {
        _call.PressedButton -= OnPressedButton;
    }

    private void OnPressedButton()
    {
        if (_call.IsPressed)
        {
            IEnumerator routine1 = StartFirstIndicator();
            IEnumerator routine2 = StartSecondtIndicator();

            routine1.MoveNext();

            StartCoroutine(routine1);
            StartCoroutine(routine2);

            _colorIndicatorFirst.color = Color.red;
            _colorIndicatorSecond.color = Color.red;
        }
        else
        {
            SetDefaultValues();
            StopAllCoroutines();
        }
    }




    private IEnumerator StartFirstIndicator()
    { 
        print("1 go");
        _colorIndicatorFirst.color = Color.green;
        print(_colorIndicatorFirst.color);
        float time = Random.Range(MinValue, MaxValue);
        

        while (time >= EndValue)
        {
            yield return null;
            time -= Time.deltaTime;
            //print(time);
            _textIndicatorFirst.text = time.ToString();

            if (time < 0)
            {
                _colorIndicatorFirst.color = Color.red;
                Debug.Log("Coroutine1 finished");
                break;

            }
        }
    }

    private IEnumerator StartSecondtIndicator()
    {
        print("2 go");
        int time = Random.Range(MinValue, MaxValue);
        _colorIndicatorSecond.color = Color.green;

        while (time >= EndValue)
        {
            _textIndicatorSecond.text = time.ToString();
            time--;
            yield return new WaitForSeconds(1);
        }

        _colorIndicatorSecond.color = Color.red;       
    }

    private void SetDefaultValues()
    {
        _colorIndicatorFirst.color = Color.white;
        _colorIndicatorSecond.color = Color.white;
        _textIndicatorFirst.text = "0";
        _textIndicatorSecond.text = "0";
    }
}