using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public bool m_OnPoint;

    public bool Move(Vector2 direction)
    {
        if (BoxBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            transform.Translate(direction);
            TestForOnPoint();
            return true;
        }
    }

    bool BoxBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y && box != gameObject)
            {
                return true;
            }
        }
        return false;
    }

    void TestForOnPoint()
    {
        GameObject[] points = GameObject.FindGameObjectsWithTag("Point");
        foreach (var point in points)
        {
            if (transform.position.x == point.transform.position.x && transform.position.y == point.transform.position.y)
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                m_OnPoint = true;
                return;
            }
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        m_OnPoint = false;
    }
}
