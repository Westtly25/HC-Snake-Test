using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    [SerializeField] private int snakeBaseLength = 5;
    [SerializeField] private int snakeMaxLength = 10;
    [SerializeField] private float snakeBodyDiameter;

    [SerializeField] private Transform snakeHead;
    [SerializeField] private Transform snakeBodyPartPref;

    [SerializeField] private List<Transform> snakeBodyParts;
    [SerializeField] private List<Vector3> snakeBodyPartsPositions;


    private void Awake()
    {
        Initialize();
        SetBodyPartDiameter();
        CreateBaseSnakeTail();
    }

    private void Update()
    {
        ChaseSnakeHead();
    }

    private void Initialize()
    {
        snakeBodyParts = new List<Transform>();
        snakeBodyPartsPositions = new List<Vector3>();

        snakeBodyPartsPositions.Add(snakeHead.position);
    }

    private void CreateBaseSnakeTail()
    {
        for (var i = 0; i < snakeBaseLength; i++)
        {
            AddBodyParts();
        }
    }

    private void AddBodyParts()
    {
        Transform body = Instantiate(snakeBodyPartPref, snakeBodyPartsPositions[snakeBodyPartsPositions.Count - 1], Quaternion.identity, transform);
        snakeBodyParts.Add(body);
        snakeBodyPartsPositions.Add(body.position);
    }

    private void SetBodyPartDiameter()
    {
        snakeBodyDiameter = snakeHead.GetComponent<SphereCollider>().radius * 2;
    }

    private void ChaseSnakeHead()
    {
        float distance = ((Vector3)snakeHead.position - snakeBodyPartsPositions[0]).magnitude;

        if(distance > snakeBodyDiameter)
        {
            Vector3 direction = ((Vector3)snakeHead.position - snakeBodyPartsPositions[0]).normalized;

            snakeBodyPartsPositions.Insert(0, snakeBodyPartsPositions[0] + direction * snakeBodyDiameter);
            snakeBodyPartsPositions.RemoveAt(snakeBodyPartsPositions.Count - 1);

            distance -= snakeBodyDiameter;
        }

        for (var i = 0; i < snakeBodyParts.Count; i++)
        {
            snakeBodyParts[i].position = Vector3.Lerp(snakeBodyPartsPositions[i + 1], snakeBodyPartsPositions[i], distance / snakeBodyDiameter);
        }
    }
}