using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    public bool canMove;
    public bool dragging;
    public bool isAI;
    public bool isFake;
    public Collider2D colliderBox;

    void Start()
    {
        canMove = false;
        dragging = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (isAI)
        {
            canMove = true;
            if (isFake)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Disapprove").transform.position, Time.deltaTime * 5);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Approve").transform.position, Time.deltaTime * 5);
            }
        } else
        if (Input.GetMouseButtonDown(0))
        {
            if (colliderBox == Physics2D.OverlapPoint(mousePos))
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
            if (canMove)
            {
                dragging = true;
            }
        }
        if (dragging)
        {
            transform.position = mousePos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
            dragging = false;
        }
    }
}

