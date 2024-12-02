using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingBlue : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject linePrefab;
    public bool isPainting = false;

    public GameObject currentLine;

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCollider;

    private Vector3 offset;
    private Vector3 screenPoint;

    //public CinemachineVirtualCamera cam02;

    public List<Vector2> mousePositions;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void CreateLine()
    {
        currentLine = Instantiate(linePrefab);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();
        mousePositions.Clear();
        mousePositions.Add(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        mousePositions.Add(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0, mousePositions[0]);
        lineRenderer.SetPosition(1, mousePositions[1]);
        edgeCollider.points = mousePositions.ToArray();
    }

    void UpdateLine(Vector2 newMousePos)
    {
        mousePositions.Add(newMousePos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newMousePos);
        edgeCollider.points = mousePositions.ToArray();
    }
    
    private void OnMouseDown()
    {
        //Debug.Log("dragging");
        //isDrag = true;
        
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position -
                 Camera.main.ScreenToWorldPoint(
                     new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        CreateLine();
        Debug.Log("painting");
        isPainting = true;
    }
    

    private void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPos;
        Vector2 tempMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if(Vector2.Distance(tempMousePos, mousePositions[mousePositions.Count - 1]) > 0.1f)
        {
            UpdateLine(tempMousePos);
        }
        isPainting = true;
    }
}
