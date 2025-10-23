using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] palyercontroller capsule;   

    AudioSource audioSource;

    [SerializeField] AudioClip successClip;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip coinClip;

    private float reloadDelay = 1f;         
    private float nextLevelDelay = 5f;  

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Fail();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Success();
        }
        else if (other.gameObject.CompareTag("Coins"))
        {
            Score();
        }
    }

    void Success()
    {
        capsule.enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(successClip);
        Invoke(nameof(LoadNextLevel), nextLevelDelay);
    }

    void Fail()
    {
        capsule.enabled = false;
        audioSource.Stop();
        audioSource.PlayOneShot(deathClip);
        Invoke(nameof(ReloadLevel), reloadDelay);
    }

    void Score()
    {
        // Just play coin sound instantly, do NOT disable movement
        audioSource.PlayOneShot(coinClip);
        // Optional: destroy coin after pickup
        // Destroy(other.gameObject);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
