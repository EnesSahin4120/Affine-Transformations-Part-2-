using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public float Square(float grade)
    {
        return grade * grade;
    }

    static public float Distance(Coordinates coord1, Coordinates coord2)
    {
        float diffSquared = Square(coord1.x - coord2.x) +
            Square(coord1.y - coord2.y) +
            Square(coord1.z - coord2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public Coordinates ReflectVector(Coordinates originVector,Coordinates normalVector)
    {
        Coordinates originOnNormal = Projection(originVector, normalVector);
        float xReflect = originVector.x - 2 * (originOnNormal.x);
        float yReflect = originVector.y - 2 * (originOnNormal.y);
        float zReflect = originVector.z - 2 * (originOnNormal.z);

        Coordinates result = new Coordinates(xReflect, yReflect, zReflect);
        return result;
    }

    static public Coordinates Projection(Coordinates vector1, Coordinates vector2)
    {
        float numeratorPart = Dot(vector1, vector2);
        float vector2Length = VectorLength(vector2);
        float denominatorPart = Square(vector2Length);
        Coordinates resultCoordinate = new Coordinates(vector2.x * (numeratorPart / denominatorPart), vector2.y * (numeratorPart / denominatorPart), vector2.z * (numeratorPart / denominatorPart));

        return resultCoordinate;
    }

    static public float VectorLength(Coordinates vector)
    {
        float length = Distance(new Coordinates(0, 0, 0), vector);
        return length;
    }

    static public float Dot(Coordinates vector1, Coordinates vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public Coordinates Scale(Coordinates position, float xScale, float yScale, float zScale)
    {
        float[,] scaleElements = { { xScale, 0, 0, 0 },
                                   { 0, yScale, 0, 0 },
                                   { 0, 0, zScale, 0 },
                                   { 0, 0, 0, 1 }
        };
        Matrix scaleMatrix = new Matrix(4, 4, scaleElements);
        Matrix posMatrix = new Matrix(4, 1, position.AsMatrixElements());

        Matrix resultMatrix = scaleMatrix * posMatrix;
        return resultMatrix.AsCoordinates();
    }

    static public Coordinates Reflect(Coordinates position)
    {
        float[,] reflectElements = { { 1, 0, 0, 0 },
                                     { 0 ,-1, 0, 0 },
                                     { 0, 0, 1, 0 },
                                     { 0, 0, 0, 1 }
        };
        Matrix reflectMatrix = new Matrix(4, 4, reflectElements);
        Matrix posMatrix = new Matrix(4, 1, position.AsMatrixElements());

        Matrix resultMatrix = reflectMatrix * posMatrix;
        return resultMatrix.AsCoordinates();
    }

    static public Coordinates Shear(Coordinates position, float xShear, float yShear, float zShear)
    {
        float[,] shearElements = { { 1, yShear, zShear, 0 },
                                   { xShear, 1, zShear, 0 },
                                   { xShear, yShear, 1, 0 },
                                   { 0, 0, 0, 1 } 
        };
        Matrix shearMatrix = new Matrix(4, 4, shearElements);
        Matrix posMatrix = new Matrix(4, 1, position.AsMatrixElements());

        Matrix resultMatrix = shearMatrix * posMatrix;
        return resultMatrix.AsCoordinates();
    }
}
