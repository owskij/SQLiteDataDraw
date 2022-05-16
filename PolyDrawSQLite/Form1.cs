using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;


namespace PicturePlotDB
{
    public partial class Form1 : Form
    {
        const double laMin = 0;
        const double laMax = 2000;
        const double tempMin = -273;
        const double tempMax = 3000;

        //Дата, температура и длины волн для масштабирования
        double MinDateTime, MaxDateTime;
        double LaMin, LaMax;
        double TempMin, TempMax;

        CultureInfo myCulInf = new CultureInfo("es-ES", false);
        OpenFileDialog openFileDialog = new OpenFileDialog();

        SQLiteDB myDB = new SQLiteDB();
        List<string> listID = new List<string>();
        
        string dataType = String.Empty;
        int numberOfSensors;
        int[] IDOfSensor;
        double leftDateTime, rightDateTime;

        int GWBL = 60;
        int GWBR = 10;
        int GHB = 110;
        int GHT = 30;
        int K1, K2, M1, M2;

        Color[] myGroupColors = new Color[100];

        private class Sensor
        {
            //public const double laMin = 0;
            //public const double laMax = 2000;
            const double dateTimeMin = 0;
            const double dateTimeMax = 1000000;

            public int ID;
            public int GroupID;

            public bool LaCur_Status = false;
            public bool LaCur0_Status = false;
            public bool LaCur1_Status = false;
            public bool LaCur2_Status = false;
            public bool LaCur3_Status = false;
            public bool LaCur4_Status = false;
            public bool LaShift_Status = false;
            public bool Temp_Status = false;

            //public long ID
            //{
            //    get { return id; }
            //    set { id = value; }
            //}
            //public long GroupID
            //{
            //    get { return groupid; }
            //    set { groupid = value; }
            //}

            public double DateTimeMin = dateTimeMax;
            public double DateTimeMax = dateTimeMin;
            public List<double> LaCur = new List<double>();
            public double LaCurMin = laMax;
            public double LaCurMax = laMin;

            public double DateTime0Min = dateTimeMax;
            public double DateTime0Max = dateTimeMin;
            public List<double> LaCur0 = new List<double>();
            public double LaCur0Min = laMax;
            public double LaCur0Max = laMin;

            public double DateTime1Min = dateTimeMax;
            public double DateTime1Max = dateTimeMin;
            public List<double> LaCur1 = new List<double>();
            public double LaCur1Min = laMax;
            public double LaCur1Max = laMin;

            public double DateTime2Min = dateTimeMax;
            public double DateTime2Max = dateTimeMin;
            public List<double> LaCur2 = new List<double>();
            public double LaCur2Min = laMax;
            public double LaCur2Max = laMin;

            public double DateTime3Min = dateTimeMax;
            public double DateTime3Max = dateTimeMin;
            public List<double> LaCur3 = new List<double>();
            public double LaCur3Min = laMax;
            public double LaCur3Max = laMin;

            public double DateTime4Min = dateTimeMax;
            public double DateTime4Max = dateTimeMin;
            public List<double> LaCur4 = new List<double>();
            public double LaCur4Min = laMax;
            public double LaCur4Max = laMin;

            public double DateTimeShiftMin = dateTimeMax;
            public double DateTimeShiftMax = dateTimeMin;
            public List<double> LaShift = new List<double>();
            public double LaShiftMin = laMax;
            public double LaShiftMax = laMin;

            public double DateTimeTempMin = dateTimeMax;
            public double DateTimeTempMax = dateTimeMin;
            public List<double> Temp = new List<double>();
            public double TempMin = 1000;
            public double TempMax = -273;
        }

        //MyClass[] MyClassVariable = new MyClass[10];
        List<Sensor> sensorsList = new List<Sensor>();

        public Form1()
        {
            InitializeComponent();
        }

        byte maxTry = 2;
        byte currTry = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            myGroupColors[0] = Color.Black;
            myGroupColors[1] = Color.Red;
            myGroupColors[2] = Color.Green;
            myGroupColors[3] = Color.Blue;
            myGroupColors[4] = Color.Violet;
            myGroupColors[5] = Color.Red;
            myGroupColors[6] = Color.Green;
            myGroupColors[7] = Color.Blue;
            myGroupColors[8] = Color.Violet;
            myGroupColors[8] = Color.Cyan;
            myGroupColors[9] = Color.HotPink;

            openFileDialog.InitialDirectory = @"C:\\";
            openFileDialog.Filter = "Data base files (*.db)|*.db| SQLite files (*.sqlite)|*.sqlite| All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            if (DbFilePathSearch()) Environment.Exit(0);

            AddToListCB();

            SQLiteDataReader reader = null;
            //SQLiteTransaction transaction = null;
            double minDateTime = 0, maxDateTime = 0;

            myDB.ConnectDB();
            myDB.ReadFromDB("SELECT min(DateTimeDouble) as MinDT, max(DateTimeDouble) as MaxDT FROM SensorsData;", ref reader);
            while (reader.Read())
            {
                minDateTime = Convert.ToDouble((reader["MinDT"].ToString()));
                maxDateTime = Convert.ToDouble((reader["MaxDT"].ToString()));
            }
            reader.Close();
            //logBox.AppendText(DateTime.FromOADate(minDateTime).ToString() + Environment.NewLine + DateTime.FromOADate(maxDateTime).ToString());
            //minDateTime = maxDateTime - 10.0 / (24.0 * 60.0);
            //maxDateTime = maxDateTime + 5.0 / (24.0 * 60.0);
            //transaction.Commit();

            myDB.DisconnectDB();

            DateTime parsedDateMin = DateTime.FromOADate(minDateTime);
            DateTime parsedDateMax = DateTime.FromOADate(maxDateTime);

            datePickerFrom.Value = parsedDateMin;
            datePickerTo.Value = parsedDateMax;
        }

        private void drawBtn_Click(object sender, EventArgs e)
        {
            leftDateTime = datePickerFrom.Value.ToOADate();
            rightDateTime = datePickerTo.Value.ToOADate();

            //установка глобальных переменных мастштаба
            MinDateTime = rightDateTime;
            MaxDateTime = leftDateTime;
            LaMin = laMax;
            LaMax = laMin;
            TempMin = tempMax;
            TempMax = tempMin;

            if (numberOfSensors == 0) return;

            int numberOfCheckedSensors = sensorsListCB.CheckedIndices.Count;
            int[] indexOfCheckedSensors = new int[numberOfCheckedSensors];
            int circleCount = 0;
            foreach (int indexChecked in sensorsListCB.CheckedIndices)
            {
                int index = 0;
                string currID = listID[indexChecked];
                bool isClassAlreadyExist = false;
                for (int i = 0; i < numberOfSensors; i++)
                {
                    if (IDOfSensor[i] == Convert.ToInt32(currID)) 
                    {
                        isClassAlreadyExist = true;
                        index = i;
                        Sensor CheckSensor = sensorsList[i];
                    }

                    if (isClassAlreadyExist) break;
                }

                if (isClassAlreadyExist)
                {
                    //statusLabel.Text = "Экземпляр класса уже создан";
                    indexOfCheckedSensors[circleCount] = index;
                }else
                {
                    Sensor CurrSensor = new Sensor();
                    CurrSensor.ID = Convert.ToInt32(currID);

                    int emptyIndex = -1;
                    for (int i = 0; i < numberOfSensors; i++)
                    {
                        if (IDOfSensor[i] == 0)
                        {
                            emptyIndex = i;
                            IDOfSensor[emptyIndex] = CurrSensor.ID;
                            indexOfCheckedSensors[circleCount] = emptyIndex;
                            break;
                        }
                    }
                    sensorsList.Add(CurrSensor);
                }
                circleCount += 1;
            }
            string dataTypeSQLQuery = "";
            string separator = ", ";

            if (LaCurCB.Checked)
            {
                dataTypeSQLQuery += "LaCur";
                dataTypeSQLQuery += separator;
            }

            if (LaCur0CB.Checked)
            {
                dataTypeSQLQuery += "LaCur0";
                dataTypeSQLQuery += separator;
            }
            if (LaCur1CB.Checked)
            {
                  dataTypeSQLQuery += "LaCur1";
                  dataTypeSQLQuery += separator;
            }
            if (LaCur2CB.Checked)
            {
                dataTypeSQLQuery += "LaCur2";
                dataTypeSQLQuery += separator;
            }
            if (LaCur3CB.Checked)
            {
                dataTypeSQLQuery += "LaCur3";
                dataTypeSQLQuery += separator;
            }
            if (LaCur4CB.Checked)
            {
                dataTypeSQLQuery += "LaCur4";
                dataTypeSQLQuery += separator;
            }
            if (LaShiftCB.Checked)
            {
                dataTypeSQLQuery += "LaShift";
                dataTypeSQLQuery += separator;
            }
            if (TempCB.Checked)
            {
                dataTypeSQLQuery += "Temperature";
            }
            else 
            {
                dataTypeSQLQuery = dataTypeSQLQuery.Remove(dataTypeSQLQuery.Length - 2);
            }

            string idSQLQuery = "";
            string logicSep = " OR "; 
            for (int i = 0; i <  numberOfCheckedSensors; i++ )
            {
                int currIndex = indexOfCheckedSensors[i];
                idSQLQuery += "ID = " + IDOfSensor[currIndex].ToString();
                idSQLQuery += logicSep;
            }

            idSQLQuery = idSQLQuery.Remove(idSQLQuery.Length - 4);

            Sensor[] sensorArray = new Sensor[numberOfCheckedSensors];
            for (int i = 0; i < numberOfCheckedSensors; i++) 
            {
                sensorArray[i] = sensorsList[indexOfCheckedSensors[i]];
            }

            bool isConnectionExist;
            isConnectionExist = myDB.ConnectDB();
            //statusLabel.Text = myDB.status;
            if (isConnectionExist == false) return;

            double currDateTime, currData;
            int currentID;

            string SQLQuery = "SELECT DateTimeDouble, ID, " + dataTypeSQLQuery + " FROM SensorsData WHERE " + idSQLQuery + " AND DateTimeDouble BETWEEN " + 
                leftDateTime.ToString() + " AND " + rightDateTime.ToString() + " ORDER BY RecordID;";
            logBox.AppendText(SQLQuery + '\n');
            SQLiteDataReader reader = null;
            myDB.ReadFromDB(SQLQuery, ref reader);
            //в список выбранного типа пишется дата и значение друг за другом
            while (reader.Read())
            {
                currDateTime = Convert.ToDouble((reader["DateTimeDouble"].ToString()));
                currentID = Convert.ToInt32(reader["ID"].ToString());
                int currIndx = 0;
                while (IDOfSensor[indexOfCheckedSensors[currIndx]] != currentID)
                {
                    currIndx += 1;
                }
                if (LaCurCB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaCur, currDateTime, ref sensorArray[currIndx].DateTimeMin, ref sensorArray[currIndx].DateTimeMax);
                    SetGlobalMinMax(sensorArray[currIndx].DateTimeMin, sensorArray[currIndx].DateTimeMax, ref MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["LaCur"].ToString());
                    SetData(sensorArray[currIndx].LaCur, currData, ref sensorArray[currIndx].LaCurMin, ref sensorArray[currIndx].LaCurMax);
                    SetGlobalMinMax(sensorArray[currIndx].LaCurMin, sensorArray[currIndx].LaCurMax, ref LaMin, ref LaMax);
                }

                if (LaCur0CB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaCur0, currDateTime, ref sensorArray[currIndx].DateTime0Min, ref sensorArray[currIndx].DateTime0Max);
                    SetGlobalMinMax(sensorArray[currIndx].DateTime0Min, sensorArray[currIndx].DateTime0Max, ref MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["LaCur0"].ToString());
                    SetData(sensorArray[currIndx].LaCur0, currData, ref sensorArray[currIndx].LaCur0Min, ref sensorArray[currIndx].LaCur0Max);
                    SetGlobalMinMax(sensorArray[currIndx].LaCur0Min, sensorArray[currIndx].LaCur0Max, ref LaMin, ref LaMax);
                }
                if (LaCur1CB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaCur1, currDateTime, ref sensorArray[currIndx].DateTime1Min, ref sensorArray[currIndx].DateTime1Max);
                    SetGlobalMinMax(sensorArray[currIndx].DateTime1Min, sensorArray[currIndx].DateTime1Max, ref MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["LaCur1"].ToString());
                    SetData(sensorArray[currIndx].LaCur1, currData, ref sensorArray[currIndx].LaCur1Min, ref sensorArray[currIndx].LaCur1Max);
                    SetGlobalMinMax(sensorArray[currIndx].LaCur1Min, sensorArray[currIndx].LaCur1Max, ref LaMin, ref LaMax);
                }
                if (LaCur2CB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaCur2, currDateTime, ref sensorArray[currIndx].DateTime2Min, ref sensorArray[currIndx].DateTime2Max);
                    SetGlobalMinMax(sensorArray[currIndx].DateTime2Min, sensorArray[currIndx].DateTime2Max, ref  MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["LaCur2"].ToString());
                    SetData(sensorArray[currIndx].LaCur2, currData, ref sensorArray[currIndx].LaCur2Min, ref sensorArray[currIndx].LaCur2Max);
                    SetGlobalMinMax(sensorArray[currIndx].LaCur2Min, sensorArray[currIndx].LaCur2Max, ref LaMin, ref LaMax);
                }
                if (LaCur3CB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaCur3, currDateTime, ref sensorArray[currIndx].DateTime3Min, ref sensorArray[currIndx].DateTime3Max);
                    SetGlobalMinMax(sensorArray[currIndx].DateTime3Min, sensorArray[currIndx].DateTime3Max, ref MinDateTime, ref  MaxDateTime);

                    currData = Convert.ToDouble(reader["LaCur3"].ToString());
                    SetData(sensorArray[currIndx].LaCur3, currData, ref sensorArray[currIndx].LaCur3Min, ref sensorArray[currIndx].LaCur3Max);
                    SetGlobalMinMax(sensorArray[currIndx].LaCur3Min, sensorArray[currIndx].LaCur3Max, ref LaMin, ref LaMax);
                }
                if (LaCur4CB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaCur4, currDateTime, ref sensorArray[currIndx].DateTime4Min, ref sensorArray[currIndx].DateTime4Max);
                    SetGlobalMinMax(sensorArray[currIndx].DateTime4Min, sensorArray[currIndx].DateTime4Max, ref MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["LaCur4"].ToString());
                    SetData(sensorArray[currIndx].LaCur4, currData, ref sensorArray[currIndx].LaCur4Min, ref sensorArray[currIndx].LaCur4Max);
                    SetGlobalMinMax(sensorArray[currIndx].LaCur4Min, sensorArray[currIndx].LaCur4Max, ref LaMin, ref LaMax);
                }
                if (LaShiftCB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].LaShift, currDateTime, ref sensorArray[currIndx].DateTimeShiftMin, ref sensorArray[currIndx].DateTimeShiftMax);
                    SetGlobalMinMax(sensorArray[currIndx].DateTimeShiftMin, sensorArray[currIndx].DateTimeShiftMax, ref MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["LaShift"].ToString());
                    SetData(sensorArray[currIndx].LaShift, currData, ref sensorArray[currIndx].LaShiftMin, ref sensorArray[currIndx].LaShiftMax);
                    SetGlobalMinMax(sensorArray[currIndx].LaShiftMin, sensorArray[currIndx].LaShiftMax, ref LaMin, ref LaMax);
                }
                if (TempCB.Checked)
                {
                    SetDateTime(sensorArray[currIndx].Temp, currDateTime, ref sensorArray[currIndx].DateTimeTempMin, ref sensorArray[currIndx].DateTimeTempMax);
                    SetGlobalMinMax(sensorArray[currIndx].DateTimeTempMin, sensorArray[currIndx].DateTimeTempMax, ref MinDateTime, ref MaxDateTime);

                    currData = Convert.ToDouble(reader["Temperature"].ToString());
                    SetData(sensorArray[currIndx].Temp, currData, ref sensorArray[currIndx].TempMin, ref sensorArray[currIndx].TempMax);
                    SetGlobalMinMax(sensorArray[currIndx].TempMin, sensorArray[currIndx].TempMax, ref LaMin, ref LaMax);
                }
            }
            reader.Close();

            //записать в лист ссылки на экземпляры из массива классов
            for (int i = 0; i < numberOfCheckedSensors; i++) 
            {
                for (int j = 0; j < sensorArray.Length; j++ )
                {
                    if (sensorsList[i].ID == sensorArray[j].ID) 
                    {
                        sensorsList[i] = sensorArray[j];
                        break;
                    }
                }
            }
            myDB.DisconnectDB();

            plotPicture();

            int inc = 0;
            while (inc < numberOfSensors)
            {
                if (IDOfSensor[inc] != 0) 
                {
                    Sensor NewSensor = new Sensor();
                    NewSensor.ID = IDOfSensor[inc];
                    sensorsList[inc] = NewSensor;
                } 
                inc += 1;
            }
        }

        private bool DbFilePathSearch() 
        {
            bool exit = false;
            if ((openFileDialog.ShowDialog() == DialogResult.OK) && (!string.IsNullOrEmpty(openFileDialog.FileName)))
            {
                myDB.myDBFileName = openFileDialog.FileName;
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "Пожалуйста, выберите файл базы данных",
                    "Ошибка",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Retry)
                {
                    currTry += 1;
                    if (currTry == maxTry) 
                    {
                        exit = true;
                        return exit;
                    } else
                        return DbFilePathSearch();
                }
                else
                {
                    exit = true;
                    return exit;
                }
            }
            return exit;
        }

        private void AddToListCB() 
        {
            bool isConnectionExist;
            isConnectionExist = myDB.ConnectDB();
            //statusLabel.Text = myDB.status;
            if (isConnectionExist == false) return;

            listID.Clear();
            numberOfSensors = 0;

            SQLiteDataReader reader = null;
            //SQLiteTransaction transaction = null;

            string sqlQuery = "SELECT DISTINCT ID FROM SensorsData;";
            myDB.ReadFromDB(sqlQuery, ref reader);
            while (reader.Read())
            {
                listID.Add(reader["ID"].ToString());
                numberOfSensors += 1;

            }
            reader.Close();
            //transaction.Commit();
            myDB.DisconnectDB();

            IDOfSensor = new int[numberOfSensors];

            sensorsListCB.Items.Clear();
            foreach (string ID in listID)
            {
                sensorsListCB.Items.Add(ID);
            }
        }

        private void SetDateTime(List<double> currList, double DateTime, ref double minDateTime, ref double maxDateTime)
        {
            ///
            /// currList - список, в которой запишется DateTime
            /// DateTime - значение даты и времени
            /// minDateTime - самая маленькая дата и время данного типа значений у датчика
            /// maxDateTime - самая большая дата и время данного типа значений у датчика
            ///

            currList.Add(DateTime);
            if (DateTime < minDateTime) minDateTime = DateTime;
            if (DateTime > maxDateTime) maxDateTime = DateTime;
        }

        private void SetData(List<double> currList, double currData, ref double minData, ref double maxData)
        {
            ///
            /// Записать текущее значение currData в список currList
            /// minData - минимальное значение типа данных у датчика
            /// maxData - максимальное значение типа данных у датчика
            /// 
            currList.Add(currData);
            if (currData < minData) minData = currData;
            if (currData > maxData) maxData = currData; 
        }

        private void SetGlobalMinMax(double dataMin, double dataMax, ref double currMin, ref double currMax) 
        {
            if (dataMin < currMin)
            {
                currMin = dataMin;
            }
            if (dataMax > currMax)
            {
                currMax = dataMax;
            }
        }

        private void plotPicture()
        {
            int GW = pictureBox.Width;
            int GH = pictureBox.Height;

            double xMin, xMax;

            xMin = MinDateTime;
            xMax = MaxDateTime;
            if (xMax == xMin)
            {
                xMin = xMin - 1.0 / (24.0 * 60.0);
                xMax = xMax + 1.0 / (24.0 * 60.0);
            }

            double yMin, yMax;
            yMin = LaMin;
            yMax = LaMax;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Random rnd = new Random();

            int xBar = 50;
            int yBar = 40;

            //int red, green, blue;
            //red = 0;
            //green = 0;
            //blue = 0;

            string drawString;
            Pen myPen = new Pen(Color.LightGray);
            Font drawFont = new Font("Arial", 8);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Graphics myG = pictureBox.CreateGraphics();
            BufferedGraphics BmyG = (new BufferedGraphicsContext()).Allocate(myG, new Rectangle(0, 0, GW, GH));
            BmyG.Graphics.Clear(Color.White);


            // Y-Axis
            double YT;
            double yDI = (yMax - yMin) / yBar;
            double yDIpm = yDI;
            for (int k = 0; k <= yBar; k++)
            {
                drawString = "";
                YT = yMin + k * yDI;
                drawString = YT.ToString("F5");
                M2 = (int)(GHB + (GH - GHB - GHT) * (YT - yMin) / (yMax - yMin));
                BmyG.Graphics.DrawString(drawString, drawFont, drawBrush, 0, GH - M2);
                BmyG.Graphics.DrawLine(myPen, GWBL, GH - M2, GW - GWBR, GH - M2);
            }
            //*****************************************************************************************************
            // X-Axis
            double XT;
            drawFont = new Font("Arial", 8);
            drawBrush = new SolidBrush(Color.Black);
            int tShift = 10;
            double xDI = (xMax - xMin) / xBar;

            StringFormat FormatVer = new StringFormat(StringFormatFlags.DirectionVertical);

            for (int k = 0; k <= xBar; k++)
            {
                drawString = "";
                XT = xMin + k * xDI;
                drawString = DateTime.FromOADate(XT).ToLongTimeString() + " " + DateTime.FromOADate(XT).ToShortDateString();
                tShift = drawString.Length * 6 / 2;
                tShift = 5;
                K1 = (int)(GWBL + (GW - GWBL - GWBR) * (XT - xMin) / (xMax - xMin));
                BmyG.Graphics.DrawString(drawString, drawFont, drawBrush, K1 - tShift, GH - GHB + 10, FormatVer);
                BmyG.Graphics.DrawLine(myPen, K1, GH - GHB, K1, GHT);
            }

                myG.Clear(Color.White);

            int KOT = 0;
            foreach (int indexChecked in sensorsListCB.CheckedIndices)
            {
                string currID = listID[indexChecked];
                int index = -1;
                Sensor currSensor = null;
                for (int i = 0; i < numberOfSensors; i++)
                {
                    if (IDOfSensor[i] == Convert.ToInt32(currID))
                    {
                        currSensor = sensorsList[i];
                        index = i;
                        break;
                    }
                }
                if (LaCurCB.Checked) 
                {
                    DrawData(ref currSensor.LaCur, currID, "LaCur", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (LaCur0CB.Checked)
                {
                    DrawData(ref currSensor.LaCur0, currID, "LaCur0", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (LaCur1CB.Checked)
                {
                    DrawData(ref currSensor.LaCur1, currID, "LaCur1", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (LaCur2CB.Checked)
                {
                    DrawData(ref currSensor.LaCur2, currID, "LaCur2", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (LaCur3CB.Checked)
                {
                    DrawData(ref currSensor.LaCur3, currID, "LaCur3", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (LaCur4CB.Checked)
                {
                    DrawData(ref currSensor.LaCur4, currID, "LaCur4", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (LaShiftCB.Checked)
                {
                    DrawData(ref currSensor.LaShift, currID, "LaShift", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                if (TempCB.Checked)
                {
                    DrawData(ref currSensor.Temp, currID, "Temperature", KOT, GH, GW, ref BmyG, xMin, xMax, yMin, yMax);
                }
                KOT += 1;
            }
            BmyG.Render(myG);
        }

        private void DrawData(ref List<double> dataList, string ID, string dataName, int indexOfColor, int GH, int GW, ref BufferedGraphics BmyG, double xMin, double xMax, double yMin, double yMax) 
        {
            Pen newPen = new Pen(myGroupColors[indexOfColor], 1);
            Brush drawBrush = new SolidBrush(myGroupColors[indexOfColor]);

            if (dataList.Count <= 0)
            {
            //    richTextBox1.AppendText("Пустой набор данных  = " + currSensor.ID.ToString() + Environment.NewLine);
                return;
            }
           
            else
            {
                //double CurrData;
                // STLLASER_CUR
                //red = rnd.Next(0, 255);
                //blue = rnd.Next(0, 255);
                //green = rnd.Next(0, 233);
                

                int K1 = (int)(GWBL + (GW - GWBL - GWBR) * (xMin - xMin) / (xMax - xMin));
                int M1 = (int)(GHB + (GH - GHB - GHT) * (dataList[1] - yMin) / (yMax - yMin));

                int inc = 0;
                double currDateTime = 0;
                foreach (double data in dataList)
                {
                    if (inc % 2 == 0)
                    {
                        currDateTime = data;
                        inc += 1;
                        continue;
                    }
                    double currData = data;
                    K2 = (int)(GWBL + (GW - GWBL - GWBR) * (currDateTime - xMin) / (xMax - xMin));
                    M2 = (int)(GHB + (GH - GHB - GHT) * (currData - yMin) / (yMax - yMin));
                    BmyG.Graphics.DrawLine(newPen, K1, GH - M1, K2, GH - M2);
                    K1 = K2;
                    M1 = M2;
                    inc += 1;

                }
                Font drawFont = new Font("Arial", 10);
                drawBrush = new SolidBrush(myGroupColors[indexOfColor]);
                string drawString = "Датчик " + ID + " " + dataName;
                int xString = Convert.ToInt32(Math.Abs(K1 - GWBR * 10));
                int yString = GH - M1 - 10;
                BmyG.Graphics.DrawString(drawString, drawFont, drawBrush, xString, yString);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) timer1.Enabled = true;
            if (!checkBox1.Checked) timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawBtn_Click(null, null);
        }
    }
}

/// MyClass[] MyClassVariable = new MyClass[10];
/// for(int i = 0; i < 10; i++)
/// {
/// MyClassVariable[i] = new MyClass(i, "Вася");
/// }