using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    [Header("Cached Elements")]
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Snake snake;

    private void Awake() => Initialize();

    private void OnEnable() => snake.OnColorChanged += ChangeColor;

    private void OnDisable() => snake.OnColorChanged -= ChangeColor;

    private void Initialize()
    {
        if(meshRenderer == null)
        { 
            meshRenderer = GetComponent<MeshRenderer>();
        }

        if(snake == null)
        {
            snake = GetComponent<Snake>();
        }
    }

    public void ChangeColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}
