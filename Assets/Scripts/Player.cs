using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InputManager.Instance.OnTapEvent += Tap;
        InputManager.Instance.OnContinousEvent += HandleContinuousInput;
    }

    public void Tap(bool isTouching)
    {
        spriteRenderer.color = isTouching ? Color.red : Color.white;
    }

    private void HandleContinuousInput(Vector2 position)
    {
        Vector2 spritePos = Camera.main.ScreenToWorldPoint(position);
        transform.position = new Vector3(spritePos.x, spritePos.y, 0);
    }

}
