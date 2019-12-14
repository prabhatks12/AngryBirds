using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ball : MonoBehaviour
{

    public Rigidbody2D rb;
    public float releaseTime = .15f;
    private bool isPressed = false;
    private Vector3 mOffset;
    private float mZCoord;
    public Canvas cv;

    void start()
    {
        cv.enabled=false;
    }

    void update() {

        if (isPressed)
        {

            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;

        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);

        GetComponent<SpringJoint2D>().enabled = false;
        
        Invoke("AtTheEnd", 5f);



    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
        gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        isPressed = true;
        rb.isKinematic = true;
        
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);

    }

    void OnMouseDrag()
    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }
    public void AtTheEnd()
    {
        Destroy(gameObject);
        cv.gameObject.SetActive(true);
    }

    




}
