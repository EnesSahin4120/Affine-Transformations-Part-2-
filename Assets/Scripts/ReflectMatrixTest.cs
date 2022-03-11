using UnityEngine;

public class ReflectMatrixTest : MonoBehaviour
{
    public GameObject ball;
    void Start()
    {
        Coordinates position = new Coordinates(ball.transform.position, 1);
        Vector3 firstPos = ball.transform.position;
        ball.transform.position = Mathematics.Reflect(position).ToVector();
        Debug.DrawLine(firstPos, ball.transform.position, Color.red, Mathf.Infinity);
    }
}
