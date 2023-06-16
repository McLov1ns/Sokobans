using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool isMoving = false;
    private Vector2 currentDirection;
    public int num_moves;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _walk;
    private Animator _animator;

    private void Awake()
    {
        InitializeAudio();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isMoving)
        {
            Move(currentDirection);
        }
    }

    public void StartMovement(Vector2 direction)
    {
        isMoving = true;
        currentDirection = direction;
    }

    public void StopMovement()
    {
        isMoving = false;
    }

    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5)
        {
            direction.x = 0;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();

        if (Blocked(transform.position, direction))
        {
            StopMovement();
            return false;
        }
        else
        {
            _animator.SetBool("IsWalking", true);
            PlaySound(_walk, 0.3f);
            Vector3 newPosition = transform.position + new Vector3(direction.x, direction.y, 0);
            transform.position = newPosition;
            num_moves++;
            StartCoroutine(StopWalkingAnimation(0.2f));
            return true;
        }
    }
    IEnumerator StopWalkingAnimation(float duration)
    {
        yield return new WaitForSeconds(duration);
        _animator.SetBool("IsWalking", false);
    }

    bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");
        foreach (var wall in walls)
        {
            if (Mathf.Approximately(wall.transform.position.x, newPos.x) && Mathf.Approximately(wall.transform.position.y, newPos.y))
            {
                StopMovement();
                return true;
            }
        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            if (Mathf.Approximately(box.transform.position.x, newPos.x) && Mathf.Approximately(box.transform.position.y, newPos.y))
            {
                Box bx = box.GetComponent<Box>();
                if (bx && bx.Move(direction))
                {
                    return false;
                }
                else
                {
                    StopMovement();
                    return true;
                }
            }
        }
        return false;
    }

    private void InitializeAudio()
    {
        // Add necessary initialization code here
    }

    private void PlaySound(AudioClip clip, float volume)
    {
        _audioSource.Stop();
        _audioSource.volume = volume;
        _audioSource.PlayOneShot(clip);
    }
}
