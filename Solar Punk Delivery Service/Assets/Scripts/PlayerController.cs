using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Action<Vector2> cbOnPlayerFinishMove;
    private Action<Vector2> cbOnPlayerStartMove;
    private Action cbOnPlayerCannotMove;

    private Animator animator;

    private enum PreviousAction { Move, Talk, Collect, CreatePotion, Sleep };

    private bool movingEnabled = true;

    private bool isMoving = false;
    [SerializeField]
    private float speed = 5f;

    private float movementTimer = 0f;
    private float movementMaxTime = 0.05f;

    private PreviousAction previousAction;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        GetPlayerInput();
    }

    private void GetPlayerInput()
    {
        movementTimer += Time.deltaTime;
        if (movementTimer < movementMaxTime)
        {
            return;
        }
        movementTimer = 0f;

        if (movingEnabled == false) { return; }
        
        // Don't get new input if currently moving
        if (isMoving) { return; }

        bool moved = false;
        if (Input.GetKey(KeyCode.W))
        {
            if (TryMove(Direction.North))
            {
                moved = true;
                animator.SetTrigger("North");
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (TryMove(Direction.South))
            {
                moved = true;
                animator.SetTrigger("South");
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (TryMove(Direction.East))
            {
                moved = true;
                animator.SetTrigger("East");
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (TryMove(Direction.West))
            {
                moved = true;
                animator.SetTrigger("West");
            }
        }

        if (moved)
        {
            if (previousAction == PreviousAction.Talk)
            {
                FindObjectOfType<TextDisplayer>().HideText();
            }
            previousAction = PreviousAction.Move;
        }
    }

    private bool IsLocationOpen(Direction d)
    {
        Vector3 targetPos = GetNeighborPosition(d, transform.position);

        // Check for collision with a collider object at target position
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(
            targetPos, new Vector2(0.1f, 0.1f), 0);
        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Colliders"))
            {
                cbOnPlayerCannotMove?.Invoke();
                return false;
            }
            else if (hitCollider.CompareTag("NPC"))
            {
                hitCollider.gameObject.GetComponent<NPC>().Talk();
                previousAction = PreviousAction.Talk;
                return false;
            }
            else if (hitCollider.CompareTag("Collectable"))
            {
                hitCollider.gameObject.GetComponent<Collectable>().Collect();
                previousAction = PreviousAction.Collect;
                return false;
            }
            else if (hitCollider.CompareTag("PotionTable"))
            {
                hitCollider.gameObject.GetComponent<PotionTable>().OpenBrewingUI();
                previousAction = PreviousAction.CreatePotion;
                return false;
            }
            else if (hitCollider.CompareTag("SleepLocation"))
            {
                hitCollider.gameObject.GetComponent<Sleep>().StartSleep();
                previousAction = PreviousAction.Sleep;
                return false;
            }
        }

        return true;
    }

    private bool TryMove(Direction d)
    {
        if (IsLocationOpen(d) == false)
        {
            return false;
        }

        Vector3 targetPos = GetNeighborPosition(d, transform.position);
        cbOnPlayerStartMove?.Invoke(targetPos);

        StartCoroutine(LerpMove(targetPos));
        return true;
    }

    private IEnumerator LerpMove(Vector2 targetPos)
    {
        Vector2 startPos = transform.position;
        isMoving = true;
        float timer = 0f;

        while (timer <= 1f)
        {
            transform.position = Vector2.Lerp(
                startPos, targetPos, timer);
            timer += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }

        transform.position = targetPos;
        cbOnPlayerFinishMove?.Invoke(transform.position);
        isMoving = false;
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

    public void EnableMovement()
    {
        movingEnabled = true;
    }

    public void DisableMovement()
    {
        movingEnabled = false;
    }

    public void RegisterOnPlayerFinishMove(Action<Vector2> callbackfunc)
    {
        cbOnPlayerFinishMove += callbackfunc;
    }

    public void UnregisterOnPlayerFinishMove(Action<Vector2> callbackfunc)
    {
        cbOnPlayerFinishMove -= callbackfunc;
    }

    public void RegisterOnPlayerStartMove(Action<Vector2> callbackfunc)
    {
        cbOnPlayerStartMove += callbackfunc;
    }

    public void UnregisterOnPlayerStartMove(Action<Vector2> callbackfunc)
    {
        cbOnPlayerStartMove -= callbackfunc;
    }

    public void RegisterOnPlayerCannotMove(Action callbackfunc)
    {
        cbOnPlayerCannotMove += callbackfunc;
    }

    public void UnregisterOnPlayerCannotMove(Action callbackfunc)
    {
        cbOnPlayerCannotMove -= callbackfunc;
    }
}
