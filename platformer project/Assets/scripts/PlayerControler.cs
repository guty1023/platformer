using UnityEngine;


// ���� ������ public private protected
public class PlayerControler : MonoBehaviour
{
    //  staer, Update ����Ƽ�̺�Ʈ �Լ��� ���� �̸��� �ִ��� ����
    //  ���� �̸��� ������? ����Ƽ���� ���س��� ���� �ð��� �� �Լ��� ����

    // Start is called before the first frame update
    // ù �������� �ҷ��������� (�ѹ�) �����Ѵ�.

    //�ӵ�, ����
    [Header("�̵�")]
    public float moveSpeed = 5f;    //ĳ������ �̵� �ӵ�
    public float jumpForce = 10f;   //ĳ������ ������
    private float moveInput;        // �÷��̾��� �滐 �� ��ǲ ������ ����  

    public Transform startTransform; //ĳ���Ͱ� ������ ��ġ
    public Rigidbody2D rigidbody2D;  //����(����) ����� �����ϴ� ������Ʈ

    [Header("����")]
    public bool isGrounded;         // true : ĳ���Ͱ� ���� �� �� �ִ� ����, false : ĳ���Ͱ� ���� �� �� ���� ����
    public float groundDistance = 2f;
    public LayerMask groundLayer;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log("Hello Unity");
        //���� �� ��ġ <+ ���ο� x,y �����ϴ� ������ Ÿ�� ( ���� 
        //transform.position = new Vector2(transform.position.x, 10);

        transform.position = startTransform.position;
       
    }

    // Update is called once per frame
    // 1 �����ӿ� ���� ȣ�ٵȴ�. - �ݺ������� ����
    void Update()
    {
        isGrounded = Phtsics.Raycast(transform.postion, Vector2.down,2)

        // �÷��̾��� �Է� ���� �޾ƿ;� �մϴ�.

       moveInput = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(moveSpeed * moveInput, rigidbody2D.velocity.y);


        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
           // ���� : Y Postion _ rigidbody Y velocity�� ���� �Ŀ���ŭ �÷��ָ�ȴ�.
           rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform, position.x, transform.position.y - groundDistance));
    }
}
