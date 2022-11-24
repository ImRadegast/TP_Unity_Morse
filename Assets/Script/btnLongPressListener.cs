using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class btnLongPressListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [Tooltip("Hold duration in seconds")]
    [Range(0.3f, 5f)] public float holdDuration = 0.5f;
    [Range(0.3f, 5f)] public float timeSpace = 2f;
    private float notPressedTime = 0f;

    public UnityEvent onShortPress;
    public UnityEvent onLongPress;
    public UnityEvent onNotPress;

    private bool isPointerDown = false;
    private bool isLongPressed = false;
    private float pressedTime = 0f;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
    }

    private void Update()
    {
        if (isPointerDown && !isLongPressed)
        {
            pressedTime += Time.deltaTime;
            notPressedTime = 0f;
        }
        else
        {
            notPressedTime += Time.deltaTime;
        }

        if(notPressedTime > timeSpace && button.interactable && !object.ReferenceEquals(onNotPress, null))
        {
            notPressedTime = 0f;
            onNotPress.Invoke();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {   
        if (pressedTime >= holdDuration)
        {
            isLongPressed = true;
            pressedTime = 0f;
            if (button.interactable && !object.ReferenceEquals(onLongPress, null))
                onLongPress.Invoke();
        }
        else
        {
            pressedTime = 0f;
            if (button.interactable && !object.ReferenceEquals(onShortPress, null))
                onShortPress.Invoke();
        }
        isPointerDown = false;
        isLongPressed = false;
        pressedTime = 0f;
    }
}
