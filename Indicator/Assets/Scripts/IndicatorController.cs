using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Indicator
{
    [RequireComponent(typeof(Caller))]
    public class IndicatorController : MonoBehaviour
    {
        private const int MinValue = 10;
        private const int MaxValue = 21;
        private const int EndValue = 0;

        [SerializeField] private TMP_Text _textIndicatorFirst;
        [SerializeField] private TMP_Text _textIndicatorSecond;

        [SerializeField] private Image _colorIndicatorFirst;
        [SerializeField] private Image _colorIndicatorSecond;

        private Caller _call;

        private IEnumerator _firstIndicator;
        private IEnumerator _secondIndicator;

        private int _timer;

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
                _firstIndicator = InitiateFistIndicator();
                _secondIndicator = InitiateSecondIndicator();

                _colorIndicatorFirst.color = Color.red;
                _colorIndicatorSecond.color = Color.red;

                _firstIndicator.MoveNext();
                StartCoroutine(_secondIndicator);
            }
            else
            {
                SetDefaultValues();
                StopAllCoroutines();
            }
        }

        private void InitializeData(Image color, TMP_Text text)
        {
            _timer = Random.Range(MinValue, MaxValue);
            color.color = Color.green;
            text.text = _timer.ToString();
        }

        private void SetDefaultValues()
        {
            _colorIndicatorFirst.color = Color.white;
            _colorIndicatorSecond.color = Color.white;
            _textIndicatorFirst.text = "0";
            _textIndicatorSecond.text = "0";
        }

        private IEnumerator InitiateFistIndicator()
        {
            InitializeData(_colorIndicatorFirst, _textIndicatorFirst);

            while (true)
            {
                _timer--;
                _textIndicatorFirst.text = _timer.ToString();

                yield return new WaitForSeconds(1);

                if (_timer == EndValue)
                {
                    _colorIndicatorFirst.color = Color.red;
                    break;
                }
            }

            yield return StartCoroutine(InitiateSecondIndicator());
        }

        private IEnumerator InitiateSecondIndicator()
        {
            yield return _firstIndicator;

            InitializeData(_colorIndicatorSecond, _textIndicatorSecond);

            while (true)
            {
                _timer--;
                _textIndicatorSecond.text = _timer.ToString();
                yield return new WaitForSeconds(1);

                if (_timer == EndValue)
                {
                    _colorIndicatorSecond.color = Color.red;
                    break;
                }
            }

            yield return StartCoroutine(InitiateFistIndicator());
        }
    }
}