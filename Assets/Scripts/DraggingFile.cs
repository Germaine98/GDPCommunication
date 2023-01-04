using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggingFile : MonoBehaviour
{
    public Draggable prevLastDragge => lastDragged;
    public Container mConainer;
    private bool dragActive = false;
    private Vector2 screenPosition;
    private Vector2 worldPosition;
    private Draggable lastDragged;



    void Awake()
    {
        DraggingFile[] controllers = FindObjectsOfType<DraggingFile>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dragActive && (Input.GetMouseButtonDown(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
        {
            Drop(lastDragged);
            return;
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            screenPosition = new Vector2(mousePos.x, mousePos.y);

        }
        else if (Input.touchCount > 0)
        {
            screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }
        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        if (dragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    lastDragged = draggable;
                    InitiateDrag();
                }
            }
        }
    }
    void InitiateDrag()
    {
        UpdateDragStatus(true);

    }
    void Drop(Draggable justDragged)
    {
        dragActive = false;

        //mConainer.ClickIntoPlace(justDragged);
    }
    void Drag()
    {
        lastDragged.transform.position = new Vector2(worldPosition.x, worldPosition.y);
    }
    void UpdateDragStatus(bool isDragging)
    {
        dragActive = lastDragged.isDragging = isDragging;
        if (isDragging)
        {
            lastDragged.gameObject.layer = LayerIDs.DragItems;
        }
        else
        {
            lastDragged.gameObject.layer = LayerIDs.Default;
        }
    }
}
