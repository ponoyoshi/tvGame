using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuProfileBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    void Start()
    {
        StartCoroutine();
    }

    private void StartCoroutine()
    {
        StartCoroutine(PlayAnimationAfterDelay());
    }

    private IEnumerator PlayAnimationAfterDelay()
    {
        yield return new WaitForSeconds(0.64516f);
        if (Random.Range(0, 1) >= 0.5)
        {
            animator.SetTrigger("Scale");
        }

    }
}
