using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSnap : MonoBehaviour
{
    public Draggable[] fileArray;
    public Container[] containerArray;
    public int answerNumber;
    private int correctCount;
    // Start is called before the first frame update
    void Start()
    {
        correctCount = 0;
        foreach (Draggable i in fileArray)
        {
            foreach (Container j in containerArray)
            {
                if (Vector2.Distance(i.transform.position, j.transform.position) <= 2.2)
                {
                    i.transform.position = j.transform.position;
                    j.filled = true;
                    //print("1here");
                }
                else
                {
                    //print("FILE LOCATION ERROR");
                    j.filled = false;
                }
            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonUp(0))
        {
            NewClick();
            CheckPositions();
        }
        //TRIGGER NEWCLICK USING MOUSE BUTTON LET GO
    }
    public void NewClick()
    {
        foreach (Draggable i in fileArray)
        {
            var fileLocked = false;
            foreach (Container j in containerArray)
            {
                if (Vector2.Distance(i.transform.position, j.transform.position) <= 2.2 && j.filled == false)
                {
                    i.transform.position = j.transform.position;
                    j.filled = true;
                    //print(filled);
                    fileLocked = true;
                    break;
                }

                else
                {

                    j.filled = false;
                }
            }
            if (fileLocked == false)
            {
                i.transform.position = i.originPos;
                //SEND OLD FILE TO OLD POSITION
            }

        }
    }
    public void CheckPositions()
    {
        foreach (Draggable i in fileArray)
        {
            foreach (Container j in containerArray)
            {
                if (i.transform.position == j.transform.position)
                {
                    if (i.finalValue == j.answerValue)
                    {
                        correctCount = correctCount + 1;
                    }
                }
            }
        }
        if (correctCount == answerNumber)
        {
            //CHANGE SCENE HERE
            print("WINWINWINWINWIN");
        }
        else
        {
            correctCount = 0;
        }
    }
}
