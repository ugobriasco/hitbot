// hitbot_demo_for_cpp.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "hitbot_interface.h"


using namespace std;
ControlBeanEx* robot1;
ControlBeanEx* robot2;

int main()
{
	//��ʼ�����������
	net_port_initial();
	cout << "server.exe �����ɹ�" << endl;
	Sleep(1000);

	robot1 = get_robot(211);//�޸�Ϊ�Լ��豸��id��
	robot2 = get_robot(212);//�޸�Ϊ�Լ��豸��id��
	cout << "��ȡControlBeanExʵ���ɹ�" << endl;

	for (int i = 0; i < 10; i++)
	{
		if (robot1->is_connected())
		{
			cout << robot1->get_card_num() << "������" << endl;
			cout << robot1->get_card_num() << "��ʼ��ʼ��" << endl;
			int ret = robot1->initial(1, 210);//�޸�Ϊ�Լ��豸�Ĳ���
			if (ret == 1)
			{
				cout << robot1->get_card_num() << "��ʼ�����" << endl;
				robot1->unlock_position();
				cout << robot1->get_card_num() << "�ѽ���" << endl;
			}
			else
			{
				cout << robot1->get_card_num() << "��ʼ��ʧ�ܣ�����ֵ = " << ret << endl;
			}

			break;
		}
		if (i == 9)
		{
			cout << robot1->get_card_num() << "���ӳ�ʱ" << endl;
			break;
		}
		Sleep(500);
	}


	for (int i = 0; i < 10; i++)
	{
		if (robot2->is_connected())
		{
			cout << robot2->get_card_num() << "������" << endl;
			cout << robot2->get_card_num() << "��ʼ��ʼ��" << endl;
			int ret = robot2->initial(1, 210);//�޸�Ϊ�Լ��豸�Ĳ���
			if (ret == 1)
			{
				cout << robot2->get_card_num() << "��ʼ�����" << endl;
				robot2->unlock_position();
				cout << robot2->get_card_num() << "�ѽ���" << endl;
			}
			else
			{
				cout << robot2->get_card_num() << "��ʼ��ʧ�ܣ�����ֵ = " << ret << endl;
			}

			break;
		}
		if (i == 9)
		{
			cout << robot2->get_card_num() << "���ӳ�ʱ" << endl;
			break;
		}
		Sleep(500);
	}


	robot1->get_scara_param();
	if (robot1->initial_finish)
	{
		cout << robot1->get_card_num() << "��ʼ����" << endl;
		int ret = robot1->set_position_move(400, 0, -100, 0, 10, 1, 1, 1);
		if (ret != 1)
		{
			cout << robot1->get_card_num() << "����ʧ�ܣ�set_position_move ����ֵ = " << ret << endl;
		}
	}
	else
	{
		cout << robot1->get_card_num() << "δ��ʼ�����޷�����" << endl;
	}

	robot2->get_scara_param();
	if (robot2->initial_finish)
	{
		cout << robot2->get_card_num() << "��ʼ����" << endl;
		int ret = robot2->set_position_move(400, 0, -100, 0, 10, 1, 1, 1);
		if (ret != 1)
		{
			cout << robot2->get_card_num() << "����ʧ�ܣ�set_position_move ����ֵ = " <<ret<< endl;

		}
	}
	else
	{
		cout << robot2->get_card_num() << "δ��ʼ�����޷�����" << endl;
	}

	system("pause");
	return 0;
}
