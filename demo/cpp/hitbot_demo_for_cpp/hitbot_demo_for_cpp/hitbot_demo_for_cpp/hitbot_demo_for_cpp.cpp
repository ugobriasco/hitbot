// hitbot_demo_for_cpp.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "hitbot_interface.h"


using namespace std;
ControlBeanEx* robot1;
ControlBeanEx* robot2;

int main()
{
	//初始化网络服务器
	net_port_initial();
	cout << "server.exe 启动成功" << endl;
	Sleep(1000);

	robot1 = get_robot(211);//修改为自己设备的id号
	robot2 = get_robot(212);//修改为自己设备的id号
	cout << "获取ControlBeanEx实例成功" << endl;

	for (int i = 0; i < 10; i++)
	{
		if (robot1->is_connected())
		{
			cout << robot1->get_card_num() << "已连接" << endl;
			cout << robot1->get_card_num() << "开始初始化" << endl;
			int ret = robot1->initial(1, 210);//修改为自己设备的参数
			if (ret == 1)
			{
				cout << robot1->get_card_num() << "初始化完成" << endl;
				robot1->unlock_position();
				cout << robot1->get_card_num() << "已解锁" << endl;
			}
			else
			{
				cout << robot1->get_card_num() << "初始化失败，返回值 = " << ret << endl;
			}

			break;
		}
		if (i == 9)
		{
			cout << robot1->get_card_num() << "连接超时" << endl;
			break;
		}
		Sleep(500);
	}


	for (int i = 0; i < 10; i++)
	{
		if (robot2->is_connected())
		{
			cout << robot2->get_card_num() << "已连接" << endl;
			cout << robot2->get_card_num() << "开始初始化" << endl;
			int ret = robot2->initial(1, 210);//修改为自己设备的参数
			if (ret == 1)
			{
				cout << robot2->get_card_num() << "初始化完成" << endl;
				robot2->unlock_position();
				cout << robot2->get_card_num() << "已解锁" << endl;
			}
			else
			{
				cout << robot2->get_card_num() << "初始化失败，返回值 = " << ret << endl;
			}

			break;
		}
		if (i == 9)
		{
			cout << robot2->get_card_num() << "连接超时" << endl;
			break;
		}
		Sleep(500);
	}


	robot1->get_scara_param();
	if (robot1->initial_finish)
	{
		cout << robot1->get_card_num() << "开始回零" << endl;
		int ret = robot1->set_position_move(400, 0, -100, 0, 10, 1, 1, 1);
		if (ret != 1)
		{
			cout << robot1->get_card_num() << "回零失败，set_position_move 返回值 = " << ret << endl;
		}
	}
	else
	{
		cout << robot1->get_card_num() << "未初始化，无法回零" << endl;
	}

	robot2->get_scara_param();
	if (robot2->initial_finish)
	{
		cout << robot2->get_card_num() << "开始回零" << endl;
		int ret = robot2->set_position_move(400, 0, -100, 0, 10, 1, 1, 1);
		if (ret != 1)
		{
			cout << robot2->get_card_num() << "回零失败，set_position_move 返回值 = " <<ret<< endl;

		}
	}
	else
	{
		cout << robot2->get_card_num() << "未初始化，无法回零" << endl;
	}

	system("pause");
	return 0;
}
