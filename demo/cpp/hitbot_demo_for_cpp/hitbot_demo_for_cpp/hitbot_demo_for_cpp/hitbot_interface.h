#pragma once
#pragma comment(lib,"hitbot_interface.lib") 
#include "ControlBeanEx.h"

extern   "C"   __declspec(dllexport)  void  net_port_initial(); 

extern   "C"   __declspec(dllexport) ControlBeanEx * get_robot(int card_number);

extern   "C"   __declspec(dllexport) int card_number_connect(int num);

extern "C" __declspec(dllexport) void close_server();
