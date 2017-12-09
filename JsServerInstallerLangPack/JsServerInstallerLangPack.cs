using System;


public class StringFactory
{
    public static string GetString(int int_StringNumber, int int_Language)
    {
        switch (int_StringNumber)
        {
            case 1:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "YakSys Server Service Installer";


                        case 1:
                            return "YakSys Server Service Installer";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 2:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Internet: http://www.YakSys.net\n\nAuthor: chief_yaksys@yandex.ru www.YakSys.net\n\nTechnical support: support@YakSys.net";


                        case 1:
                            return "�������� ����: http://www.YakSys.net\n\n�����: chief_yaksys@yandex.ru www.YakSys.net \n\n����������� ���������: support@YakSys.net";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 3:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "About";

                        case 1:
                            return "� ���������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////	

            case 4:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Host Address:";


                        case 1:
                            return "����� �����:";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 5:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Host Type:";


                        case 1:
                            return "��� �����:";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 6:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Service Type:";


                        case 1:
                            return "��� �������:";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 7:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Desktop Interact:";


                        case 1:
                            return "���������������:";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 8:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Service Status:";


                        case 1:
                            return "������ �������:";

                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 9:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Service Name:";

                        case 1:
                            return "��� �������:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 10:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Service State:";

                        case 1:
                            return "��������� �������:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 11:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Process ID:";

                        case 1:
                            return "ID ��������:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 12:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Service Start Mode:";

                        case 1:
                            return "����� ������� �������:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 13:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Automati�";

                        case 1:
                            return "�������������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 14:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Manual";

                        case 1:
                            return "� ������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 15:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Disabled";

                        case 1:
                            return "��������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 16:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Get Information";

                        case 1:
                            return "�������� ���������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 17:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Network Address:";

                        case 1:
                            return "������� �����:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 18:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Login:";

                        case 1:
                            return "�����:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 19:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Domain:";

                        case 1:
                            return "�����:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 20:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Password:";

                        case 1:
                            return "������:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 21:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Microsoft Windows Network";

                        case 1:
                            return "���� Microsoft Windows";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 22:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Active Directory Network";

                        case 1:
                            return "���� Active Directory";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 23:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Install Server";

                        case 1:
                            return "���������� ������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 24:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Uninstall Server";

                        case 1:
                            return "������� ������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 25:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Networks and Computers";

                        case 1:
                            return "���� � ����������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 26:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "YakSys Server Service Control and Information";

                        case 1:
                            return "���������� � ���������� YakSys Server Service";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 27:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Cancel";

                        case 1:
                            return "������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 28:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Task Progrress";

                        case 1:
                            return "��� ���������� �������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 29:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Task Activity Monitoring";

                        case 1:
                            return "�������� ���������� �������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 30:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Access Denied.";

                        case 1:
                            return "������ ��������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 31:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The type of device and the type of network resource do not match.";

                        case 1:
                            return "��� ��������� � ��� �������� ������� �� ���������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////
                
            case 32:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The specified Local Name is invalid.";

                        case 1:
                            return "��������� ��������� ��� �� �����.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 33:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The Remote resource is not acceptable to any network resource provider, either because the resource name is invalid, or because the named resource cannot be located.";

                        case 1:
                            return "��������� ������ �� �������� ��� ����� ���� ��������� ��������, �������� ������ ��� ��� ������� �� ����� ��� ������ ��� ������ �� ��� ���������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 34:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The user account is in an incorrect format.";

                        case 1:
                            return "������� ������ ������������ ����� ������������ ������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 35:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The Provider value does not match any provider.";

                        case 1:
                            return "�������� ���������� �� ������������� ������� �� �����������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 36:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The router or provider is busy, possibly initializing. Please retry later.";

                        case 1:
                            return "������ ��� ��������� ������, �������� �� ������� ���������� �������� �������������. ���������� ��������� ������ ����� ��������� �����.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 37:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The attempt to make the connection was cancelled by the user through a dialog box from one of the network resource providers, or by a called resource.";

                        case 1:
                            return "������� ���������� ���������� ���� �������� ������������� ����� ���������� ���� ������ �� ������� ����������� �������� ��� ���������� ��������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 38:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The system is unable to open the user profile to process persistent connections.";

                        case 1:
                            return "������� �� ������ ������� ������� ������������ ��� ��������� ���������� ����������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 39:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "An entry for the device specified by LocalName is already in the user profile.";

                        case 1:
                            return "���� ��� ���������� ������������� LocalName ��� ��������� � ���������������� �������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 40:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "A network-specific error occurred.";

                        case 1:
                            return "��������� ������������ ������� ������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 41:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The specified password is invalid.";

                        case 1:
                            return "��������� ������ �� �����.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 42:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The operation cannot be performed because a network component is not started or because a specified name cannot be used.";

                        case 1:
                            return "�������� �� ����� ���� ��������� � �� ������� ������������� ������� �������� ���������� ��� � ����� � ��� ��� ��������� ��� �� ����� ��������������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 43:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The network is unavailable.";

                        case 1:
                            return "���� ����������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 44:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Authorization failure.";

                        case 1:
                            return "�������� � �������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 45:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Multiple connections to a server or shared resource by the same user, using more than one user name, are not allowed. Disconnect all previous connections to the server or shared resource and try again.";

                        case 1:
                            return "������������� ����������� � ������� ��� ����� �������� ������ � ���� �� ������������, ��������� ����� ��� ���� ��� ������������, �����������. ��������� ��� ���������� ���������� � ������� ��� ����� �������� � ���������� �����.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 46:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "OK, Object already exist";

                        case 1:
                            return "��, ������ ��� ����������.";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 47:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Installation process was aborted";

                        case 1:
                            return "������� ��������� ��� �������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 48:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Installation process was cancelled";

                        case 1:
                            return "������� ��������� ��� �������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 49:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Uninstallation process was cancelled";

                        case 1:
                            return "������� �������� ���������� ��� �������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 50:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "User Auth";

                        case 1:
                            return "����������� ������������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 51:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Creating YakSys Server directory";

                        case 1:
                            return "�������� ���������� YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 52:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Self-extracted file �opying";

                        case 1:
                            return "����������� ���������������������� ������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 53:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Getting YakSys Server directory path";

                        case 1:
                            return "�������� ���� � ���������� YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 54:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Exctracting YakSys Server binaries";

                        case 1:
                            return "���������� ����������� ������ YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 55:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Creating and registering YakSys Server Windows Service";

                        case 1:
                            return "�������� � ����������� Windows ������ YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 56:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Starting YakSys Server Windows Service";

                        case 1:
                            return "������ Windows ������ YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 57:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Starting YakSys Server Windows Service";

                        case 1:
                            return "������ Windows ������ YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 58:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Installation Complete";

                        case 1:
                            return "��������� ���������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

                
            case 59:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Stop YakSys Server Windows Service";

                        case 1:
                            return "��������� Windows ������ YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 60:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Delete YakSys Server Service";

                        case 1:
                            return "�������� YakSys Server Windows Service";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 61:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Delete YakSys Server directory";

                        case 1:
                            return "�������� ���������� YakSys Server";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

                
            case 62:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Uninstallation Complete";

                        case 1:
                            return "�������� ���������� ���������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////


            case 63:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Domain";

                        case 1:
                            return "�����";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

                
            case 64:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Computer";

                        case 1:
                            return "���������";
                    }
                }
                break;

            /////////////////////////////////////////////////////////

            case 65:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Working activity monitoring process was cancelled";

                        case 1:
                            return "������� ����������� ���������� ������ ��� �������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////


            case 66:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "The device is already connected to a network resource.";

                        case 1:
                            return "���������� ��� ���������� � �������� �������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////
                

            case 67:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Remote System";

                        case 1:
                            return "��������� �������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////
                

            case 68:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Local System";

                        case 1:
                            return "��������� �������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////


            case 69:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Install Date:";

                        case 1:
                            return "���� ���������:";
                    }
                }
                break;
            /////////////////////////////////////////////////////////

            case 70:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Operation";

                        case 1:
                            return "��������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////


            case 71:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Result";

                        case 1:
                            return "���������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////


            case 72:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Working Progress";

                        case 1:
                            return "�������� ����������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////
                
            case 73:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Working Activity";

                        case 1:
                            return "���������� ������";
                    }
                }
                break;
            /////////////////////////////////////////////////////////



            case 74:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "File";

                        case 1:
                            return "����";
                    }
                }
                break;



            case 75:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Exit";

                        case 1:
                            return "�����";
                    }
                }
                break;



            case 76:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Language";

                        case 1:
                            return "����";
                    }
                }
                break;



            case 77:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Russian";

                        case 1:
                            return "�������";
                    }
                }
                break;



            case 78:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Help";

                        case 1:
                            return "������";
                    }
                }
                break;


            case 79:
                {
                    switch (int_Language)
                    {
                        case 0:
                            return "Are you sure want to exit?";

                        case 1:
                            return "�� ������������� ������ �����?";
                    }
                }
                break;
            //////	


            default:
                {
                    return "";
                }
        }

        return "";
    }
}
