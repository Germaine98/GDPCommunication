//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CorrectPosition : MonoBehaviour
//{
//    [SerializeField] private SpriteRenderer _renderer;
//    private bool _dragging, _placed;

//    private BoxSlot _slot;

//    Vector2 _originalPosition;



//    public void Init(BoxSlot slot)
//    {
//        _renderer.sprite = slot.Renderer.sprite;
//    }

//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void OnMouseUp()
//    {
//        if (Vector2.Distance(transform.position, _slot.transfrom.position < 3))
//            {
//            transform.position = _slot.transform.position;
//            _slot.Placed();
//            _placed = true;
//        }

//        else
//        {
//            transform.position = _originalPosition;
//            _dragging = false;

//        }

//    }
//}
