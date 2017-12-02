using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace JurikSoft
{
    namespace Server_Core
    {

        public class DatabaseOfSendingFiles
        {
            static List<DatabaseOfSendingFiles> list_DatabaseOfSendingFiles = new List<DatabaseOfSendingFiles>();

            public static List<DatabaseOfSendingFiles> SendingFilesCollectionDB
            {
                get
                {
                    return list_DatabaseOfSendingFiles;
                }
            }



            int int_UINT;

            Int64 int64_SizeOfSendingFile;

            public FileStream fileStream_SendingFile;

            TcpClient tcpClient_WorkingClient;

            public TcpClient WorkingClient
            {
                set
                {
                    tcpClient_WorkingClient = value;
                }

                get
                {
                    return tcpClient_WorkingClient;
                }
            }


            public int UINT
            {
                get
                {
                    return int_UINT;
                }

                set
                {
                    int_UINT = value;
                }
            }


            public Int64 SizeOfSendingFile
            {

                get
                {
                    return int64_SizeOfSendingFile;
                }

                set
                {
                    int64_SizeOfSendingFile = value;
                }
            }


        }

        public class DatabaseOfUploadingFiles
        {
            static List<DatabaseOfUploadingFiles> list_DatabaseOfUploadingFiles = new List<DatabaseOfUploadingFiles>();

            public static List<DatabaseOfUploadingFiles> UploadingFilesCollectionDB
            {
                get
                {
                    return list_DatabaseOfUploadingFiles;
                }
            }


            int int_UINT;

            Int64 int64_SizeOfUploadingFile;

            public FileStream fileStream_UploadingFile;

            TcpClient tcpClient_WorkingClient;

            public TcpClient WorkingClient
            {
                set
                {
                    tcpClient_WorkingClient = value;
                }

                get
                {
                    return tcpClient_WorkingClient;
                }
            }


            public int UINT
            {
                get
                {
                    return int_UINT;
                }

                set
                {
                    int_UINT = value;
                }
            }

            public Int64 SizeOfUploadingFile
            {

                get
                {
                    return int64_SizeOfUploadingFile;
                }

                set
                {
                    int64_SizeOfUploadingFile = value;
                }
            }

        }
    }
}