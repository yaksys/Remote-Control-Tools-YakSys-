// YakSysRctServerLib.h: ������� ���� ��������� ��� DLL YakSysRctServerLib
//

#pragma once

#ifndef __AFXWIN_H__
	#error "�������� stdafx.h �� ��������� ����� ����� � PCH"
#endif

#include "resource.h"		// �������� �������


// CYakSysRctServerLibApp
// ��� ���������� ������� ������ ��. YakSysRctServerLib.cpp
//

class CYakSysRctServerLibApp : public CWinApp
{
public:
	CYakSysRctServerLibApp();

// ���������������
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
