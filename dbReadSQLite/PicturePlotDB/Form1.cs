using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.IO;


namespace PicturePlotDB
{
    public partial class Form1 : Form
    {
        CultureInfo myCulInf = new CultureInfo("es-ES", false);
        NumberStyles nStyle = NumberStyles.AllowDecimalPoint;
        OpenFileDialog openFileDialog = new OpenFileDialog();

        SQLiteDB myDB = new SQLiteDB();
        List<string> listID = new List<string>();
        string dataType = String.Empty;
        int numberOfSensors;
        int[] indexOfSensor;
        double leftDateTime, rightDateTime;
        double minDateTime, maxDateTime;
        double laMin;
        double laMax;

        const string curr_A_12 = "1207";
        const string curr_B_12 = "1208";
        const string curr_C_12 = "1209";

        const string curr_A_26 = "2607";
        const string curr_B_26 = "2608";
        const string curr_C_26 = "2609";

        private class Sensor
        {
            public const double laMin = 0;
            public const double laMax = 2000;

            public int ID;
            public int GroupID;

            public bool LaCur_Status = false;
            public bool LaCur0_Status = false;
            public bool LaCur1_Status = false;
            public bool LaCur2_Status = false;
            public bool LaCur3_Status = false;
            public bool LaCur4_Status = false;
            public bool LaShift_Status = false;

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

            public List<double> DateTime = new List<double>();
            public double DateTimeMin;
            public double DateTimeMax;
            public List<double> LaCur = new List<double>();
            public double LaCurMin = laMax;
            public double LaCurMax = laMin;

            public List<double> DateTime0 = new List<double>();
            public double DateTime0Min;
            public double DateTime0Max;
            public List<double> LaCur0 = new List<double>();
            public double LaCur0Min = laMax;
            public double LaCur0Max = laMin;

            public List<double> DateTime1 = new List<double>();
            public double DateTime1Min;
            public double DateTime1Max;
            public List<double> LaCur1 = new List<double>();
            public double LaCur1Min = laMax;
            public double LaCur1Max = laMin;

            public List<double> DateTime2 = new List<double>();
            public double DateTime2Min;
            public double DateTime2Max;
            public List<double> LaCur2 = new List<double>();
            public double LaCur2Min = laMax;
            public double LaCur2Max = laMin;

            public List<double> DateTime3 = new List<double>();
            public double DateTime3Min;
            public double DateTime3Max;
            public List<double> LaCur3 = new List<double>();
            public double LaCur3Min = laMax;
            public double LaCur3Max = laMin;

            public List<double> DateTime4 = new List<double>();
            public double DateTime4Min;
            public double DateTime4Max;
            public List<double> LaCur4 = new List<double>();
            public double LaCur4Min = laMax;
            public double LaCur4Max = laMin;

            public List<double> DateTimeShift = new List<double>();
            public double DateTimeShiftMin;
            public double DateTimeShiftMax;
            public List<double> LaShift = new List<double>();
            public double LaCurShiftMin = laMax;
            public double LaCurShiftMax = laMin;


            public List<double> DateTimeTemp = new List<double>();
            public double DateTimeTempMin;
            public double DateTimeTemptMax;
            public List<double> sensorTemp = new List<double>();
            public double sensorTempMin = laMax;
            public double sensorTempMax = laMin-laMax;
        }

        //MyClass[] MyClassVariable = new MyClass[10];
        List<Sensor> sensorsList = new List<Sensor>();


        public Form1()
        {
            InitializeComponent();
        }

        byte maxTry = 5;
        byte currTry = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void drawBtn_Click(object sender, EventArgs e)
        {
            bool isConnectionExist;
            isConnectionExist = myDB.ConnectDB();
            statusLabel.Text = myDB.status;
            if (isConnectionExist == false) return;

            leftDateTime = datePickerFrom.Value.ToOADate();
            rightDateTime = datePickerTo.Value.ToOADate();

            minDateTime = rightDateTime;
            maxDateTime = leftDateTime;

            laMin = 2000;
            laMax = 0;

            //richTextBox1.AppendText(datePickerFrom.Value.ToShortDateString() + Environment.NewLine);
            //richTextBox1.AppendText(timePickerFrom.Value.ToLongTimeString() + Environment.NewLine);

            //richTextBox1.AppendText(datePickerTo.Value.ToShortDateString() + Environment.NewLine);
            //richTextBox1.AppendText(timePickerTo.Value.ToLongTimeString() + Environment.NewLine);

            if (numberOfSensors == 0) return;
            foreach (int indexChecked in sensorsListCB.CheckedIndices)
            {
                int index = 0;
                string currID = listID[indexChecked];
                bool isDataTypeAlreadyRead = false;
                bool isClassAlreadyExist = false;
                for (int i = 0; i < numberOfSensors; i++)
                {
                    if (indexOfSensor[i] == Convert.ToInt32(currID)) 
                    {
                        isClassAlreadyExist = true;
                        index = i;
                        Sensor CheckSensor = sensorsList[i];
                        switch (dataType)
                        {
                            case "LaCur":
                                if (CheckSensor.LaCur_Status == true) isDataTypeAlreadyRead = true; 
                                break;
                            case "LaCur0":
                                if (CheckSensor.LaCur0_Status == true) isDataTypeAlreadyRead = true;
                                break;
                        }
                    }

                    if ((isDataTypeAlreadyRead == true)||(isClassAlreadyExist)) break;
                }

                if (isDataTypeAlreadyRead) 
                {
                    statusLabel.Text = "Экземпляр класса уже создан";
                    continue;
                }

                if (isClassAlreadyExist == false)
                {
                    Sensor CurrSensor = new Sensor();
                    CurrSensor.ID = Convert.ToInt32(currID);

                    int emptyIndex = -1;
                    for (int i = 0; i < numberOfSensors; i++)
                    {
                        if (indexOfSensor[i] == 0)
                        {
                            emptyIndex = i;
                            indexOfSensor[emptyIndex] = CurrSensor.ID;
                            break;
                        }
                    }
                    AddDataToSensorClass(currID, ref CurrSensor);
                    sensorsList.Add(CurrSensor);
                }
                else 
                {
                    Sensor CurrSensor = sensorsList[index];
                    AddDataToSensorClass(currID, ref CurrSensor);
                }
            }
            myDB.DisconnectDB();

            plotPicture();

            int inc = 0;
            while ( inc < numberOfSensors)
            {
                if (indexOfSensor[inc] != 0) 
                {
                    Sensor NewSensor = new Sensor();
                    NewSensor.ID = indexOfSensor[inc];
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
            statusLabel.Text = myDB.status;
            if (isConnectionExist == false) return;

            listID.Clear();
            numberOfSensors = 0;

            SQLiteDataReader reader = null;
            SQLiteTransaction transaction = null;

            string sqlQuery = "SELECT DISTINCT ID FROM SensorsData;";
            myDB.ReadFromDB(sqlQuery, ref reader, ref transaction);
            if (reader == null) 
            {
                myDB.DisconnectDB();
                transaction.Commit();
                return;
            }
            while (reader.Read())
            {
                //var task = new Task();
                //task.Id = (int)reader["id"]; // the name of the column in the reader will match the column in the Tasks table.
                //task.Name = (string)reader["name"];
                //task.Key = (string)reader["key"];

                //tasks.Add(task);
                listID.Add(reader["ID"].ToString());
                numberOfSensors += 1;

            }
            reader.Close();
            transaction.Commit();
            myDB.DisconnectDB();

            indexOfSensor = new int[numberOfSensors];

            sensorsListCB.Items.Clear();
            foreach (string ID in listID)
            {
                sensorsListCB.Items.Add(ID);
            }
        }

        private void LaCurRB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaCur";
            }        
        }

        private void LaCur0RB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaCur0";
            }        
        }

        private void LaCur1RB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaCur1";
            }        
        }

        private void LaCurShiftRB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaShift";
            }        
        }

        private void LaCur2RB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaCur2";
            }        
        }

        private void LaCur3RB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaCur3";
            }        
        }

        private void LaCur4RB_CheckedChanged(object sender, EventArgs e)
        {
            // приводим отправителя к элементу типа RadioButton
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                //MessageBox.Show("Вы выбрали " + radioButton.Text);
                dataType = "LaCur4";
            }        
        }

        private void AddDataToSensorClass(string currentID, ref Sensor CurrentSensor)
        {
            double currLa;
            double currTime;
            string separator, Query;
            SQLiteDataReader Reader = null;
            SQLiteTransaction Transaction = null;

            switch (dataType)
            {
                case "LaCur":
                    separator = ", ";
                    Query = "SELECT " + "DateTimeDouble" + separator + dataType +
                        " FROM SensorsData WHERE ID = " + currentID + " AND DateTimeDouble BETWEEN " + leftDateTime +
                        " AND " + rightDateTime + " ORDER BY RecordID" + ";";
                    myDB.ReadFromDB(Query, ref Reader, ref Transaction);
                    richTextBox1.AppendText(Query + Environment.NewLine);
                    CurrentSensor.DateTimeMin = rightDateTime;
                    CurrentSensor.DateTimeMax = leftDateTime;

                    while (Reader.Read())
                    {
                        currTime = Convert.ToDouble(Reader["DateTimeDouble"].ToString());
                        try
                        {
                            CurrentSensor.DateTime.Add(currTime);
                            if (currTime< CurrentSensor.DateTimeMin) 
                            {
                                CurrentSensor.DateTimeMin = currTime;
                            }
                            if (currTime > CurrentSensor.DateTimeMax) 
                            {
                                CurrentSensor.DateTimeMax = currTime;
                            }
                        }
                        catch { }

                        currLa = Convert.ToDouble(Reader[dataType].ToString());
                        CurrentSensor.LaCur.Add(currLa);

                        if (currLa < CurrentSensor.LaCurMin) 
                        {
                            CurrentSensor.LaCurMin = currLa;
                        }
                        if (currLa > CurrentSensor.LaCurMax) 
                        {
                            CurrentSensor.LaCurMax = currLa;
                        }
                    }
                    CurrentSensor.LaCur_Status = true;
                    Transaction.Commit();
                    Reader.Close();
                    if (CurrentSensor.DateTimeMin < minDateTime)
                    {
                        minDateTime = CurrentSensor.DateTimeMin;
                    }
                    if (CurrentSensor.DateTimeMax > maxDateTime)
                    {
                        maxDateTime = CurrentSensor.DateTimeMax;
                    }
                    if (CurrentSensor.LaCurMin < laMin) 
                    {
                        laMin = CurrentSensor.LaCurMin;
                    }
                    if (CurrentSensor.LaCurMax > laMax)
                    {
                        laMax = CurrentSensor.LaCurMax;
                    }
                    break;
                case "LaCur0":
                    SelectData(dataType, currentID, ref CurrentSensor.DateTime0, ref CurrentSensor.DateTime0Min, ref CurrentSensor.DateTime0Max, 
                        ref CurrentSensor.LaCur0, ref CurrentSensor.LaCur0Min, ref CurrentSensor.LaCur0Max, ref CurrentSensor.LaCur0_Status); 
                    break;
                case "LaShift":
                    SelectData(dataType, currentID, ref CurrentSensor.DateTimeShift, ref CurrentSensor.DateTimeShiftMin, ref CurrentSensor.DateTimeShiftMax,
                        ref CurrentSensor.LaShift, ref CurrentSensor.LaCurShiftMin, ref CurrentSensor.LaCurShiftMax, ref CurrentSensor.LaCur0_Status);
                    break;

            }
        }

        private void plotPicture() 
        {
            double xMin, xMax;
            Color[] myGroupColors = new Color[100];
            myGroupColors[0] = Color.Black;
            myGroupColors[1] = Color.Red;
            myGroupColors[2] = Color.Green;
            myGroupColors[3] = Color.Blue;
            myGroupColors[4] = Color.Violet;
            myGroupColors[5] = Color.Red;
            myGroupColors[6] = Color.Green;
            myGroupColors[7] = Color.Blue;
            myGroupColors[8] = Color.Violet;

            //должен быть switch(dateType)
            //добавить нахождение максимального и минимального значений длины волны и времен из полей классов
            xMin =leftDateTime;
            xMax = rightDateTime;
            if (xMax == xMin) 
            {
                xMin = xMin - 1.0 / (24.0 * 60.0);
                xMax = xMax + 1.0 / (24.0 * 60.0);
            }

            double yMin, yMax;
            //должен быть switch(dateType)
            yMin = laMin;
            yMax = laMax;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //Random rnd = new Random();

            int GW = pictureBox.Width;
            int GH = pictureBox.Height;
            int GWBL = 60;
            int GWBR = 10;
            int GHB = 100;
            int GHT = 30;
            int K1, K2, M1, M2;
            int xBar = 25; 
            int yBar = 50;

            int red, green, blue;
            red = 0;
            green = 0;
            blue = 0;

            string drawString;
            Pen myPen = new Pen(Color.LightGray);
            Font drawFont = new Font("Arial", 7);
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
            drawFont = new Font("Arial", 7);
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

            try
            {
                myG.Clear(Color.White);
            }
            catch (Exception E)
            {
                //LogWrite(10, E.Message);
            }
            int KOT = 0;
            foreach (int indexChecked in sensorsListCB.CheckedIndices)
            {                
                string currID = listID[indexChecked];
                int index = -1;
                Sensor currSensor = null;
                KOT = KOT + 1;
                for (int i = 0; i < numberOfSensors; i++) 
                {
                    if (indexOfSensor[i] == Convert.ToInt32(currID)) 
                    {
                        currSensor = sensorsList[i];
                        index = i;
                        break;
                    } 
                }

                if (currSensor.LaCur.Count <= 0)
                {
                    richTextBox1.AppendText("Пустой набор данных для (" + indexChecked.ToString() + ") = " + currID + Environment.NewLine);
                }
                else
                {
                    // STLLASER_CUR
                    //red = rnd.Next(0, 255);
                    //blue = rnd.Next(0, 255);
                    //green = rnd.Next(0, 233);                    
                    myPen = new Pen(myGroupColors[KOT], 1);

                    K1 = (int)(GWBL + (GW - GWBL - GWBR) * (xMin - xMin) / (xMax - xMin));
                    M1 = (int)(GHB + (GH - GHB - GHT) * (currSensor.LaCur[0] - yMin) / (yMax - yMin));

                    int inc = 0;
                    //должен быть switch(dateType)
                    foreach (double data in currSensor.LaCur)
                    {
                        double currDateTime = currSensor.DateTime[inc];//НАДО ОПТИМИЗИРОВАТЬ
                        //if ((currDateTime > currSensor.DateTimeMin) && (currDateTime < currSensor.DateTimeMax))
                        //{
                        //    K2 = (int)(GWBL + (GW - GWBL - GWBR) * (currDateTime - xMin) / (xMax - xMin));
                        //    M2 = (int)(GHB + (GH - 2 * GHB) * (data - yMin) / (yMax - yMin));
                        //    BmyG.Graphics.DrawLine(myPen, K1, GH - M1, K2, GH - M2);
                        //    K1 = K2;
                        //    M1 = M2;
                        //}

                        K2 = (int)(GWBL + (GW - GWBL - GWBR) * (currDateTime - xMin) / (xMax - xMin));
                        M2 = (int)(GHB + (GH - GHB - GHT) * (data - yMin) / (yMax - yMin));
                        BmyG.Graphics.DrawLine(myPen, K1, GH - M1, K2, GH - M2);
                        K1 = K2;
                        M1 = M2;

                        inc += 1;
                    }
                    drawFont = new Font("Arial", 12);
                    drawBrush = new SolidBrush(myGroupColors[KOT]);
                    //добавить легенду графика!!!!!!!!!!
                    drawString = "Датчик " + currSensor.ID.ToString();
                    //BmyG.Graphics.DrawString(drawString, drawFont, drawBrush, GWBL, 20 * Math.Abs(sensorsListCB.CheckedIndices.Count - indexChecked));
                    BmyG.Graphics.DrawString(drawString, drawFont, drawBrush, K1, GH - M1);


                }
            }

            BmyG.Render(myG);
            
 
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

        private void SelectData(string dataType, string  currentID, ref List <double> dtCurr, ref double dtMinSens, ref double dtMaxSens, ref List <double> laCurr, ref double laMinSens, ref double laMaxSens, ref bool status) 
        {
            //CurrentSensor.DateTime0Min = dateTimeMin
            //CurrentSensor.DateTime0Max = dateTimeMax
            //CurrentSensor.LaCur = laCurr
            //CurrentSensor.LaCurShiftMin = laMin
            //CurrentSensor.LaCurShiftMax = laMax
            //CurrentSensor.LaShift_Status = status

            double currLa;
            double currTime;
            string separator, Query;
            SQLiteDataReader Reader = null;
            SQLiteTransaction Transaction = null;

            leftDateTime = datePickerFrom.Value.ToOADate();
            rightDateTime = datePickerTo.Value.ToOADate();

            separator = ", ";
            Query = "SELECT " + "DateTimeDouble" + separator + dataType +
                " FROM SensorsData WHERE ID = " + currentID + " AND DateTimeDouble BETWEEN " + leftDateTime +
                " AND " + rightDateTime + " ORDER BY RecordID" + ";";
            myDB.ReadFromDB(Query, ref Reader, ref Transaction);
            richTextBox1.AppendText(Query + Environment.NewLine);
            dtMinSens = rightDateTime;
            dtMaxSens = leftDateTime;
            if (Reader == null)
            {
                richTextBox1.AppendText("Не задана ссылка на объект reader");
                myDB.DisconnectDB();
                Transaction.Commit();
                return;
            } 
            
            while (Reader.Read())
            {
                Convert.ToDouble(Reader["DateTimeDouble"].ToString());
                try
                {
                    currTime = Convert.ToDouble(Reader["DateTimeDouble"].ToString());
                    dtCurr.Add(currTime);
                    if (currTime < dtMinSens)
                    {
                        dtMinSens = currTime;
                    }
                    if (currTime > dtMaxSens)
                    {
                        dtMaxSens = currTime;
                    }
                }
                catch { }

                currLa = Convert.ToDouble(Reader[dataType].ToString());
                laCurr.Add(currLa);

                if (currLa < laMinSens)
                {
                    laMinSens = currLa;
                }
                if (currLa > laMax)
                {
                    laMaxSens = currLa;
                }
            }
            status = true;
            Transaction.Commit();
            Reader.Close();
            if (dtMinSens < minDateTime)
            {
                minDateTime = dtMinSens;
            }
            if (dtMaxSens > maxDateTime)
            {
                maxDateTime = dtMaxSens;
            }
            if (laMinSens < laMin)
            {
                laMin = laMinSens;
            }
            if (laMaxSens > laMax)
            {
                laMax = laMaxSens;
            }
        }

        private void SelectData(string dataType, double leftDateTime, double rightDateTime, string currentID, ref List<double> dataList) 
        {
            double currData;
            string Query;
            SQLiteDataReader Reader = null;
            SQLiteTransaction Transaction = null;

            string separator = ", ";
            Query = "SELECT " + dataType +
                " FROM SensorsData WHERE ID = " + currentID + " AND DateTimeDouble BETWEEN " + leftDateTime +
                " AND " + rightDateTime + " ORDER BY RecordID" + ";";
            myDB.ReadFromDB(Query, ref Reader, ref Transaction);
            richTextBox1.AppendText(Query + Environment.NewLine);
            //dtMinSens = rightDateTime;
            //dtMaxSens = leftDateTime;
            if (Reader == null) 
            {
                richTextBox1.AppendText("Не задана ссылка на объект reader");
                myDB.DisconnectDB();
                Transaction.Commit();
                return;
            } 
            while (Reader.Read())
            {
                //Convert.ToDouble(Reader["DateTimeDouble"].ToString());
                try
                {
                    //currTime = Convert.ToDouble(Reader["DateTimeDouble"].ToString());
                    //dtCurr.Add(currTime);
                    //if (currTime < dtMinSens)
                    //{
                    //    dtMinSens = currTime;
                    //}
                    //if (currTime > dtMaxSens)
                    //{
                    //    dtMaxSens = currTime;
                    //}
                }
                catch { }

                currData = Convert.ToDouble(Reader[dataType].ToString());
                dataList.Add(currData);

                //if (currLa < laMinSens)
                //{
                //    laMinSens = currLa;
                //}
                //if (currLa > laMax)
                //{
                //    laMaxSens = currLa;
                //}
            }
            //status = true;
            Transaction.Commit();
            Reader.Close();
            //if (dtMinSens < minDateTime)
            //{
            //    minDateTime = dtMinSens;
            //}
            //if (dtMaxSens > maxDateTime)
            //{
            //    maxDateTime = dtMaxSens;
            //}
            //if (laMinSens < laMin)
            //{
            //    laMin = laMinSens;
            //}
            //if (laMaxSens > laMax)
            //{
            //    laMax = laMaxSens;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string currentDataSetPath = @"C:\Install\data anylize\Data_2020.10.30-2020.12.14";

            firstOpenDB_button_Click(null, null);

            bool isConnectionExist;
            isConnectionExist = myDB.ConnectDB();
            statusLabel.Text = myDB.status;
            if (isConnectionExist == false) return;

            List<double> AC_curr_12 = new List<double>();
            List<double> AC_curr_26 = new List<double>();

            for (int i = 1; i <= 1; i++)
            {
                switch (i)
                {
                    case 1:
                        dataType = "LaCur0";
                        break;
                    case 2:
                        dataType = "LaCur1";
                        break;
                    case 3:
                        dataType = "LaCur2";
                        break;
                    case 4:
                        dataType = "LaCur3";
                        break;
                    case 5:
                        dataType = "LaCur4";
                        break;
                    default:
                        break;
                }

                string[] dataSetFiles = Directory.GetFiles(currentDataSetPath);

                foreach (string filePath in dataSetFiles)
                {
                    int length = 0;
                    bool flag = false;
                    string[] fileType = filePath.Split('.');
                    for (int k = 0; (k < fileType.Length) && (flag == false); i++) 
                    {
                        if (fileType[i] == "csv")
                        {
                            flag = true;
                        }
                        else 
                        {
                            length = length + fileType[i].Length;
                        }
                    }
                    if (flag == false) continue;

                    string fileName = filePath.Substring(length);
                    int index = fileName.IndexOf('(');
                    fileName = fileName.Substring(index);
                    string[] temp = fileName.Split('_');
                    fileName = temp[1];

                    string[] yymmdd = fileName.Split('-');

                    DateTime currentDT = new DateTime(Convert.ToInt32(yymmdd[0]), Convert.ToInt32(yymmdd[1]), Convert.ToInt32(yymmdd[2]));



                    foreach (string ID in listID)
                    {
                        Sensor CurrSensor = new Sensor();
                        CurrSensor.ID = Convert.ToInt32(ID);

                        AC_curr_12.Clear();
                        AC_curr_26.Clear();

                        SelectData(dataType, ID, ref CurrSensor.DateTime, ref CurrSensor.DateTimeMin, ref CurrSensor.DateTimeMax,
                            ref CurrSensor.LaCur, ref CurrSensor.LaCurMin, ref CurrSensor.LaCurMax, ref CurrSensor.LaCur_Status);
                        SelectData("Temperature", leftDateTime, rightDateTime, ID, ref CurrSensor.sensorTemp);
                    }
                }

            }
        }

        private void ReadCSVFile(string directory) 
        {
            openFileDialog.InitialDirectory = @"C:\\";
            openFileDialog.Filter = "Data base files (*.db)|*.db| SQLite files (*.sqlite)|*.sqlite| All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            if (DbFilePathSearch()) Environment.Exit(0);

            bool isConnectionExist;
            isConnectionExist = myDB.ConnectDB();
            statusLabel.Text = myDB.status;
            if (isConnectionExist == false) return;

            string[] filePath = Directory.GetFiles(directory);
            string tableName = "Current";
            int queryMax = 100;
            string columnsName = "('DateTimeString', 'OADate', 'CellNumber', 'CurrA', 'CurrB', 'CurrC')";
            string[] sqlQuery = new string[queryMax];
            int index = 0;

            double[] currABC = new double[3];
            DateTime[] dtABC = new DateTime[3];

            foreach (string path in filePath) 
            {
                string[] fileType = path.Split('.');
                if (fileType[1] != "csv") continue;

                string reString = String.Empty;
                FileStream fs;
                if (!File.Exists(path))
                {
                    richTextBox1.AppendText("Не смог найти CSV-файл " + path);
                    return;
                }

                fs = File.Open(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                bool flag = false;
                bool exitFromReading = false;
                while (!sr.EndOfStream && !flag)
                {
                    reString = sr.ReadLine();
                    if (reString.Length > 0)
                    {
                        string[] parts = reString.Split(';');

                        string[] dateTime = parts[0].Split(' ');
                        string address = parts[1];
                        string current = parts[2];

                        string[] yymmdd = dateTime[0].Split('-');
                        string[] hhmmss = dateTime[1].Split(':');

                        DateTime dt = new DateTime(Convert.ToInt32(yymmdd[0]), Convert.ToInt32(yymmdd[1]),
                                                   Convert.ToInt32(yymmdd[2]), Convert.ToInt32(hhmmss[0]),
                                                   Convert.ToInt32(hhmmss[1]), Convert.ToInt32(hhmmss[2]));

                        if ((address == curr_A_12) || (address == curr_A_26))
                        {
                            Double.TryParse(current, nStyle, myCulInf, out currABC[0]);
                            dtABC[0] = dt;

                            for (int i = 1; i <= 2; i++)
                            {   
                                reString = sr.ReadLine();
                                parts = reString.Split(';');

                                //dateTime = parts[0].Split(' ');
                                //yymmdd = dateTime[0].Split('-');
                                //hhmmss = dateTime[1].Split(':');

                                string B_C_address = parts[1];

                                if (address == curr_A_12) 
                                {
                                    if ((B_C_address != curr_B_12) && (B_C_address != curr_C_12)) 
                                    {
                                        exitFromReading = true;
                                    }
                                }
                                else if ((B_C_address != curr_B_26) && (B_C_address != curr_C_26))
                                {
                                    exitFromReading = true;
                                }
                                if (exitFromReading) 
                                {
                                    break;
                                }
                                Double.TryParse(parts[2], nStyle, myCulInf, out currABC[i]);
                                //dtABC[i] = new DateTime(Convert.ToInt32(yymmdd[0]), Convert.ToInt32(yymmdd[1]),
                                //                   Convert.ToInt32(yymmdd[2]), Convert.ToInt32(hhmmss[0]),
                                //                   Convert.ToInt32(hhmmss[1]), Convert.ToInt32(hhmmss[2]));

                            }
                            if (exitFromReading) 
                            {
                                exitFromReading = false;
                                continue;
                            }

                            string cellNumber;
                            if (address == curr_A_12)
                            {
                                cellNumber = "12";
                            }
                            else cellNumber = "26";

                            string separator = ", ";

                            for (int i = 0; i < 1; i++)
                            {
                                //string DateTimeString = "'" + dtABC[i].Year.ToString() + "." + dtABC[i].Month.ToString() + "." + dtABC[i].Day.ToString() + " " +
                                //    dtABC[i].Hour.ToString() + ":" + dtABC[i].Minute.ToString() + ":" + dtABC[i].Second.ToString() + "'";

                                string DateTimeString = "'" + dtABC[i].ToShortDateString() + " " + dtABC[i].ToLongTimeString() + "'";
                                string OADate = dtABC[i].ToOADate().ToString();

                                string values = "(" + DateTimeString + separator + OADate + separator + cellNumber + separator +
                                    currABC[0] + separator + currABC[1] + separator + currABC[2] + ");";
                                

                                sqlQuery[index] = values;
                                index++;
                            }
                            if (index == queryMax) 
                            {
                                SQLiteTransaction myTransaction = myDB.myDBConnection.BeginTransaction();
                                for (int i = 0; i < queryMax; i++) 
                                {
                                    int status = myDB.AddRecord(tableName, columnsName, sqlQuery[i]);
                                    if (status == 1) 
                                    {
                                        DialogResult result = MessageBox.Show(
                                            myDB.status,
                                            "Ошибка при записи в базу",
                                            MessageBoxButtons.RetryCancel,
                                            MessageBoxIcon.Exclamation,
                                            MessageBoxDefaultButton.Button1,
                                            MessageBoxOptions.DefaultDesktopOnly);
                                    }
                                }
                                myTransaction.Commit();

                                index = 0;
                            }
                        }


                    }
                }

                if (index < queryMax) 
                {
                    SQLiteTransaction myTransaction = myDB.myDBConnection.BeginTransaction();
                    for (int i = 0; i < index; i++)
                    {
                        int status = myDB.AddRecord(tableName, columnsName, sqlQuery[i]);
                        if (status == 1)
                        {
                            DialogResult result = MessageBox.Show(
                                myDB.status,
                                "Ошибка при записи в базу",
                                MessageBoxButtons.RetryCancel,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                    myTransaction.Commit();
                }

                sr.Close();
                fs.Close(); 
            }
            myDB.DisconnectDB();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReadCSVFile(@"H:\Обработка данных\Data 24-12 30-12");
        }

        private void firstOpenDB_button_Click(object sender, EventArgs e)
        {
            openFileDialog.InitialDirectory = @"C:\\";
            openFileDialog.Filter = "Data base files (*.db)|*.db| SQLite files (*.sqlite)|*.sqlite| All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = false;

            if (DbFilePathSearch()) return;

            AddToListCB();

            if (LaCurRB.Checked) dataType = "LaCur";
            else if (LaCur0RB.Checked) dataType = "LaCur0";
            else if (LaCur1RB.Checked) dataType = "LaCur1";
            else if (LaCur2RB.Checked) dataType = "LaCur2";
            else if (LaCur3RB.Checked) dataType = "LaCur3";
            else if (LaCur4RB.Checked) dataType = "LaCur4";
            else if (LaCurShiftRB.Checked) dataType = "LaShift";
            else dataType = "LaCur";

            SQLiteDataReader reader = null;
            SQLiteTransaction transaction = null;
            double minDateTime = 0, maxDateTime = 0;

            myDB.ConnectDB();
            myDB.ReadFromDB("SELECT min(DateTimeDouble) as MinDT, max(DateTimeDouble) as MaxDT FROM SensorsData;", ref reader, ref transaction);
            if (reader == null)
            {
                richTextBox1.AppendText("Не задана ссылка на объект reader");
                myDB.DisconnectDB();
                transaction.Commit();
                return;
            }
            while (reader.Read())
            {
                minDateTime = Convert.ToDouble((reader["MinDT"].ToString()));
                maxDateTime = Convert.ToDouble((reader["MaxDT"].ToString()));
                //minDateTime = maxDateTime - 10.0 / (24.0 * 60.0);
                //maxDateTime = maxDateTime + 5.0 / (24.0 * 60.0);
            }
            reader.Close();
            transaction.Commit();

            myDB.DisconnectDB();

            DateTime parsedDateMin = DateTime.FromOADate(minDateTime);
            DateTime parsedDateMax = DateTime.FromOADate(maxDateTime);
            datePickerFrom.Value = parsedDateMin;
            datePickerTo.Value = parsedDateMax;
        }
    }
}

/// MyClass[] MyClassVariable = new MyClass[10];
/// for(int i = 0; i < 10; i++)
/// {
/// MyClassVariable[i] = new MyClass(i, "Вася");
/// }
