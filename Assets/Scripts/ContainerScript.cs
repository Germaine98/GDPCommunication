using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{

    public GameObject[] fileArray;
    private bool filled;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in fileArray)
        {
            if (Vector2.Distance(i.transform.position, transform.position) <= 2.2)
            {
                i.transform.position = transform.position;
                filled = true;
            }
            else
            {
                print("FILE LOCATION ERROR");
                filled = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ClickIntoPlace(GameObject usedFile)
    {

        if (Vector2.Distance(usedFile.transform.position, transform.position) <= 2.2)
        {
            if (filled != true)
            {
                usedFile.transform.position = transform.position;
                //FileSort();
            }
            else
            {
                //ReturnToOriginalPosition(usedFile);
            }
        }
        else
        {
            //ReturnToOriginalPosition(usedFile);
        }

    }
}
