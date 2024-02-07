using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    //graphical
    Camera myCam;
    [SerializeField] RectTransform boxVisual;
    //logical
    Rect selectionBox;

    Vector2 startPoition = Vector2.zero;
    Vector2 endPoition = Vector2.zero;
    Vector2 size = Vector2.zero;

    //input
    RadarControl controls;

    //tracked units
    public List<GameObject> trackedUnits = new List<GameObject>();

    void Start()
    {
        myCam = GetComponentInParent<Camera>();
        selectionBox = new Rect();
    }

    private void Awake()
    {
        controls = new RadarControl();
    }


    void Update()
    {
        DrawVisual();
        if (controls.RadarControlls.SelectArea.WasPressedThisFrame())
        {
            size.Set(400, 300);
            DrawVisual();
            
        }
        if (controls.RadarControlls.SelectArea.WasReleasedThisFrame())
        {
            DrawSelection();
            SelectUnits();
            size = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        boxVisual.sizeDelta = size;
    }

    void DrawSelection()
    {
        selectionBox.Set(0, 0, size.x, size.y);
    }

    void SelectUnits()
    {
        foreach (var unit in UnitSelections.Instance.units)
        {
            if (selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                Select(unit);
            }
        }
    }

    void Select(GameObject unitToAdd)
    {
        if (!UnitSelections.Instance.units.Contains(unitToAdd))
        {
            trackedUnits.Add(unitToAdd);
        }
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
