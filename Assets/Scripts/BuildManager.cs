﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one buildManager!");
        }
        instance = this;
        
    }

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public GameObject buildEffect;
    public GameObject sellEffect;

    public TurretUI turretUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money>= turretToBuild.cost; } }

    public void TurnOff()
    {
        turretToBuild = null;
    }
    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        turretUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        turretUI.HideUI();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

   } 
