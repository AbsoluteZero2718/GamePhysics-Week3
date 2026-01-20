using UnityEngine;

public class SampleRaycastNormal : MonoBehaviour
{
    public Transform objectToPlace;
    public Camera gameCamera;

    // Update is called once per frame
    void Update()
    {
        Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            objectToPlace.position = hit.point;
            objectToPlace.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
        }
    }
}
