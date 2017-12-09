// YakSysRctServerLib.h: главный файл заголовка для DLL YakSysRctServerLib
//

#pragma once

#ifndef __AFXWIN_H__
	#error "включить stdafx.h до включения этого файла в PCH"
#endif

#include "resource.h"		// основные символы


// CYakSysRctServerLibApp
// Про реализацию данного класса см. YakSysRctServerLib.cpp
//

class CYakSysRctServerLibApp : public CWinApp
{
public:
	CYakSysRctServerLibApp();

// Переопределение
public:
	virtual BOOL InitInstance();

	DECLARE_MESSAGE_MAP()
};
