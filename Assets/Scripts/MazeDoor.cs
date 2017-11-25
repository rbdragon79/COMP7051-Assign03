using UnityEngine;

public class MazeDoor : MazeHall {
	private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _animator.SetBool("Open", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _animator.SetBool("Open", false);
        }
    }
}