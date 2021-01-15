using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseStandartTurret()
    {
        Debug.Log("Standart Turret Purchased");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void PurchaseMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void PurchaseLaserBeamer()
    {
        buildManager.SelectTurretToBuild(laserBeamer);
    }
}
