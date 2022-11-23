using System.Collections;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;

    private void Awake() => Instance = this;

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
        transform.DOMove(new Vector3(0, transform.position.y - 0.4f, transform.position.z), 0.15f);
        yield return new WaitForSeconds(0.15f);
        transform.DOMove(new Vector3(0, transform.position.y + 0.4f, transform.position.z), 0.15f);
        yield return new WaitForSeconds(0.15f);
        transform.DOMove(new Vector3(0, transform.position.y - 0.2f, transform.position.z), 0.1f);
        yield return new WaitForSeconds(0.1f);
        transform.DOMove(new Vector3(0, transform.position.y + 0.2f, transform.position.z), 0.1f);
    }
}
