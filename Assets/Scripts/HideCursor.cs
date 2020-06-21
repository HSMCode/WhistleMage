using UnityEngine;
using System.Collections;

public class HideCursor : MonoBehaviour
{
    // Start is called before the first frame update
    bool CursorLockedVar;
    public float hideTime = 10f;

    // define IEnumerator to be able to stop each started coroutine
    private IEnumerator coroutine;
    // add another bool to check if a coroutine was started before, to stop it to avoid double ending
    public bool coroutineRunning;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = (false);
        CursorLockedVar = (true);
        coroutineRunning = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !CursorLockedVar)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = (false);
            CursorLockedVar = (true);

            if(coroutineRunning){
                StopCoroutine(coroutine); 
                coroutineRunning = false;
            }        
        }
        else if (Input.GetKeyDown(KeyCode.E) && CursorLockedVar)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = (true);
            CursorLockedVar = (false);

            if(!coroutineRunning){
                coroutine = ShowCursorAfter(hideTime);
                StartCoroutine(coroutine);
                Debug.Log("start coroutine visible cursor at " + Time.time);  
            }
        }
    }


    IEnumerator ShowCursorAfter(float hideTime)
    {
        coroutineRunning = true;
        yield return new WaitForSeconds(hideTime);
            Cursor.visible = false;
            CursorLockedVar = true;       
            coroutineRunning = false;
            Debug.Log("hide cursor again at " + Time.time); 
    }
}