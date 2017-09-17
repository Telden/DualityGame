using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class move : MonoBehaviour
{

    //Line drawing variables
    private LineRenderer line;
    Vector3 characterPos;
    Vector2 CursorPosition;
    bool active = false;

    // Use this for initialization
    void Start()
    {
        characterPos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            characterPos.x = gameObject.transform.position.x;
            characterPos.y = gameObject.transform.position.y;
            CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            line = GetComponent<LineRenderer>();
            line.SetPosition(0, characterPos);
            line.SetPosition(1, CursorPosition);
            checkInput();
        }

    }

    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = CursorPosition;
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            active = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
            active = false;
        }
    }

    public void init()
    {
        active = true;
    }
}
