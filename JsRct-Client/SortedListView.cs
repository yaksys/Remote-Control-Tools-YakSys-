using System.Collections;
using System.Windows.Forms;

public class ListViewColumnSorter : IComparer
{
	private int int_ColumnToSort;

	private SortOrder OrderOfSort;

	private CaseInsensitiveComparer caseInsensitiveComparer_obj;

	string string_FirstComparedObj,	string_SecondComparedObj;

	float float_FirstComparedObj, float_SecondComparedObj;
	
	public ListViewColumnSorter()
	{
		int_ColumnToSort = 0;

		OrderOfSort = SortOrder.None;

		caseInsensitiveComparer_obj = new CaseInsensitiveComparer();
	}	
	
	public int Compare(object object_FirstObject, object object_SecondObject)
	{
		int int_CompareResult = 0;

		ListViewItem listView_FirstObject, listView_SecondObject;

		listView_FirstObject = (ListViewItem)object_FirstObject;
		listView_SecondObject = (ListViewItem)object_SecondObject;

		string_FirstComparedObj = listView_FirstObject.SubItems[int_ColumnToSort].Text;
		string_SecondComparedObj = listView_SecondObject.SubItems[int_ColumnToSort].Text;
	
		int_CompareResult = caseInsensitiveComparer_obj.Compare(string_FirstComparedObj, string_SecondComparedObj);
			
		try
		{
			string_FirstComparedObj = string_FirstComparedObj.Replace(" ", "");
			string_SecondComparedObj = string_SecondComparedObj.Replace(" ", "");

			string_FirstComparedObj = string_FirstComparedObj.Replace(",", "");
			string_SecondComparedObj = string_SecondComparedObj.Replace(",", "");

			string_FirstComparedObj = string_FirstComparedObj.Replace(".", "");
			string_SecondComparedObj = string_SecondComparedObj.Replace(".", "");

			float_FirstComparedObj = float.Parse(string_FirstComparedObj);
			float_SecondComparedObj = float.Parse(string_SecondComparedObj);	

			if( string_FirstComparedObj.Length > string_SecondComparedObj.Length) int_CompareResult = 1;
			if( string_FirstComparedObj.Length < string_SecondComparedObj.Length) int_CompareResult = -1;	
			if( string_FirstComparedObj.Length == string_SecondComparedObj.Length) int_CompareResult = (int)(float_FirstComparedObj - float_SecondComparedObj);

		}
		catch
		{

		}

		if(OrderOfSort == SortOrder.Ascending) return int_CompareResult;
	
		else if(OrderOfSort == SortOrder.Descending) return (-int_CompareResult);

		else return 0;	
	}
    	
	public int SortColumn
	{
		set
		{
			int_ColumnToSort = value;
		}
		get
		{
			return int_ColumnToSort;
		}
	}
    
	public SortOrder Order
	{
		set
		{
			OrderOfSort = value;
		}
		get
		{
			return OrderOfSort;
		}
	}

}
