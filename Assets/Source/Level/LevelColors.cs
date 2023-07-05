using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelColors : MonoBehaviour
{
    [Header("Level Material")]
    [Header("Ground")]
    [SerializeField] private Material _groungMaterial;
    [SerializeField] private Material _borderMaterial;
    [Space][Header("Progress Bar")]
    [SerializeField] private Image _progressFill;
    [Space][Header("Fade Backdround")]
    [SerializeField] private Image _fadeBackgroundDown;
    [SerializeField] private Image _fadeBackgroundUp;

    [Space][Header("Level Colors")]
    [Header("Ground")]
    [SerializeField] private Color _groungColor;
    [SerializeField] private Color _borderColor;
    [Space][Header("Progress Bar")]
    [SerializeField] private Color _progressFillColor;
    [Space][Header("Background")]
    [SerializeField] private Color _cameraBackgroundColor;
    [SerializeField] private Color _fadeBackgroundDownColor;
    [SerializeField] private Color _fadeBackgroundUpColor;

    private void Awake()
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        _groungMaterial.color = _groungColor;
        _borderMaterial.color = _borderColor;
        _progressFill.color = _progressFillColor;
        Camera.main.backgroundColor = _cameraBackgroundColor;
        _fadeBackgroundDown.color = _fadeBackgroundDownColor;
        _fadeBackgroundUp.color = _fadeBackgroundUpColor;
    }

    private void OnValidate()
    {
        UpdateColor();
    }
}
