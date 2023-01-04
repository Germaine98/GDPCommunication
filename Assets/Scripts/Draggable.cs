using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    public bool isDragging;
    private Container mConainer;
    private Collider2D collider;
    private GameObject thisFile;
    private DraggingFile controller;
    public string id;
    void Start()
    {
        collider = GetComponent<Collider2D>();
        controller = FindObjectOfType<DraggingFile>();
        thisFile = GetComponent<GameObject>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Draggable collidedDraggable = collision.GetComponent<Draggable>();

        if (collidedDraggable != null && controller.prevLastDragge.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = collision.Distance(collider);
            Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= diff;
            mConainer.ClickIntoPlace(thisFile);
        }
    }
}