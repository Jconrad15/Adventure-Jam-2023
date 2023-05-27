using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            TryMove(Direction.North);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            TryMove(Direction.South);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            TryMove(Direction.East);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            TryMove(Direction.West);
        }
    }

    private bool IsLocationOpen(Direction d)
    {
        Vector3 targetPos = GetNeighborPosition(d, transform.position);

        // Check for collision with a collider object at target position
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(targetPos, new Vector2(0.1f, 0.1f),0);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Colliders"))
            {
                return false;
            }
        }

        return true;
    }

    private void TryMove(Direction d)
    {
        if (IsLocationOpen(d) == false) { return; }

        Vector3 targetPos = GetNeighborPosition(d, transform.position);
        transform.position = targetPos;
    }

    private static Vector2 GetNeighborPosition(
        Direction d, Vector2 startingPos)
    {
        switch (d)
        {
            case Direction.North:
                startingPos.y += 1;
                break;

            case Direction.East:
                startingPos.x += 1;
                break;

            case Direction.South:
                startingPos.y -= 1;
                break;

            case Direction.West:
                startingPos.x -= 1;
                break;
        }

        return startingPos;
    }

}
