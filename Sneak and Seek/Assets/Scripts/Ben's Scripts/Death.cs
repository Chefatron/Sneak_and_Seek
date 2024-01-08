using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] Animator deathAnimation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(death());

            GameObject.Find("Game Manager").GetComponent<GameManager>().Rumble(1f, 1f);
        }
    }

    IEnumerator death()
    {
        deathAnimation.SetBool("Play", true);

        yield return new WaitForSeconds(1);

        GameObject.Find("Game Manager").GetComponent<GameManager>().ResetScene();
    }
}
