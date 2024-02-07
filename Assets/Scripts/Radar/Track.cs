using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Track : MonoBehaviour
{
    private Camera myCam;
    public LayerMask players;
    public LayerMask obstacle;

    private List<GameObject> unitsSelected = new List<GameObject>();
    RadarControl controls;

    void Start()
    {
        controls = new RadarControl();
        // TO DO
        //change to specific player camera
        myCam = Camera.main;
    }

    void Update()
    {
        if (controls.RadarControlls.SelectArea.WasPressedThisFrame())
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, Mathf.Infinity, players))
            {
                SelectArea(hit.collider.gameObject);
            }
            else
            {
                Deselect();
            }
        }
    }

    public void SelectArea(GameObject unitToAdd)
    {

    }

    public void NextTarget()
    {

    }

    public void Deselect()
    { 
        unitsSelected.Clear();
    }

    private void OnEnable()
    {
        controls.RadarControlls.Enable();
    }

    private void OnDisable()
    {
        controls.RadarControlls.Disable();
    }
}
