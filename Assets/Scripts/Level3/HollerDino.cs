using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HollerDino : MonoBehaviour
{
    public GameObject target;
    public UnityEvent _event;
    public bool done = false;
    public HollerMeat meat;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done && meat.done)
        {
            _event.Invoke();
            done = true;
            Destroy(GetComponent<BoxCollider>());
            SceneManager.LoadScene("End");
        }
    }
}
