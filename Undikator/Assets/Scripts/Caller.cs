using UnityEngine;
using System;
using TMPro;

public class Caller : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private string _textStart;
    [SerializeField] private string _textStop;

    private bool _isPressed = true;

    public event Action PressedButton;

    public bool IsPressed => _isPressed;

    private void Start()
    {
        _title.text = _textStart;
    }

    public void ToggleText()
    {
        GetText();
        PressedButton?.Invoke();
    }

    private string GetText()
    {
        if (_title.text == _textStart)
        {
            _isPressed = true;
            return _title.text = _textStop;
        }
        else
            _isPressed = false;
        return _title.text = _textStart;
    }
}
