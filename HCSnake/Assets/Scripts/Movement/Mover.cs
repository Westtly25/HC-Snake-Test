using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [Header("Movement Params")]
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float sensitivity = 50f;

    private Vector2 touchPosition;
    private float sideSpeed;

    [Header("Cached Components")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Rigidbody rigidbodyComponent;
    [SerializeField] private SnakeTail snakeTail;

    private void Awake() => Initialize();

    private void Update() => TouchPosition();

    private void FixedUpdate() => Move();

    private void Initialize()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if(rigidbodyComponent == null)
        {
            rigidbodyComponent = GetComponent<Rigidbody>();
        }

        if(snakeTail == null)
        {
            snakeTail = GetComponent<SnakeTail>();
        }
    }

    private void TouchPosition()
    {
        if (Mouse.current.leftButton.isPressed || Mouse.current.rightButton.isPressed || Mouse.current.middleButton.isPressed)
        {
            Debug.Log("Pressed");
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Vector2 delta = (Vector2) mainCamera.ScreenToViewportPoint(mousePosition) - touchPosition;
            sideSpeed += delta.x * sensitivity;
            touchPosition = mainCamera.ScreenToViewportPoint(mousePosition);
        }
        else
        {
            sideSpeed = 0f;
        }
    }

    private void Move()
    {
        if (Mathf.Abs(sideSpeed) > 4) sideSpeed = 4 * Mathf.Sign(sideSpeed);

        rigidbodyComponent.velocity = new Vector3(sideSpeed * 5, transform.position.y, forwardSpeed);

        sideSpeed = 0;
    }
}