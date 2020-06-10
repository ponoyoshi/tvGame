using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuProfileBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    void Start()
    {
        StartDelayCoroutine();
    }

    private void StartDelayCoroutine()
    {
        StartCoroutine(PlayAnimationAfterDelay());
    }

    private IEnumerator PlayAnimationAfterDelay()
    {
        yield return new WaitForSeconds(0.32258064516f);

        if (Random.Range(0f, 1f) >= 0.5f)
        {
            animator.SetTrigger("Scale");
            Debug.Log("Tick");
        }

        StartDelayCoroutine();

    }
}
