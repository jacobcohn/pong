using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    public float speed = 5f;
    public float clampY = 4f;

    private bool isMouseLocked;
    private float lastMouseY;

    void Start()
    {
        lastMouseY = Input.mousePosition.y;
    }

    void Update()
    {
        MovePaddle();
        UpdateIsMouseLocked();
    }

    void MovePaddle()
    {
        float move = Input.GetAxis("Vertical");

        if (Mathf.Abs(move) > 0.01f)
        {
            MovePaddleWithKeyboard(move);
            isMouseLocked = true;
        }
        else if (!isMouseLocked)
        {
            MovePaddleWithMouse();
        }
    }

    void MovePaddleWithKeyboard(float move)
    {
        transform.Translate(Vector2.up * move * speed * Time.deltaTime);
        isMouseLocked = true;
    }

    void MovePaddleWithMouse()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float targetY = Mathf.Clamp(mouseWorldPos.y, -clampY, clampY);
        float newY = Mathf.MoveTowards(transform.position.y, targetY, speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void UpdateIsMouseLocked()
    {
        float currentMouseY = Input.mousePosition.y;

        if (Mathf.Abs(currentMouseY - lastMouseY) > 0.5f)
        {
            isMouseLocked = false;
        }

        lastMouseY = currentMouseY;
    }
}
