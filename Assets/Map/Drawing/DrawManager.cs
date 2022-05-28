using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawManager : MonoBehaviour
{
    [Header("Draw Properties")]
    [SerializeField][Range(0.01f, 0.9f)] private float lineZOffset = 0.01f;
    public const float RESOLUTION = 0.01f;

    [Header("Line Prefabs")]
    [SerializeField] private Line linePrefab;
    private Line currentLine;

    [Header("Other Components")]
    [SerializeField] private Camera mainCamera;

    [Header("Ray Properties")]
    [SerializeField] private float rayMaxDistance = 5f;
    [SerializeField] private LayerMask mapLayerMask;

    [Header("Other Scripts")]
    [SerializeField] private Map map;

    void Update()
    {
        DrawingProcess();
    }

    private void DrawingProcess()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayMaxDistance, mapLayerMask) && map.IsMapVisible())
        {
            if (Input.GetMouseButtonDown(0))
            {
                CreateNewCurrentLine();
                ChangeCurrentLineZOffset(currentLine.transform, lineZOffset);
            }
            else if (Input.GetMouseButton(0))
            {
                //TODO: make if pointer exit from map stop working
                currentLine.SetPosition(map.transform.InverseTransformPoint(hit.point) * map.transform.localScale.x);
            }
        }
    }

    private void CreateNewCurrentLine()
    {
        currentLine = Instantiate(linePrefab, map.transform.position, transform.rotation, transform);
    }

    private void ChangeCurrentLineZOffset(Transform currentLine,float zOffset)
    {
        currentLine.transform.localPosition = new Vector3(
            currentLine.transform.localPosition.x,
            currentLine.transform.localPosition.y + zOffset,
            currentLine.transform.localPosition.z
        );
    }
}
