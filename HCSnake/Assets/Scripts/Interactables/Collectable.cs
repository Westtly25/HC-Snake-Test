using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableTypeSO collectableSO;
}



[CreateAssetMenu(fileName = "CollectableTypeSO", menuName = "HCSnake/Scriptable Collectable Type/Collectable Type", order = 0)]
public class CollectableTypeSO : ScriptableObject
{
    
}