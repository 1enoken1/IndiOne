using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public float bulletLifetime = 5f;
    private bool isRicocheting = false;

    void Start()
    {
        // ������ �������� �������� ����
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * bulletSpeed;

        // ��������� ������ ��� ����������� ���� ����� bulletLifetime ������
        Destroy(gameObject, bulletLifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ��� ������������ �������� ����� ��������
        if (!isRicocheting)
        {
            isRicocheting = true;

            // �������� ����������� �������� �� ���������������
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = -rb.velocity;

            // ��������� ����� ����� ����, ����� ��� ������� ������
            bulletLifetime = Mathf.Min(bulletLifetime, 1f);
        }
    }
}