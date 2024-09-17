using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerCameraController : NetworkBehaviour
{
    [SerializeField] GameObject _cam;

    public override void OnStartAuthority()
    {
        _cam.SetActive(true);
    }
    //1. ���������� �������
    //2. ������ ����������� ��� ������� ��������������� ����-�����.

    //��������:
    //- ������� ������ ����������� �� ����� GitHub;
    //- ������������ ����������� �� ���� ��������� � ������� Sourcetree;
    //- ����������� ���������� ������� ��������������� ����-����� � ����� �����������;
    //- ������� ������ � ��������� ��� � GitHub.
}
