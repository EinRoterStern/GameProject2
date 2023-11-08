using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject rotationButtonText;
    public int select = 0;
    public float jumpForce = 5.0f; // Сила прыжка
    public bool isGrounded = true; // Флаг, указывающий, находится ли персонаж на земле
    public bool rotation = false;
    private Rigidbody rb;
    public float moveSpeed = 3.0f; // Скорость движения персонажа

    private Animator animator;

    void Start()
    {
        setActiveUnit(0);
        animator = obj[select].GetComponent<Animator>();
        rb = obj[select].GetComponent<Rigidbody>();
        rb.mass = 1.0f; // Установите массу персонажа
        rb.drag = 0.0f; // Установите сопротивление движению в воздухе
        rb.angularDrag = 0.05f; // Установите сопротивление вращению
        rb.useGravity = true; // Включите гравитацию для падения
        rb.isKinematic = false; // Установите в false, чтобы включить физическое взаимодействие
    }

    void Update()
    {
        // Включение/выключение вращения
        if (Input.GetKeyDown(KeyCode.R))
        {
            ButtonRotation();
        }

        // Управление движением с клавиатуры
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        if (moveDirection != Vector3.zero)
        {
            // Поворот персонажа в направлении движения
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            obj[select].transform.rotation = targetRotation;

            // Анимация ходьбы
            animator.SetBool("IsWalking", true);
            ButtonWalk();

            // Перемещение персонажа
            obj[select].transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            // Остановка анимации ходьбы, если нет входного направления
            animator.SetBool("IsWalking", false);
            ButtonIdle1();
        }

        // Проверка на наличие земли под персонажем
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        // Проверка нажатия клавиши "Пробел" и условие isGrounded для прыжка
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            ButtonIdle3();// Дополнительный код для анимации прыжка (если нужно)
        }
    }


    void setActiveUnit(int iselect)
    {
        select = iselect;
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].SetActive(false);
        }
        obj[select].SetActive(true);
        animator = obj[select].GetComponent<Animator>();
    }

    public void ButtonRotation()
    {
        rotation = !rotation;
        if (rotation)
        {
            rotationButtonText.GetComponent<Text>().text = "Rotation ON";
        }
        else
        {
            rotationButtonText.GetComponent<Text>().text = "Rotation OFF";
        }
    }

    // Остальные методы управления анимациями остаются без изменений
    // ...
    public void ButtonModel0()
    {
        setActiveUnit(0);
    }

    public void ButtonModel1()
    {
        setActiveUnit(1);
    }

    public void ButtonModel2()
    {
        setActiveUnit(2);
    }

    public void ButtonShowAllAnimation()
    {
        obj[select].GetComponent<Animator>().Play("all animation");
    }

    public void ButtonIdle1()
    {
        obj[select].GetComponent<Animator>().Play("idle1");
    }
    public void ButtonIdle2()
    {
        obj[select].GetComponent<Animator>().Play("idle2");
    }
    public void ButtonIdle3()
    {
        obj[select].GetComponent<Animator>().Play("idle3");
    }
    public void ButtonIdle4()
    {
        obj[select].GetComponent<Animator>().Play("idle4");
    }

    public void ButtonAttack1()
    {
        obj[select].GetComponent<Animator>().Play("Attack1");
    }
    public void ButtonAttack2()
    {
        obj[select].GetComponent<Animator>().Play("Attack2");
    }
    public void ButtonAttack3()
    {
        obj[select].GetComponent<Animator>().Play("Attack3");
    }
    public void ButtonAttack4()
    {
        obj[select].GetComponent<Animator>().Play("Attack4");
    }
    public void ButtonAttack5()
    {
        obj[select].GetComponent<Animator>().Play("Attack5");
    }
    public void ButtonIdle_Attack()
    {
        obj[select].GetComponent<Animator>().Play("Idle_Attack");
    }
    public void ButtonCombat_run()
    {
        obj[select].GetComponent<Animator>().Play("Combat_run");
    }
    public void ButtonRun()
    {
        obj[select].GetComponent<Animator>().Play("Run");
    }
    public void ButtonWalk()
    {
        obj[select].GetComponent<Animator>().Play("Walk");
    }
    public void ButtonDeath1()
    {
        obj[select].GetComponent<Animator>().Play("Death1");
    }
    public void ButtonDeath2()
    {
        obj[select].GetComponent<Animator>().Play("Death2");
    }



}