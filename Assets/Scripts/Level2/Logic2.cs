using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic2 : MonoBehaviour
{
    public int s = 0;

    public void inc()
    {
        s++;

        switch (s)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                SceneManager.LoadScene("Level3");
                break;
        }
    }

}
