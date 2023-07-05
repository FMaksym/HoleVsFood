using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreEffect : MonoBehaviour
{
    [Header("Floating Text")]
    [SerializeField] private TextMesh _floatingTextPrefab;

    private void FloatingText(Vector3 position)
    {
        TextMesh floatingText = Instantiate(_floatingTextPrefab, position, Quaternion.identity, transform);
        floatingText.text = "+1";
        Destroy(floatingText.gameObject, 1);
    }

    public void ShowFloatingText(Vector3 position)
    {
        if (_floatingTextPrefab)
        {
            FloatingText(position);
        }
    }
}
