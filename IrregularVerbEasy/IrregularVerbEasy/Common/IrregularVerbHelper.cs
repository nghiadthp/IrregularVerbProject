using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrregularVerbEasy.Common
{
    class IrregularVerbHelper
    {

        #region Private Static Methods
        
        /// <summary>
        /// Instance of IrregularVerbHelper
        /// </summary>
        private static IrregularVerbHelper _irregularVerbHelper;

        #endregion

        #region Static Assessments

        /// <summary>
        /// Get instance of IrregularVerbHelper
        /// </summary>
        public static IrregularVerbHelper Instance
        {
            get { return _irregularVerbHelper ?? (_irregularVerbHelper = new IrregularVerbHelper()); }
        }

        /// <summary>
        /// Contructor
        /// </summary>
        private IrregularVerbHelper() { }

        #endregion

        /// <summary>
        /// Random a number in range 0 -> 415
        /// </summary>
        /// <returns></returns>
        public int RandomNumber()
        {
            Random random = new Random();
            int number = random.Next(0, 415);

            return number;
        }

        /// <summary>
        /// Random a number in range start number -> end number
        /// </summary>
        /// <param name="startNum"></param>
        /// <param name="endNum"></param>
        /// <returns></returns>
        public int RandomNumber(int startNum, int endNum)
        {
            Random random = new Random();
            int number = random.Next(startNum, endNum);

            return number;
        }

        /// <summary>
        /// Create list of different numbers
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public int[] CreateNumberList(int size)
        {
            int[] list = new int[size];
            //Set default value = -1
            for (int i = 0; i < size; i++)
            {
                list[i] = -1;
            }

            // random list different number
            for (int i = 0; i < size; i++)
            {
                bool equalNumberInList = true;
                while (equalNumberInList)
                {
                    int temp = RandomNumber();
                    foreach (int num in list)
                    {
                        if (temp != num)
                        {
                            equalNumberInList = false;
                        }
                        else
                        {
                            equalNumberInList = true;
                            break;
                        }
                    }
                    if (!equalNumberInList)
                    {
                        list[i] = temp;
                    }

                }

            }

            return list;
        }

        /// <summary>
        /// Return data table with missing data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable DataTableWithMissingData(DataTable data)
        {
            DataTable dataTable = NewDataTable();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                int randomPosition = RandomNumber(0, 2);

                if (randomPosition == 0)
                {
                    dataTable.Rows.Add(data.Rows[i].Field<string>(Constant.verb), "", "");
                }
                else if (randomPosition == 1)
                {
                    dataTable.Rows.Add("", data.Rows[i].Field<string>(Constant.past), "");
                }
                else
                {
                    dataTable.Rows.Add("", "", data.Rows[i].Field<string>(Constant.past2));
                }
            }

            return dataTable;

        }

        /// <summary>
        /// Return DataTable with random word list
        /// </summary>
        /// <param name="numberRows"></param>
        /// <returns></returns>
        public DataTable GetDataTableWithSpecificRows(int numberRows)
        {
            DataTable originalDataTable = GetOriginalDataTable();
            DataTable randomRowDataTable = NewDataTable();

            int[] rowNumberList = CreateNumberList(numberRows);
            foreach (int randomNumber in rowNumberList)
            {
                randomRowDataTable.Rows.Add(originalDataTable.Rows[randomNumber].Field<string>("Verb"),
                                            originalDataTable.Rows[randomNumber].Field<string>("Past"), 
                                            originalDataTable.Rows[randomNumber].Field<string>("Past II"));
            }

            return randomRowDataTable;
        }

        /// <summary>
        /// Return DataTable with full irregular verb words
        /// </summary>
        /// <returns></returns>
        public DataTable GetOriginalDataTable()
        {
            string path1 = Path.Combine(Environment.CurrentDirectory, @"Asset\Data\exportdemo.xlsx");
            string sheetName = "Main";
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path1 + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
            DataTable data = new DataTable();
            try
            {
                //string path =  @"..\..\Asset\DataBase\exportdemo.xlsx";

                OleDbConnection oldDbConnection = new OleDbConnection(connectionString);
                OleDbCommand oleDbCommand =
                    new OleDbCommand(@"Select * From [" + sheetName + @"$A:D] where [Verb] is not null ",
                        oldDbConnection);
                oldDbConnection.Open();

                OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);

                oleDbDataAdapter.Fill(data);
            }
            catch (Exception)
            {
                // ignored
            }

            return data;
        }

        /// <summary>
        /// Data table with only one row for create question
        /// </summary>
        /// <param name="verb"></param>
        /// <param name="past"></param>
        /// <param name="past2"></param>
        /// <returns></returns>
        public DataTable OneRowDataTable(string verb, string past, string past2)
        {
            DataTable data = NewDataTable();
            data.Rows.Add(verb, past, past2);
            return data;
        }

        /// <summary>
        /// return new DataTable in irregular verb format
        /// </summary>
        /// <returns></returns>
        public DataTable NewDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(Constant.verb, typeof(string));
            dataTable.Columns.Add(Constant.past, typeof(string));
            dataTable.Columns.Add(Constant.past2, typeof(string));

            return dataTable;
        }
    }
}
