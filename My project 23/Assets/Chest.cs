using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Аниматор сундука
    private Animator chestAnimator;

    // Проверка, открыт ли сундук
    private bool isOpen = false;

    void Start()
    {
        // Получаем компонент аниматора
        chestAnimator = GetComponent<Animator>();
    }

    // Функция, которая вызывается при нажатии на сундук
    void OnMouseDown()
    {
        // Проверяем, открыт ли уже сундук
        if (!isOpen)
        {
            // Если нет, то открываем его
            chestAnimator.SetTrigger("OpenChest");
            isOpen = true;
        }
    }
}