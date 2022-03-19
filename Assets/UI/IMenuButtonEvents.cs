using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMenuButtonEvents
{
    void OnButtonEnter(Button button);
    void OnButtonExit(Button button);

    void OnButtonClick(Button button);
}
