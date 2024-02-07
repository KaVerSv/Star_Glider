using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackAble : MonoBehaviour
{
    
    void Start()
    {
        UnitSelections.Instance.units.Add(this.gameObject);
    }

    private void OnDestroy()
    {
        UnitSelections.Instance.units.Remove(this.gameObject);
    }
}
