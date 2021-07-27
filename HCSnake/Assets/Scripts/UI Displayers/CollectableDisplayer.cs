using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textVariable;
    [SerializeField] private ParticleSystem particles;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable() => OnValueChanged();

    private void OnDisable() => OnValueChanged();

    private void Initialize()
    {
        textVariable = GetComponentInChildren<TextMeshProUGUI>();
        particles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnValueChanged()
    {

        //particles.Play();
    }
}