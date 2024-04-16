#pragma once
//#include "stdafx.h"
//#include "ControlBean.h"
#pragma comment(lib,"hitbot_interface.lib") 

class ControlBeanEx
{
private:
	LPVOID private_p;
	float private_v[8];
public:

	float x, y, z, angle1, angle2, rotation;
	bool communicate_success, initial_finish, servo_off_flag, move_flag;
	float angle1_after_judge, angle2_after_judge;
	bool isReach_after_judge;
	float real_x, real_y, real_z, real_angle1, real_angle2, real_rotation;
	ControlBeanEx(LPVOID *b);

	~ControlBeanEx();

	__declspec(dllexport) bool  is_connected();

	__declspec(dllexport) int  initial(int generation, float z_travel);

	__declspec(dllexport) int  set_angle_move(float angle1, float angle2, float z, float rotation, float speed);

	__declspec(dllexport) 	bool judge_in_range(float x, float y, float z, float ratation);

	__declspec(dllexport) void  get_scara_param();

	__declspec(dllexport) bool is_collision();

	__declspec(dllexport) int  get_card_num();

	__declspec(dllexport) void  set_arm_length(float l1, float l2);
	
	__declspec(dllexport) int  change_attitude(float speed);
	
	__declspec(dllexport) int  single_axis_move(int axis, float distance);
	
	__declspec(dllexport) int  trail_move(int point_number, float* x, float *y, float *z, float *r, float speed);
	
	__declspec(dllexport) int  set_position_move(float goal_x, float goal_y, float goal_z, float rotation, float speed, float acceleration, int interpolation, int move_mode);//speedΪ�˶��ٶȣ����ǵ����˶��ٶ�
	
	__declspec(dllexport) int  xyz_move(int direction, float distance, float speed);
	
	__declspec(dllexport) void  stop_move();
	
	__declspec(dllexport) void  servo_off();
	
	__declspec(dllexport) 	bool  servo_on();
	
	__declspec(dllexport) 	bool  set_digital_out(int io_number, bool value);
	
	__declspec(dllexport) 	int  unlock_position();
	
	__declspec(dllexport) 	int  get_digital_in(int io_in_number);
	
	__declspec(dllexport) 	int set_efg_state(int type, float distance);
	
	__declspec(dllexport) 	int get_efg_state(int* type, float* distance);
	
	__declspec(dllexport) 	int get_digital_out(int io_out_num);
	
	__declspec(dllexport) bool set_cooperation_fun_state(bool state);
	
	__declspec(dllexport) 	bool  get_cooperation_fun_state();
	
	__declspec(dllexport) 	bool set_drag_teach(bool state);

	__declspec(dllexport) 	bool get_drag_teach();

	__declspec(dllexport) 	bool judge_position_gesture(float x, float y);

	__declspec(dllexport) 	void get_robot_real_coor();

	__declspec(dllexport) 	bool is_robot_goto_target();

	__declspec(dllexport) 	int single_joint_move(int axis, float distance, float speed);

	__declspec(dllexport) void set_allow_distance_at_target_position(float x_distance, float y_distance, float z_distance, float r_distance);

	__declspec(dllexport) 	int  start_joint_monitor();

	__declspec(dllexport) 	int  get_joint_state(int joint_num);

	__declspec(dllexport) 	int  joint_home(int joint_num);

	__declspec(dllexport) 	void  set_catch_or_release_accuracy(float accuracy);

	__declspec(dllexport) 	int  movel_xyz(float goal_x, float goal_y, float goal_z, float rotation, float speed);

	
	__declspec(dllexport)   int   movej_xyz(float goal_x, float goal_y, float goal_z, float goal_r, float speed, float rough);

	
	__declspec(dllexport)   int   movej_angle(float angle1, float angle2, float goal_z, float goal_r, float speed, float rough);

	__declspec(dllexport)   bool   wait_stop();

	__declspec(dllexport)    void   clear_move_list_buf();

	__declspec(dllexport)   int pause_move();

	__declspec(dllexport)   int resume_move();

};

