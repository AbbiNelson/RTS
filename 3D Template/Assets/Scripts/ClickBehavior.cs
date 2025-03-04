using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ClickBehavior : MonoBehaviour
{
    public UnityEvent onClick;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            var raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(raycast))
            {
                onClick.Invoke();
            }            
        }
    }
    //Has it be public and use a basic type
    public void SwitchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
