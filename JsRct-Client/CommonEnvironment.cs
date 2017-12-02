using System;
using System.Security.Cryptography;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Windows.Forms;
using JurikSoft.Compression;
using JurikSoft.XMLConfigImporer;
using JurikSoft.XMLConfigImporer.JsRctClient;
using JurikSoft.XMLConfigImporer.JsRctClient.Version110;

public class ConmpressionEnvironment
{
    public ConmpressionEnvironment()
    {
        if (iCompressionArray_obj[1] != null) return;

        iCompressionArray_obj[1] = new JurikSoft.Compression.PrefixCodes(true);
        iCompressionArray_obj[2] = new JurikSoft.Compression.PrefixCodes(false);
        iCompressionArray_obj[3] = new JurikSoft.Compression.LZSS(8, true, true, false, 131072);
        iCompressionArray_obj[4] = new DeflateCompressionWrapper();
        iCompressionArray_obj[5] = new JurikSoft.Compression.RLE(JurikSoft.Compression.PrefixCodesCompression.NonAdaptive);
    }

    public static ICompression[] iCompressionArray_obj = new ICompression[6];

    public class DeflateCompressionWrapper : JurikSoft.Compression.ICompression
    {
        MemoryStream memoryStream_DecompressedData = new MemoryStream();
        MemoryStream memoryStream_DataToCompress = new MemoryStream();

        public byte[] Compress(byte[] DataToCompress, bool AddCheckSum)
        {
            memoryStream_DataToCompress.SetLength(0);

            DeflateStream deflateStream_obj = new DeflateStream(memoryStream_DataToCompress, CompressionMode.Compress, true);

            deflateStream_obj.Write(DataToCompress, 0, DataToCompress.Length);

            deflateStream_obj.Close();

            memoryStream_DataToCompress.SetLength(memoryStream_DataToCompress.Position);

            return memoryStream_DataToCompress.ToArray();
        }

        public byte[] Decompress(byte[] byteArray_DeflateCompressedData)
        {
            MemoryStream memoryStream_CompressedData = new MemoryStream(byteArray_DeflateCompressedData, 0, byteArray_DeflateCompressedData.Length);

            memoryStream_DecompressedData.SetLength(0);

            memoryStream_CompressedData.Position = 0;

            DeflateStream deflateStream_obj = new DeflateStream(memoryStream_CompressedData, CompressionMode.Decompress, true);

            int int_DecompressedByte = 0;

            for (; ; )
            {
                int_DecompressedByte = deflateStream_obj.ReadByte();

                if (int_DecompressedByte == -1) break;

                memoryStream_DecompressedData.WriteByte((byte)int_DecompressedByte);
            }

            deflateStream_obj.Flush();
            deflateStream_obj.Close();

            memoryStream_CompressedData.Close();

            memoryStream_DecompressedData.SetLength(memoryStream_DecompressedData.Position);

            return memoryStream_DecompressedData.ToArray();
        }
    }
}


public class CommonMethods
{
    public static string ReadStringFromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_StringLength = new byte[4];

        obj_MemoryStream.Read(byteArray_StringLength, 0, 4);

        byte[] byteArray_String = new byte[BitConverter.ToInt32(byteArray_StringLength, 0)];

        obj_MemoryStream.Read(byteArray_String, 0, BitConverter.ToInt32(byteArray_StringLength, 0));

        return Encoding.Unicode.GetString(byteArray_String);
    }

    public static int ReadIntFromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_Int = new byte[4];

        obj_MemoryStream.Read(byteArray_Int, 0, 4);

        return BitConverter.ToInt32(byteArray_Int, 0);
    }

    public static Int16 ReadInt16FromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_Int16 = new byte[2];

        obj_MemoryStream.Read(byteArray_Int16, 0, 2);

        return BitConverter.ToInt16(byteArray_Int16, 0);
    }

    public static long ReadInt64FromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_Int = new byte[8];

        obj_MemoryStream.Read(byteArray_Int, 0, 8);

        return BitConverter.ToInt64(byteArray_Int, 0);
    }

    public static byte[] ReadBytesFromStream(MemoryStream obj_MemoryStream)
    {
        byte[] byteArray_BytesLength = new byte[4];

        obj_MemoryStream.Read(byteArray_BytesLength, 0, 4);

        byte[] byteArray_Bytes = new byte[BitConverter.ToInt32(byteArray_BytesLength, 0)];

        obj_MemoryStream.Read(byteArray_Bytes, 0, BitConverter.ToInt32(byteArray_BytesLength, 0));

        return byteArray_Bytes;
    }



    public static void WriteStringToStream(MemoryStream obj_MemoryStream, string string_StringForWrite)
    {
        byte[] byteArray_StringForWrite = Encoding.Unicode.GetBytes(string_StringForWrite),
                byteArray_StringForWriteLength = BitConverter.GetBytes(byteArray_StringForWrite.Length);

        obj_MemoryStream.Write(byteArray_StringForWriteLength, 0, byteArray_StringForWriteLength.Length);

        obj_MemoryStream.Write(byteArray_StringForWrite, 0, byteArray_StringForWrite.Length);
    }

    public static void WriteIntToStream(MemoryStream obj_MemoryStream, int int_IntForWrite)
    {
        obj_MemoryStream.Write(BitConverter.GetBytes(int_IntForWrite), 0, 4);
    }

    public static void WriteInt16ToStream(MemoryStream obj_MemoryStream, Int16 int16_IntForWrite)
    {
        obj_MemoryStream.Write(BitConverter.GetBytes(int16_IntForWrite), 0, 2);
    }

    public static void WriteBytesToStream(MemoryStream obj_MemoryStream, byte[] byteArray_BytesForWrite)
    {
        byte[] byteArray_BytesForWriteLength = BitConverter.GetBytes(byteArray_BytesForWrite.Length);

        obj_MemoryStream.Write(byteArray_BytesForWriteLength, 0, byteArray_BytesForWriteLength.Length);

        obj_MemoryStream.Write(byteArray_BytesForWrite, 0, byteArray_BytesForWrite.Length);
    }

    public static void WriteInt64ToStream(MemoryStream obj_MemoryStream, long int_IntForWrite)
    {
        obj_MemoryStream.Write(BitConverter.GetBytes(int_IntForWrite), 0, 8);
    }



    public static byte[] GetByteArrayPart(byte[] byteArray_FullBytesArray, int int_StartPosition, int int_Length)
    {
        byte[] byteArray_NewBuffer = new byte[int_Length];

        int int_PositionInNewBuffer = 0;

        for (int int_CycleCount = 0; int_CycleCount != int_Length; int_CycleCount++, int_PositionInNewBuffer++)
        {
            byteArray_NewBuffer[int_PositionInNewBuffer] = byteArray_FullBytesArray[int_StartPosition + int_CycleCount];
        }

        return byteArray_NewBuffer;
    }

    public static bool IsBytesArraysEquals(byte[] byteArray_InitialData, byte[] byteArray_ComparedData)
    {
        if (byteArray_InitialData.Length != byteArray_ComparedData.Length) return false;

        for (int int_CycleCount = 0; int_CycleCount != byteArray_InitialData.Length; int_CycleCount++)
        {
            if (byteArray_InitialData[int_CycleCount] != byteArray_ComparedData[int_CycleCount]) return false;
        }

        return true;
    }
}


public class UserAccountsAndAccessRestrictionRulesEnvironment
{
    public static void EditSelectedProxyServerInfo(int int_SelectedProxyServerRowIndex)
    {
        ProxyDBManagerForm proxyDBManagerForm_obj = new ProxyDBManagerForm();

        proxyDBManagerForm_obj.AddButton.Visible = false;

        proxyDBManagerForm_obj.EditedRecordIndex = int_SelectedProxyServerRowIndex;

        if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < 2 ||
            JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < int_SelectedProxyServerRowIndex + 2)
        {
            return;
        }

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

        proxyDBManagerForm_obj.ProxyTypeList.SelectedIndex = (int)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTypeColumn] ;
        proxyDBManagerForm_obj.HostTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
        proxyDBManagerForm_obj.PortTextBox.Text = ((int)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyPortColumn]).ToString();
        proxyDBManagerForm_obj.TimeOutComboBox.SelectedIndex = ((int)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn] / 5000) - 1;
        proxyDBManagerForm_obj.AuthenticationCheckBox.Checked = (bool)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];
        proxyDBManagerForm_obj.ResolveHostnamesCheckBox.Checked = (bool)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];
        proxyDBManagerForm_obj.LoginTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.LoginColumn];
        proxyDBManagerForm_obj.PasswordTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.PasswordColumn];
        proxyDBManagerForm_obj.TitleTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyServerTitleColumn];
        proxyDBManagerForm_obj.LocationTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyServerLocationColumn];
        proxyDBManagerForm_obj.DescriptionTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyServerDescriptionColumn];

        proxyDBManagerForm_obj.ShowDialog();
    }
    
    public static void ViewSelectedProxyServerInfo(int int_SelectedProxyServerRowIndex)
    {
        ProxyDBManagerForm proxyDBManagerForm_obj = new ProxyDBManagerForm();

        proxyDBManagerForm_obj.AddButton.Visible = false;
        proxyDBManagerForm_obj.ApplyButton.Visible = false;

        proxyDBManagerForm_obj.CancelButton.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);

        if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < 2 ||
           JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings.Rows.Count < int_SelectedProxyServerRowIndex + 2)
        {
            return;
        }

        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.ProxyServersSettingsDataTable ProxyServersSettingsDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.ProxyServersSettings;

        proxyDBManagerForm_obj.ProxyTypeList.SelectedIndex = (int)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTypeColumn] ;
        proxyDBManagerForm_obj.HostTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyHostColumn];
        proxyDBManagerForm_obj.PortTextBox.Text = ((int)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyPortColumn]).ToString();
        proxyDBManagerForm_obj.TimeOutComboBox.SelectedIndex = ((int)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyTimeOutColumn] / 5000) - 1;
        proxyDBManagerForm_obj.AuthenticationCheckBox.Checked = (bool)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.UseAuthenticationColumn];
        proxyDBManagerForm_obj.ResolveHostnamesCheckBox.Checked = (bool)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.UseProxyToResolveHostNamesColumn];
        proxyDBManagerForm_obj.LoginTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.LoginColumn];
        proxyDBManagerForm_obj.PasswordTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.PasswordColumn];
        proxyDBManagerForm_obj.TitleTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyServerTitleColumn];
        proxyDBManagerForm_obj.LocationTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyServerLocationColumn];
        proxyDBManagerForm_obj.DescriptionTextBox.Text = (string)ProxyServersSettingsDataTable_obj[int_SelectedProxyServerRowIndex + 1][ProxyServersSettingsDataTable_obj.ProxyServerDescriptionColumn];

        proxyDBManagerForm_obj.ProxyTypeList.Enabled = false;
        proxyDBManagerForm_obj.HostTextBox.ReadOnly = true;
        proxyDBManagerForm_obj.PortTextBox.ReadOnly = true;
        proxyDBManagerForm_obj.TimeOutComboBox.Enabled = false;
        proxyDBManagerForm_obj.AuthenticationCheckBox.Enabled = false;
        proxyDBManagerForm_obj.ResolveHostnamesCheckBox.Enabled = false;
        proxyDBManagerForm_obj.LoginTextBox.ReadOnly = true;
        proxyDBManagerForm_obj.PasswordTextBox.ReadOnly = true;
        proxyDBManagerForm_obj.TitleTextBox.ReadOnly = true;
        proxyDBManagerForm_obj.LocationTextBox.ReadOnly = true;
        proxyDBManagerForm_obj.DescriptionTextBox.ReadOnly = true;

        proxyDBManagerForm_obj.ShowDialog();
    }
    
    public static void EditSelectedJurikSoftServerInfo(int int_SelectedJurikSoftServerRowIndex)
    {
        JurikSoftServersDBManagerForm jurikSoftServersDBManagerForm_obj = new JurikSoftServersDBManagerForm();

        jurikSoftServersDBManagerForm_obj.CancelButton.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);

        if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Count == 0)
        {
            return;
        }

        jurikSoftServersDBManagerForm_obj.AddButton.Visible = false;


        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

        jurikSoftServersDBManagerForm_obj.ServerDescriptionTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerDescriptionColumn];
        jurikSoftServersDBManagerForm_obj.ServerHostTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerHostColumn];
        jurikSoftServersDBManagerForm_obj.ServerLocationTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerLocationColumn];
        jurikSoftServersDBManagerForm_obj.ServerNameTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerNameColumn];
        jurikSoftServersDBManagerForm_obj.ServerPortTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerPortColumn].ToString();
        jurikSoftServersDBManagerForm_obj.ServerNetworkWorkgroupTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.WorkGroupColumn];
        jurikSoftServersDBManagerForm_obj.ServerNetworkDomainTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.DomainColumn];
        jurikSoftServersDBManagerForm_obj.LoginForConnectionTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.LoginColumn];
        jurikSoftServersDBManagerForm_obj.PasswordForConnectionTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.PasswordColumn];

        jurikSoftServersDBManagerForm_obj.ServerGroupsListBox.SelectedIndex = (int)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerGroupTypeIDColumn];
        jurikSoftServersDBManagerForm_obj.ProxyServersListView.Enabled = true;

        jurikSoftServersDBManagerForm_obj.UseProxyCheckBox.Checked = (bool)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.UseProxyServerColumn];

        if (jurikSoftServersDBManagerForm_obj.UseProxyCheckBox.Checked)
        {
            int int_SelectedProxyIndex = (int)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ProxyServerIDColumn];

            jurikSoftServersDBManagerForm_obj.ProxyServersListView.Items[int_SelectedProxyIndex - 1].Selected = true;
        }

        jurikSoftServersDBManagerForm_obj.EditedRecordIndex = int_SelectedJurikSoftServerRowIndex;

        jurikSoftServersDBManagerForm_obj.ShowDialog();
    }
    
    public static void ViewSelectedJurikSoftServerInfo(int int_SelectedJurikSoftServerRowIndex)
    {
        JurikSoftServersDBManagerForm jurikSoftServersDBManagerForm_obj = new JurikSoftServersDBManagerForm();

        jurikSoftServersDBManagerForm_obj.AddButton.Visible = false;
        jurikSoftServersDBManagerForm_obj.ApplyButton.Visible = false;

        jurikSoftServersDBManagerForm_obj.GroupMember.Visible = false;
        jurikSoftServersDBManagerForm_obj.UsedsProxy.Visible = false;

        jurikSoftServersDBManagerForm_obj.CancelButton.Text = ClientStringFactory.GetString(5, ClientSettingsEnvironment.CurrentLanguage);

        if (JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers.Rows.Count == 0)
        {
            return;
        }


        jurikSoftServersDBManagerForm_obj.ViewProxyRecordButton.Visible = false;
        jurikSoftServersDBManagerForm_obj.AddProxyRecordButton.Visible = false;
        jurikSoftServersDBManagerForm_obj.EditProxyRecordButton.Visible = false;

        jurikSoftServersDBManagerForm_obj.ApplyButton.Visible = false;
        jurikSoftServersDBManagerForm_obj.AddButton.Visible = false;

        jurikSoftServersDBManagerForm_obj.RenameGroupButton.Visible = false;
        jurikSoftServersDBManagerForm_obj.RemoveGroupButton.Visible = false;
        jurikSoftServersDBManagerForm_obj.AddNewGroupButton.Visible = false;

        jurikSoftServersDBManagerForm_obj.UseProxyCheckBox.Enabled = false;

        jurikSoftServersDBManagerForm_obj.ServerDescriptionTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.ServerHostTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.ServerLocationTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.ServerNameTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.ServerPortTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.ServerNetworkWorkgroupTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.ServerNetworkDomainTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.LoginForConnectionTextBox.ReadOnly = true;
        jurikSoftServersDBManagerForm_obj.PasswordForConnectionTextBox.ReadOnly = true;


        jurikSoftServersDBManagerForm_obj.ServerGroupsListBox.Enabled = false;
        jurikSoftServersDBManagerForm_obj.ProxyServersListView.Enabled = false;



        DataSet_Client_Ver110.DataSet_JurikSoftClientDB.JurikSoftServersDataTable jurikSoftServersDataTableDataTable_obj = JsRctClientV110XMLConfigImporter.JurikSoftClientDB.JurikSoftServers;

        jurikSoftServersDBManagerForm_obj.ServerDescriptionTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerDescriptionColumn];
        jurikSoftServersDBManagerForm_obj.ServerHostTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerHostColumn];
        jurikSoftServersDBManagerForm_obj.ServerLocationTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerLocationColumn];
        jurikSoftServersDBManagerForm_obj.ServerNameTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerNameColumn];
        jurikSoftServersDBManagerForm_obj.ServerPortTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerPortColumn].ToString();
        jurikSoftServersDBManagerForm_obj.ServerNetworkWorkgroupTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.WorkGroupColumn];
        jurikSoftServersDBManagerForm_obj.ServerNetworkDomainTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.DomainColumn];
        jurikSoftServersDBManagerForm_obj.LoginForConnectionTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.LoginColumn];
        jurikSoftServersDBManagerForm_obj.PasswordForConnectionTextBox.Text = (string)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.PasswordColumn];

        jurikSoftServersDBManagerForm_obj.ServerGroupsListBox.SelectedIndex = (int)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ServerGroupTypeIDColumn];
        jurikSoftServersDBManagerForm_obj.ProxyServersListView.Enabled = true;

        jurikSoftServersDBManagerForm_obj.UseProxyCheckBox.Checked = (bool)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.UseProxyServerColumn];

        if (jurikSoftServersDBManagerForm_obj.UseProxyCheckBox.Checked)
        {
            int int_SelectedProxyIndex = (int)jurikSoftServersDataTableDataTable_obj[int_SelectedJurikSoftServerRowIndex][jurikSoftServersDataTableDataTable_obj.ProxyServerIDColumn];

            jurikSoftServersDBManagerForm_obj.ProxyServersListView.Items[int_SelectedProxyIndex - 1].Selected = true;
        }

        jurikSoftServersDBManagerForm_obj.ShowDialog();
    }
}