using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PercentageRatio", menuName = "PercentageRatio", order = 15)]
public class PercentageRatio : ScriptableObject
{
    public int numberPeople;
    [SerializeField] private int minX;
    [SerializeField] private int minY;
    [SerializeField] private int maxX;
    [SerializeField] private int maxY;

    public int _minY => this.minY;
    public int _minX => this.minX;
    public int _maxX => this.maxX;
    public int _maxY => this.maxY;



}
