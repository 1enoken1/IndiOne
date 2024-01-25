using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public GameObject crosshair;  // ���������� ���� ������ �������
    private bool isMouseButtonDown = false;

    void Update()
    {
        // ��������� ������� � ���������� ������ ����
        if (Input.GetMouseButtonDown(1))
        {
            isMouseButtonDown = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isMouseButtonDown = false;
            ToggleCrosshairVisibility(false);
        }

        // ���������� ��������� �������
        if (isMouseButtonDown)
        {
            UpdateCrosshairPosition();
        }
    }

    void UpdateCrosshairPosition()
    {
        // �������� ������� ������� � ������� �����������
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 0f;  // ������������� z � 0, ����� ���������� � 2D-������������

        // ���������� ������ � ������� �������
        crosshair.transform.position = cursorPosition;

        // ���������� ������
        ToggleCrosshairVisibility(true);
    }

    void ToggleCrosshairVisibility(bool isVisible)
    {
        crosshair.SetActive(isVisible);
    }
}