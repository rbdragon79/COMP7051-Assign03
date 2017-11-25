﻿using UnityEngine;
using System.Collections;

public abstract class MazeCellEdge : MonoBehaviour
{

    public MazeCell cell;
    public MazeCell otherCell;
    public MazeDirectionEnum direction;

    public void Initialize(MazeCell cell, MazeCell otherCell, MazeDirectionEnum direction)
    {
        this.cell = cell;
        this.otherCell = otherCell;
        this.direction = direction;
        cell.SetEdge(direction, this);
        transform.parent = cell.transform;
        transform.localPosition = Vector3.zero;
        transform.localRotation = direction.ToRotation();
    }

    public virtual void OnPlayerEntered() { }

    public virtual void OnPlayerExited() { }
}
