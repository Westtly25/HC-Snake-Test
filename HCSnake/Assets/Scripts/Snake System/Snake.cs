using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Snake : MonoBehaviour
{
    [SerializeField] private Transform head;

    [SerializeField] private List<Transform> bodie;

    #region Events
    public event Action<Color> OnColorChanged;
    #endregion


    
}
