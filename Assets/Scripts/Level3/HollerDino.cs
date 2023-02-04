using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class HollerDino : MonoBehaviour
{
    public GameObject target;
    public UnityEvent _event;
    public bool done = false;
    
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ENTER "+other.transform.parent.gameObject.name);
        Debug.Log("KEK "+target.gameObject.name);
        if (other.transform.parent.gameObject.name == target.gameObject.name && !done)
        {
            
            _event.Invoke();
            
            
            
            done = true;
            Destroy(GetComponent<BoxCollider>());
            SceneManager.LoadScene("End");
        }
    }
}
