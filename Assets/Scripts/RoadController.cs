using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoadController : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;

    public GameObject linePrefab;
    public GameObject currentLine;
    bool canDraw;


    public List<Vector2> fingerPos;

    public int percentage = 0;

    // Start is called before the first frame update
    void Start()
    {
        canDraw = true;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 tempFingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if((Vector2.Distance(tempFingerPos,fingerPos[fingerPos.Count -1]) > .1f) && canDraw)
            {
                UpdateLine(tempFingerPos);
            }
        }
    }

    void CreateLine()
    {
        currentLine = Instantiate(linePrefab, Vector3.zero, Quaternion.identity);
        lineRenderer = currentLine.GetComponent<LineRenderer>();
        edgeCollider = currentLine.GetComponent<EdgeCollider2D>();

        fingerPos.Clear();
        fingerPos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPos.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        lineRenderer.SetPosition(0, fingerPos[0]);
        lineRenderer.SetPosition(1, fingerPos[0]);
        edgeCollider.points = fingerPos.ToArray();
    }
    void UpdateLine(Vector2 newFingerPos)
    {
        
        fingerPos.Add(newFingerPos);
        lineRenderer.positionCount++;
        percentage += lineRenderer.positionCount;
      
      
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newFingerPos);
        
        edgeCollider.points = fingerPos.ToArray();


    }
}
