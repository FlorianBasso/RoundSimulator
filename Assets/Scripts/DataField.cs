using UnityEngine;
using System.Collections;

public class DataField : MonoBehaviour
{
    // Attach something to this in the inspector and move it around
    // to demonstrate the data field lookup in action.
    public Transform ExampleCharacterObject = null;

    // Don't modify this, it will be updated as the character object moves around.
    public Color ColorUnderCharacter = Color.black;

    private Texture2D mTexture = null;

    // Check for required components on startup, and find the texture to be
    // used for the data field.
    void Start()
    {
        if (collider == null)
        {
            Debug.LogError("collider required for DataField to perform texture lookups", gameObject);
        }
        if ((renderer == null) || (renderer.material == null) || (renderer.material.mainTexture == null))
        {
            Debug.LogError("renderer with a material and a main texture required for DataField to perform texture lookups", gameObject);
        }

        mTexture = renderer.material.mainTexture as Texture2D;
        if (mTexture == null)
        {
            Debug.LogError("Texture2D required for DataField to perform texture lookups", gameObject);
        }

        // Note that you must turn on Read/Write enable in the import settings for the
        // texture or else GetPixel will fail.
    }

    // Update demonstrates the use of GetColorData, but you can call
    // it from elsewhere too (this behaviour doesn't need an Update
    // method, this is just for illustration).
    void Update()
    {
        if (ExampleCharacterObject != null)
        {
            ColorUnderCharacter = GetColorData(ExampleCharacterObject.position);
        }
    }

    // Find the color data under a given position.
    public Color GetColorData(Vector3 position)
    {
        // Default to black if we find no data.
        Color colorData = Color.black;

        // Create a down-pointing ray at the position.
        Ray ray = new Ray(position, Vector3.down);
        RaycastHit hit;

        // Check for a hit, using some arbitrarily long ray length.
        if (collider.Raycast(ray, out hit, 10000.0f))
        {
            colorData = mTexture.GetPixelBilinear(hit.textureCoord2.x, hit.textureCoord2.y);
            //colorData = mTexture.GetPixelBilinear(hit.textureCoord.x, hit.textureCoord.y);
        }

        return colorData;
    }
}
