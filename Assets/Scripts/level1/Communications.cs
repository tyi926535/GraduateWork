using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Communications", menuName = "Communications", order = 15)]
public class Communications : ScriptableObject
{
    [SerializeField] public GameObject queue;
    [SerializeField] public GameObject line;
    [SerializeField] public GameObject device;
}
