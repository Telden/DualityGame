using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

public class HoverOver : MonoBehaviour
{
    public Canvas attackMenu;
    public Button Movement;
    Vector3 characterPos;
    Vector2 CursorPosition;
    bool moving = false;
    private LineRenderer line;

    // Use this for initialization
    void Start()
    {
        Button tmp = Movement.GetComponent<Button>();
        tmp.onClick.AddListener(moveCharacter);
        attackMenu.enabled = false;
        Movement.interactable = false;

        characterPos.z = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            characterPos.x = gameObject.transform.position.x;
            characterPos.y = gameObject.transform.position.y;
            CursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveCharacter();
            checkInput();
        }


    }

    void OnMouseEnter()
    {
        Debug.Log("Mouse Over");
        //if(Input.GetMouseButtonDown(0))
        {
            // Debug.Log("Mouse clicked");
            attackMenu.enabled = true;
            Movement.interactable = true;
        }
    }

    public void moveCharacter()
    {
        //print("Moving character");
        attackMenu.enabled = false;
        Movement.interactable = false;
        moving = true;

        line = GetComponent<LineRenderer>();
        line.SetPosition(0, characterPos);
        line.SetPosition(1, CursorPosition);


    }

    void checkInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.transform.position = CursorPosition;
            moving = false;
            line.SetPosition(0, Vector3.zero);
            line.SetPosition(1, Vector3.zero);
        }
    }
}