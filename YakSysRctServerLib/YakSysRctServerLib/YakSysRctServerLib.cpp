#include "stdafx.h"
#include <afxwin.h>
#include <winsock2.h>
#include <mmsystem.h>
#include <iphlpapi.h>
#include <windows.h> 
#include <stdlib.h>
#include <lm.h>

#ifndef countof
#   define countof(a)	    (sizeof(a)/sizeof(a[0]))
#endif

#define DllExport   __declspec( dllexport )


	extern "C" DllExport void EnablePrivileges()
	{
		HANDLE hToken; 
		TOKEN_PRIVILEGES tkp; 
		 
		OpenProcessToken(GetCurrentProcess(), TOKEN_ADJUST_PRIVILEGES | TOKEN_QUERY, &hToken);

		LookupPrivilegeValue(NULL, SE_SHUTDOWN_NAME, &tkp.Privileges[0].Luid); 
	 
		tkp.PrivilegeCount = 1;    
		tkp.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED; 
	  
		AdjustTokenPrivileges(hToken, FALSE, &tkp, 0, (PTOKEN_PRIVILEGES)NULL, 0);
	}



	
	extern "C" DllExport void RestartPC(bool bool_UseForcingTerminate, bool bool_UseForcingTerminateIfHung)
	{
		int FirstParam = 0, SecondParam = 0;

		if (bool_UseForcingTerminate == true) FirstParam = EWX_FORCE;
		if (bool_UseForcingTerminateIfHung == true) SecondParam = EWX_FORCEIFHUNG;
		
		EnablePrivileges();

		ExitWindowsEx(EWX_REBOOT | FirstParam | SecondParam, 0);
	}


	extern "C" DllExport void ShutdownPC(bool bool_UseForcingTerminate, bool bool_UseForcingTerminateIfHung)
	{
		int FirstParam = 0, SecondParam = 0;

		if (bool_UseForcingTerminate == true) FirstParam = EWX_FORCE;
		if (bool_UseForcingTerminateIfHung == true) SecondParam = EWX_FORCEIFHUNG;
		
		EnablePrivileges();

		ExitWindowsEx(EWX_SHUTDOWN | FirstParam | SecondParam, 0);
	}


	extern "C" DllExport void LogOffCurrentUser(bool bool_UseForcingTerminate, bool bool_UseForcingTerminateIfHung)
	{				
		int FirstParam = 0, SecondParam = 0;

		if (bool_UseForcingTerminate == true) FirstParam = EWX_FORCE;
		if (bool_UseForcingTerminateIfHung == true) SecondParam = EWX_FORCEIFHUNG;
		
		EnablePrivileges();

		ExitWindowsEx(EWX_LOGOFF | FirstParam | SecondParam, 0);
	}

	extern "C" DllExport void PowerOff(bool bool_UseForcingTerminate, bool bool_UseForcingTerminateIfHung)
	{		
		int FirstParam = 0, SecondParam = 0;

		if (bool_UseForcingTerminate == true) FirstParam = EWX_FORCE;
		if (bool_UseForcingTerminateIfHung == true) SecondParam = EWX_FORCEIFHUNG;
		
		EnablePrivileges();

		ExitWindowsEx(EWX_POWEROFF | FirstParam | SecondParam, 0);
	}

	extern "C" DllExport void Hibernate(bool bool_UseForcingSuspend)
	{
		EnablePrivileges();

		SetSystemPowerState(FALSE, bool_UseForcingSuspend );
	}


	extern "C" DllExport void StandBy(bool bool_UseForcingSuspend)
	{
		EnablePrivileges();

		SetSystemPowerState(TRUE, bool_UseForcingSuspend );
	}


	extern "C" DllExport void LockWorkstation()
	{
		LockWorkStation();
	}

	
	extern "C" DllExport void EjectCD()
	{
		//mciSendString("Set CDAudio Door Open wait", NULL, 0, NULL);			
	}
	extern "C" DllExport void CloseCD()
	{
		//mciSendString("Set CDAudio Door Closed wait", NULL, 0, NULL);
	}
		
	extern "C" DllExport void ChangeDisplayMode(int int_ScreenWidth, int int_ScreenHeight, int int_ScreenBPP, int int_DisplayFreq)
	{	
		DEVMODE DevMode;

		DevMode.dmSize = sizeof(DEVMODE);
		
		DevMode.dmPelsWidth = int_ScreenWidth;
		DevMode.dmPelsHeight = int_ScreenHeight;
		DevMode.dmBitsPerPel = int_ScreenBPP;
		DevMode.dmDisplayFrequency = int_DisplayFreq;

		DevMode.dmFields = DM_BITSPERPEL | DM_PELSWIDTH | DM_PELSHEIGHT | DM_DISPLAYFREQUENCY;

		ChangeDisplaySettingsEx(NULL, &DevMode, NULL, ( CDS_RESET | CDS_SET_PRIMARY | CDS_UPDATEREGISTRY | 0 ), NULL);	
	}

	extern "C" DllExport void DisableMonitorPowerSaveActivity()
	{
		SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, FALSE, 0, SPIF_SENDWININICHANGE);
		SystemParametersInfo(SPI_SETPOWEROFFACTIVE, 0, 0, SPIF_SENDWININICHANGE);
		SystemParametersInfo(SPI_SETLOWPOWERACTIVE, FALSE, NULL, 0);
	}

	extern "C" DllExport BOOL ConnectToDesktop()
	{
		HWINSTA hstation = OpenWindowStation(TEXT("winsta0"), false, WINSTA_ALL_ACCESS);

		HDESK hdesktop;

		hdesktop = OpenDesktop(TEXT("winsta0\\Default"), 0, false, MAXIMUM_ALLOWED);
			
		if (hdesktop != NULL)
		{
			return SetThreadDesktop(hdesktop);
		}
		else return FALSE;
	}

	extern "C" DllExport void EnableMonitorPowerSaveActivity()
	{
		SystemParametersInfo(SPI_SETSCREENSAVEACTIVE, TRUE, 0, SPIF_SENDWININICHANGE);
		SystemParametersInfo(SPI_SETPOWEROFFACTIVE, TRUE, NULL, SPIF_SENDWININICHANGE);
		SystemParametersInfo(SPI_SETLOWPOWERACTIVE, TRUE, NULL, 0);
	}
		
	extern "C" DllExport char * ResolveMACAddressFromIP(char * charArray_IPAddress)
	{
		HRESULT  hResult_ARPResult;
		IPAddr   ipAddr_Destination;
		ULONG    uLongArray_MACAddress[2];
		ULONG    uLong_MACLength = 6;

		ipAddr_Destination = inet_addr(charArray_IPAddress);
		
		memset(uLongArray_MACAddress, 0xff, sizeof(uLongArray_MACAddress));
		    
		hResult_ARPResult = SendARP(ipAddr_Destination, 0, uLongArray_MACAddress, &uLong_MACLength);
	    	
		if(uLong_MACLength == 0 || hResult_ARPResult != NO_ERROR) return "";
		
		char * pCharArray_MACAddress = new char[uLong_MACLength * 3];
		
		PBYTE pByte_HexMACAddress = (PBYTE)uLongArray_MACAddress;
	
		int int_CycleCount = 0, int_NumOfWritenChars = 0;

		// Convert the Binary MAC Address into HEX MAC Address
		for (; int_CycleCount < uLong_MACLength - 1; int_CycleCount++) 
		{
			int_NumOfWritenChars += sprintf(pCharArray_MACAddress + int_NumOfWritenChars, "%02X-", pByte_HexMACAddress[int_CycleCount]);
		}    	
		sprintf(pCharArray_MACAddress + int_NumOfWritenChars, "%02X", pByte_HexMACAddress[int_CycleCount]);

		return pCharArray_MACAddress;
	}


		
	extern "C" DllExport int GetMouseCursorPositionX()
	{
		POINT pOINT_CursorPosition;

		GetCursorPos(&pOINT_CursorPosition);

		return pOINT_CursorPosition.x;		
	}

	extern "C" DllExport int GetMouseCursorPositionY()
	{
		POINT pOINT_CursorPosition;

		GetCursorPos(&pOINT_CursorPosition);

		return pOINT_CursorPosition.y;
	}
	
	extern "C" DllExport void SetMouseButtonClickEvent(int int_MouseEventType, int int_MouseButtonNum, int int_MouseClicksCount, int int_X, int int_Y)
	{
		if(int_MouseClicksCount == 2)
		{
			INPUT inputs[3];

			DWORD dw_DownButtonFlag = MOUSEEVENTF_LEFTDOWN;
			DWORD dw_UpButtonFlag = MOUSEEVENTF_LEFTDOWN;

			switch(int_MouseButtonNum)
			{
				case 1:
					dw_DownButtonFlag = MOUSEEVENTF_LEFTDOWN;
					dw_UpButtonFlag = MOUSEEVENTF_LEFTUP;
					break;

				case 2:
					dw_DownButtonFlag = MOUSEEVENTF_MIDDLEDOWN;
					dw_UpButtonFlag = MOUSEEVENTF_MIDDLEUP;

					break;

				case 3:
					dw_DownButtonFlag = MOUSEEVENTF_RIGHTDOWN;
					dw_UpButtonFlag = MOUSEEVENTF_RIGHTUP;
					break;
			}


			ZeroMemory(&inputs, sizeof(inputs));

			inputs[0].type = INPUT_MOUSE;
			inputs[0].mi.dx = int_X;
			inputs[0].mi.dy = int_Y;
			inputs[0].mi.dwFlags = dw_DownButtonFlag;

			inputs[1].type = INPUT_MOUSE;
			inputs[1].mi.dx = int_X;
			inputs[1].mi.dy = int_Y;
			inputs[1].mi.dwFlags = dw_UpButtonFlag;

			inputs[2].type = INPUT_MOUSE;
			inputs[2].mi.dx = int_X;
			inputs[2].mi.dy = int_Y;
			inputs[2].mi.dwFlags = dw_DownButtonFlag;

			SendInput(3, inputs, sizeof(INPUT));

			return;
		}

		if(int_MouseClicksCount == 1)
		{
			INPUT input;

			input.type = INPUT_MOUSE;

			DWORD dw_Flags = MOUSEEVENTF_LEFTDOWN;

			if(int_MouseEventType == 0)
			{
				switch(int_MouseButtonNum)
				{
				case 1:
					dw_Flags = MOUSEEVENTF_LEFTDOWN;
					break;

				case 2:
					dw_Flags = MOUSEEVENTF_MIDDLEDOWN;
					break;

				case 3:
					dw_Flags = MOUSEEVENTF_RIGHTDOWN;
					break;
				}
			}

			if(int_MouseEventType == 1)
			{
				switch(int_MouseButtonNum)
				{
				case 1:
					dw_Flags = MOUSEEVENTF_LEFTUP;
					break;

				case 2:
					dw_Flags = MOUSEEVENTF_MIDDLEUP;
					break;

				case 3:
					dw_Flags = MOUSEEVENTF_RIGHTUP;
					break;	
				}
			}

			input.mi.dwFlags = dw_Flags | MOUSEEVENTF_ABSOLUTE;

			input.mi.dx = int_X;
			input.mi.dy = int_Y;

			SendInput(1, &input, sizeof(INPUT));
		}
	}

	extern "C" DllExport void SetMouseMoveEventFromMiniRTDV(int int_X, int int_Y)
	{
		INPUT input;
	
		input.type = INPUT_MOUSE;
	
		DWORD dw_EventType = MOUSEEVENTF_MOVE;

		input.mi.dwFlags = dw_EventType | MOUSEEVENTF_ABSOLUTE;

		input.mi.dx = int_X;
		input.mi.dy = int_Y;

        SendInput(1, &input, sizeof(INPUT));	
	}

	extern "C" DllExport void SetMouseMoveEvent(int int_X, int int_Y)
	{
		SetCursorPos(int_X, int_Y);
return;
		INPUT input;
	
		input.type = INPUT_MOUSE;
	
		input.mi.dwFlags = MOUSEEVENTF_MOVE;

		input.mi.dx = int_X;
		input.mi.dy = int_Y;

        SendInput(1, &input, sizeof(INPUT));		
	}



	extern "C" DllExport void SetSequenceOfTwoKeysEvent(int int_TypeOfSequence)
	{
		INPUT input[4];
	
		ZeroMemory (&input, sizeof(input)) ;

		input[0].type = input[1].type = input[2].type = input[3].type = INPUT_KEYBOARD ;

		WORD word_FirstKey, word_SecondKey;

		switch(int_TypeOfSequence)
		{
			case 1:
				word_FirstKey = VK_MENU;
				word_SecondKey = VK_F12;
			break;	

			case 2:		
				word_FirstKey = VK_CONTROL;
				word_SecondKey = VK_ESCAPE;
			break;	
		}

		input[0].ki.wVk = input[2].ki.wVk = word_FirstKey;
		input[1].ki.wVk = input[3].ki.wVk = word_SecondKey;
	      
		input[0].ki.time = input[1].ki.time = input[2].ki.time = input[3].ki.time = GetTickCount();
	      
		input[2].ki.dwFlags = input[3].ki.dwFlags = KEYEVENTF_KEYUP;
	     
		SendInput(4, input, sizeof(INPUT)) ;
	}

	extern "C" DllExport void SetSequenceOfThreeKeysEvent(int int_TypeOfSequence)
	{						
		INPUT input[6];

		ZeroMemory (&input, sizeof(input));

		input[0].type = input[1].type = input[2].type = input[3].type = input[4].type = input[5].type = INPUT_KEYBOARD;
		
		WORD word_FirstKey, word_SecondKey, word_ThirdKey;

		switch(int_TypeOfSequence)
		{
			case 1:
				word_FirstKey = VK_MENU;
				word_SecondKey = VK_CONTROL;
				word_ThirdKey = VK_F12;
			break;	

			case 2:		
				word_FirstKey = VK_MENU;
				word_SecondKey = VK_CONTROL;
				word_ThirdKey = VK_F12;
			break;	
		}

		input[0].ki.wVk = word_FirstKey; 
		input[1].ki.wVk = word_SecondKey;
		input[2].ki.wVk = word_ThirdKey;

		input[3].ki.wVk = word_FirstKey;
		input[4].ki.wVk = word_SecondKey;
		input[5].ki.wVk = word_ThirdKey;
	
		input[3].ki.dwFlags = input[4].ki.dwFlags = input[5].ki.dwFlags = KEYEVENTF_KEYUP;

		SendInput (6, input, sizeof(INPUT));
	}



	extern "C" DllExport void SetKeyboardEvent(int int_EventType, int int_Key, int int_Modifiers)
	{
		INPUT input;
	
		input.type = INPUT_KEYBOARD;
	
		DWORD dw_EventType;

		switch(int_EventType)
		{
			case 2:
				dw_EventType = KEYEVENTF_KEYUP;
			break;
		}

		input.ki.dwFlags = dw_EventType;
	
		input.ki.wVk = input.ki.wScan = int_Key;
				       
		SendInput(1, &input, sizeof(INPUT));
	}




	extern "C" DllExport void SetKeyboardEventWModifiers(int int_EventType, int int_Key, int int_Modifiers)
	{	
		INPUT input_obj[4];

		ZeroMemory (&input_obj, sizeof (input_obj)) ;

		WORD word_FirstKey, word_SecondKey;

		switch(int_Modifiers)
		{
			case 65536:
				word_FirstKey = VK_SHIFT;  
			break;	

			case 131072:		
				word_FirstKey = VK_CONTROL;
			break;	

			case 262144:		
				word_FirstKey = VK_MENU;
			break;	
		}

		input_obj[0].type = input_obj[1].type = input_obj[2].type = input_obj[3].type = INPUT_KEYBOARD ;

		input_obj[0].ki.wVk = input_obj[2].ki.wVk = word_FirstKey ;

		input_obj[1].ki.wVk = input_obj[3].ki.wVk = int_Key;

		input_obj[0].ki.time = input_obj[1].ki.time = input_obj[2].ki.time = input_obj[3].ki.time = GetTickCount () ;

		input_obj[2].ki.dwFlags = input_obj[3].ki.dwFlags = KEYEVENTF_KEYUP ;

		SendInput (4, input_obj, sizeof (INPUT));		
	}



	
	extern "C" DllExport BOOL 
	CheckPassword_LogonUser(LPCTSTR pszDomainName, LPCTSTR pszUserName, LPCTSTR pszPassword, HANDLE * phToken)
	{
		_ASSERTE(pszUserName != NULL);
		_ASSERTE(pszPassword != NULL);

		HANDLE hToken;

		TCHAR szDomainName[DNLEN + 1];
		TCHAR szUserName[UNLEN + 1];
		TCHAR szPassword[PWLEN + 1];

		if (pszDomainName == NULL)
		{
			BYTE bSid[8 + 4 * SID_MAX_SUB_AUTHORITIES];
			ULONG cbSid = sizeof(bSid);
			ULONG cchDomainName = countof(szDomainName);
			SID_NAME_USE Use;

			if (LookupAccountName(NULL, pszUserName, (PSID)bSid, &cbSid, szDomainName, &cchDomainName, &Use) == FALSE)
			{
				return FALSE;
			}
		}
		else
		{
			lstrcpyn(szDomainName, pszDomainName, countof(szDomainName));
		}

		lstrcpyn(szUserName, pszUserName, countof(szUserName));
		lstrcpyn(szPassword, pszPassword, countof(szPassword));

		if (LogonUser(szUserName, szDomainName, szPassword, LOGON32_LOGON_NETWORK, LOGON32_PROVIDER_DEFAULT, &hToken) == FALSE)
		{
			return FALSE;
		}

		if (phToken == NULL)
		{
			CloseHandle(hToken);
		}
		else
		{
			*phToken = hToken;
		}

		return TRUE;
	}