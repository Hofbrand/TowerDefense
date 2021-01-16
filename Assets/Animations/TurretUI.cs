using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretUI : MonoBehaviour
{
    public GameObject ui;

    private Node target;

    public void SetTarget(Node _target)
    {
       this.target = _target;

        transform.position = target.GetBuildPosition();

        ui.SetActive(true);
    }

    public void HideUI()
    {
        ui.SetActive(false);
    }
}
