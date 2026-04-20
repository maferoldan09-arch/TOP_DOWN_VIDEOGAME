using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}