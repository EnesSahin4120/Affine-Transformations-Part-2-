using UnityEngine;

public class ReflectVectorTest : MonoBehaviour
{
    public Transform rayOrigin;
    public Transform rayTarget;

    void Start()
    {
        Vector3 dir = new Vector3(rayTarget.position.x - rayOrigin.position.x, rayTarget.position.y - rayOrigin.position.y, rayTarget.position.z - rayOrigin.position.z);

        RaycastHit hit;
        if(Physics.Raycast(rayOrigin.position,dir,out hit, Mathf.Infinity))
        {
            if(hit.collider.gameObject!=null)
            {
                Debug.DrawLine(rayOrigin.position, hit.point, Color.red, Mathf.Infinity);

                Coordinates originVector = new Coordinates(-rayOrigin.position);
                Coordinates normalVector = new Coordinates(hit.collider.transform.up);
                Vector3 reflectVector = Mathematics.ReflectVector(originVector, normalVector).ToVector();

                Debug.DrawLine(hit.point, reflectVector, Color.red, Mathf.Infinity);
            }
        }
    }
}
