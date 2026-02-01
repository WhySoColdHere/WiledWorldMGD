using UnityEngine;

public class GameCursor : MonoBehaviour
{
    public Texture2D cursorTexture;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
