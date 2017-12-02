using System;

// Shared Class that contains static objects of others classes
public class  ObjCopy
{
	public static NetworkAction obj_NetworkAction = new NetworkAction();
	public static RemoteCallAction obj_RemoteCallAction = new RemoteCallAction();

	public static MainClientForm obj_MainClientForm = null;
	public static FilesDownloadForm obj_FilesDownloadForm = null;
	public static FilesUploadForm obj_FilesUploadForm = null;
	public static RenameFolderOrFileForm obj_RenameFolderOrFileForm = null;
	public static ConfirmFileReplaceForm obj_ConfirmFileReplaceForm = null;
	public static RTDVForm obj_RTDVForm = null;
	public static MiniRTDVForm obj_MiniRTDVForm;
	public static FileManagerObjectPropertiesForm obj_FileManagerObjectPropertiesForm = null;

    //public static SoundPlayAndCapture obj_SoundPlayAndCapture = null;

    
}

