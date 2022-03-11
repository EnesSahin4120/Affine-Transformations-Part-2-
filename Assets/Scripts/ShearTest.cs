using UnityEngine;

public class ShearTest : MonoBehaviour
{
    public GameObject[] Spheres;
    public float X_Shear;
    public float Y_Shear;
    public float Z_Shear;

    private bool isPressed;

    private void Start()
    {
        DrawLinesBetweenPoints(Color.black);
    }

    private void Update()
    {
        if (!isPressed && Input.GetMouseButtonDown(0))
        {
            isPressed = true;

            foreach (GameObject current in Spheres)
            {
                Coordinates position = new Coordinates(current.transform.position, 1);
                current.transform.position = Mathematics.Shear(position, X_Shear, Y_Shear, Z_Shear).ToVector();
            }

            DrawLinesBetweenPoints(Color.red);
        }
    }

    private void DrawLinesBetweenPoints(Color targetColor)
    {
        Debug.DrawLine(Spheres[0].transform.position, Spheres[1].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[1].transform.position, Spheres[3].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[3].transform.position, Spheres[2].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[2].transform.position, Spheres[0].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[5].transform.position, Spheres[7].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[7].transform.position, Spheres[6].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[6].transform.position, Spheres[4].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[4].transform.position, Spheres[5].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[4].transform.position, Spheres[0].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[5].transform.position, Spheres[1].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[7].transform.position, Spheres[3].transform.position, targetColor, Mathf.Infinity);
        Debug.DrawLine(Spheres[6].transform.position, Spheres[2].transform.position, targetColor, Mathf.Infinity);
    }
}
