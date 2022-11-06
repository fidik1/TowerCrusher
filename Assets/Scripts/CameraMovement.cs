using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;

    private void Start()
    {
        instance = this;
    }

    public void OnCircleDestroy()
    {
        StartCoroutine(Movement());
    }

    private IEnumerator Movement()
    {
        float targetPos = transform.position.y + 1;
        while (transform.position.y < targetPos)
        {
            transform.position += new Vector3(0, 0.05f, 0);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
