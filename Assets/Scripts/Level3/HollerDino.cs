using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HollerDino : MonoBehaviour
{
    public GameObject target;
    public UnityEvent _event;
    public bool done = false;
    public HollerMeat meat;
    
    
    public AudioSource dyno_eat;
    public GameObject dyno_dead;
    public AudioSource normal3;

    public GameObject dyndyn;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && meat.done)
        {
            _event.Invoke();
            done = true;
            Destroy(GetComponent<BoxCollider>());
            
            StartCoroutine(StartAnim.SoundFade(dyno_eat, -1, 0, 1f));
            StartCoroutine(StartAnim.SoundFade(normal3, 0, 0.2f, 1f));
            dyno_dead.SetActive(true);
            dyndyn.SetActive(false);

            StartCoroutine(Anim());
        }
    }

    IEnumerator Anim()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("End");
    }
    
    
}
