using System;
using System.IO;
using System.Collections.Generic;

//class with file transfer functionality 
public class DatabaseOfDownloadingFiles
{
    static List<DatabaseOfDownloadingFiles> list_DatabaseOfDownloadingFiles = new List<DatabaseOfDownloadingFiles>();
    public static List<DatabaseOfDownloadingFiles> DatabaseOfDownloadingFilesList
    {
        get
        {
            return list_DatabaseOfDownloadingFiles;
        }
        set
        {
            list_DatabaseOfDownloadingFiles = value;
        }
    }
    
    FileStream fileStream_DownloadingFile;
    public FileStream DownloadingFileStream
    {
        get
        {
            return fileStream_DownloadingFile;
        }
        set
        {
            fileStream_DownloadingFile = value;
        }
    }


    int int_UINT = 0, int_IsLastFragment = 0;

    long long_SizeOfDownloadingFile, long_BytesReceived = 0;

    static long long_TotalDownloadingSize = 0, long_TotalBytesRecieved = 0;

    string string_NameOfDownloadingFile, string_LocalFolderForReceivedFiles,
           string_TimeOfLastFileWrite, string_RemoteFileNameAndPath;

    //The Unique Id number of Transferring Job!!!
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

    public long SizeOfDownloadingFile
    {

        get
        {
            return long_SizeOfDownloadingFile;
        }

        set
        {
            long_SizeOfDownloadingFile = value;
        }
    }

    public int IsLastFragment
    {
        get
        {
            return int_IsLastFragment;
        }

        set
        {
            int_IsLastFragment = value;
        }
    }

    public long BytesReceived
    {
        get
        {
            return long_BytesReceived;
        }

        set
        {
            long_BytesReceived = value;
        }
    }


    public static long TotalDownloadingSize
    {
        get
        {
            return long_TotalDownloadingSize;
        }

        set
        {
            long_TotalDownloadingSize = value;
        }
    }

    public static long TotalBytesRecieved
    {
        get
        {
            return long_TotalBytesRecieved;
        }

        set
        {
            long_TotalBytesRecieved = value;
        }
    }


    public string TimeOfLastFileWrite
    {
        get
        {
            return string_TimeOfLastFileWrite;
        }

        set
        {
            string_TimeOfLastFileWrite = value;
        }
    }

    public string RemoteFileNameAndPath
    {

        get
        {
            return string_RemoteFileNameAndPath;
        }

        set
        {
            string_RemoteFileNameAndPath = value;
        }

    }

    public string NameOfDownloadingFile
    {
        get
        {
            return string_NameOfDownloadingFile;
        }

        set
        {
            string_NameOfDownloadingFile = value;
        }
    }

    public string LocalFolderForReceivedFiles
    {
        get
        {
            return string_LocalFolderForReceivedFiles;
        }

        set
        {
            string_LocalFolderForReceivedFiles = value;
        }
    }


}


public class DatabaseOfDownloadingFolders
{
    public static List<DatabaseOfDownloadingFolders> list_DatabaseOfDownloadingFolders = new List<DatabaseOfDownloadingFolders>();

    string string_NameOfDownloadingFolder, string_LocalFolderForReceivedFolder, string_RemoteFolderNameAndPath;

    public string RemoteFolderNameAndPath
    {

        get
        {
            return string_RemoteFolderNameAndPath;
        }

        set
        {
            string_RemoteFolderNameAndPath = value;
        }

    }

    public string NameOfDownloadingFolder
    {
        get
        {
            return string_NameOfDownloadingFolder;
        }

        set
        {
            string_NameOfDownloadingFolder = value;
        }
    }

    public string LocalFolderForReceivedFolder
    {
        get
        {
            return string_LocalFolderForReceivedFolder;
        }

        set
        {
            string_LocalFolderForReceivedFolder = value;
        }
    }
}




public class DatabaseOfUploadingFiles
{

    public static List<DatabaseOfUploadingFiles> list_DatabaseOfUploadingFiles = new List<DatabaseOfUploadingFiles>();

    public FileStream fileStream_UploadingFile;

    int int_UINT = 0, int_IsLastFragment = 0;

    long long_SizeOfUploadingFile, long_BytesSent = 0;

    string string_NameOfUploadingFile, string_RemoteFolderForReceivedFiles,
           string_TimeOfLastFileWrite, string_LocalNameOfFileWithPath;

    static long long_TotalUploadingSize = 0, long_TotalBytesUploaded = 0;
   
    //The Unique Id number of Transferring Job!!!
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

    public long SizeOfUploadingFile
    {

        get
        {
            return long_SizeOfUploadingFile;
        }

        set
        {
            long_SizeOfUploadingFile = value;
        }
    }

    public int IsLastFragment
    {
        get
        {
            return int_IsLastFragment;
        }

        set
        {
            int_IsLastFragment = value;
        }
    }

    public long BytesSent
    {
        get
        {
            return long_BytesSent;
        }

        set
        {
            long_BytesSent = value;
        }
    }


    public static long TotalUploadingSize
    {

        get
        {
            return long_TotalUploadingSize;
        }

        set
        {
            long_TotalUploadingSize = value;
        }
    }

    public static long TotalBytesUploaded
    {

        get
        {
            return long_TotalBytesUploaded;
        }

        set
        {
            long_TotalBytesUploaded = value;
        }
    }


    public string TimeOfLastFileWrite
    {
        get
        {
            return string_TimeOfLastFileWrite;
        }

        set
        {
            string_TimeOfLastFileWrite = value;
        }
    }

    public string LocalNameOfFileWithPath
    {
        get
        {
            return string_LocalNameOfFileWithPath;
        }

        set
        {
            string_LocalNameOfFileWithPath = value;
        }
    }

    public string NameOfUploadingFile
    {
        get
        {
            return string_NameOfUploadingFile;
        }

        set
        {
            string_NameOfUploadingFile = value;
        }
    }

    public string RemoteFolderForReceivedFiles
    {
        get
        {
            return string_RemoteFolderForReceivedFiles;
        }

        set
        {
            string_RemoteFolderForReceivedFiles = value;
        }
    }
}

