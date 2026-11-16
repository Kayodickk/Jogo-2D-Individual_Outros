using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public Transform cameraTransform;

    [Range(0f, 1f)]
    public float parallaxX = 0.5f;

    private Vector3 startPosition;
    private Vector3 cameraStartPosition;

    private void Start()
    {
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;

        startPosition = transform.position;
        cameraStartPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        if (cameraTransform == null)
            return;

        float movementX = cameraTransform.position.x - cameraStartPosition.x;
        float movementY = cameraTransform.position.y - cameraStartPosition.y;

        transform.position = new Vector3(
            startPosition.x + movementX * parallaxX,

            // acompanha a câmera completamente no eixo Y
            startPosition.y + movementY,

            startPosition.z
        );
    }
}