using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ChangeableParameters", menuName = "ChangeableParameters", order = 10)]
public class DatabaseChangeableParameters : ScriptableObject
{
    [SerializeField]
    private int connections;

    [SerializeField]
    private int queue;
    [SerializeField] private int placesInLine;

    [SerializeField]
    private int server;
    [SerializeField] private int minrequestProcessing;
    [SerializeField] private int maxrequestProcessing;

    [SerializeField]
    private int entrances;
    [SerializeField]
    private int bandwidth;
    [SerializeField]
    private int numberConnectionsQueue;
    [SerializeField] public int active1;

    public int _connections => this.connections;

    public int _queue => this.queue;
    public int _placesInLine => this.placesInLine;
    public int _server => this.server;
    public int _minrequestProcessing => this.minrequestProcessing;
    public int _maxrequestProcessing => this.maxrequestProcessing;
    public int _entrances => this.entrances;
    public int _bandwidth => this.bandwidth;
    public int _numberConnectionsQueue => this.numberConnectionsQueue;
}
