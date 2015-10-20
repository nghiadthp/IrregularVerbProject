using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace IrregularVerbEasy.Model
{
    class IrregularVerb
    {
        private String _verb = String.Empty;
        private String _past = String.Empty;
        private String _past2 = String.Empty;
        private String _meaning = String.Empty;

        public String Verb
        {
            get { return _verb; }
            set { _verb = value; }
        }

        public String Past
        {
            get { return _past; }
            set { _past = value; }
        }

        public String Past2
        {
            get { return _past2; }
            set { _past2 = value; }
        }

        ///// <summary>
        ///// Random a number in range 0 -> 415
        ///// </summary>
        ///// <returns></returns>
        //public int RandomNumber()
        //{
        //    Random random = new Random();
        //    int number = random.Next(0, 415);

        //    return number;
        //}

        ///// <summary>
        ///// Random a number in range start number -> end number
        ///// </summary>
        ///// <param name="startNum"></param>
        ///// <param name="endNum"></param>
        ///// <returns></returns>
        //public int RandomNumber(int startNum, int endNum)
        //{
        //    Random random = new Random();
        //    int number = random.Next(startNum, endNum);

        //    return number;
        //}

        //public int[] CreateNumberList(int size)
        //{
        //    int[] list = new int[size];
        //    //Set default value = -1
        //    for (int i = 0; i < size; i++)
        //    {
        //        list[i] = -1;
        //    }

        //    // random list different number
        //    for (int i = 0; i < size; i++)
        //    {
        //        bool equalNumberInList = true;
        //        while (equalNumberInList)
        //        {
        //            int temp = RandomNumber();
        //            foreach (int num in list)
        //            {
        //                if (temp != num)
        //                {
        //                    equalNumberInList = false;
        //                }
        //                else
        //                {
        //                    equalNumberInList = true;
        //                    break;
        //                }
        //            }
        //            if (!equalNumberInList)
        //            {
        //                list[i] = temp;
        //            }

        //        }

        //    }

        //    return list;
        //}
        //public DataTable GetOriginalDataTable()
        //{
        //    string path1 = Path.Combine(Environment.CurrentDirectory, @"Asset\Data\exportdemo.xlsx");
        //    string sheetName = "Main";
        //    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 +";Extended Properties='Excel 12.0 XML;HDR=YES;';";
        //    DataTable data = new DataTable();
        //    try
        //    {
        //        //string path = "c:\\users\\vu\\documents\\visual studio 2015\\Projects\\IrregularVerb_Ver_1\\IrregularVerb_Ver_1\\Asset\\DataBase\\exportdemo.xlsx";
        //        //string path =  @"..\..\Asset\DataBase\exportdemo.xlsx";
        //        OleDbConnection oldDbConnection = new OleDbConnection(connectionString);
        //        OleDbCommand oleDbCommand =
        //            new OleDbCommand(@"Select * From [" + sheetName + @"$A:D] where [Verb] is not null ",
        //                oldDbConnection);
        //        oldDbConnection.Open();

        //        OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);

        //        oleDbDataAdapter.Fill(data);
        //    }
        //    catch (Exception)
        //    {
        //        // ignored
        //    }

        //    return data;
        //}

        //public DataTable GetDataTableWithSpecificRows(int numberRows)
        //{
        //    List<IrregularVerb> verbList = new List<IrregularVerb>();

        //    DataTable originalDataTable = GetOriginalDataTable();
        //    DataTable randomRowDataTable = new DataTable();
        //    randomRowDataTable.Columns.Add("Verb", typeof(string));
        //    randomRowDataTable.Columns.Add("Past", typeof(string));
        //    randomRowDataTable.Columns.Add("PastII", typeof(string));

        //    int[] rowNumberList = CreateNumberList(numberRows);
        //    foreach (int randomNumber in rowNumberList)
        //    {
        //        randomRowDataTable.Rows.Add(originalDataTable.Rows[randomNumber].Field<string>("Verb"), originalDataTable.Rows[randomNumber].Field<string>("Past"), originalDataTable.Rows[randomNumber].Field<string>("Past II"));
        //    }

        //    return randomRowDataTable;
        //}

        ///// <summary>
        ///// Return data table with missing data
        ///// </summary>
        ///// <param name="data"></param>
        ///// <returns></returns>
        //public DataTable DataTableWithMissingData(DataTable data)
        //{
        //    DataTable dataTable = NewDataTable();

        //    for (int i = 0; i < data.Rows.Count; i++)
        //    {
        //        int randomPosition = RandomNumber(0, 2);

        //        if (randomPosition == 0)
        //        {
        //            dataTable.Rows.Add(data.Rows[i].Field<string>("Verb"), "", "");
        //        }
        //        else if (randomPosition == 1)
        //        {
        //            dataTable.Rows.Add("", data.Rows[i].Field<string>("Past"), "");
        //        }
        //        else
        //        {
        //            dataTable.Rows.Add("", "", data.Rows[i].Field<string>("PastII"));
        //        }
        //    }

        //    return dataTable;

        //}

        ///// <summary>
        ///// Data table with only one row for create question
        ///// </summary>
        ///// <param name="verb"></param>
        ///// <param name="past"></param>
        ///// <param name="past2"></param>
        ///// <returns></returns>
        //public DataTable OneRowDataTable(string verb, string past, string past2)
        //{
        //    DataTable data = NewDataTable();
        //    data.Rows.Add(verb, past, past2);
        //    return data;
        //}

        ///// <summary>
        ///// return new DataTable in irregular verb format
        ///// </summary>
        ///// <returns></returns>
        //public DataTable NewDataTable()
        //{
        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Verb", typeof(string));
        //    dataTable.Columns.Add("Past", typeof(string));
        //    dataTable.Columns.Add("PastII", typeof(string));

        //    return dataTable;
        //}
    }
}
