using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstProgram
{
    public static class BitOperations
    {
        public struct SensorData
        {
            public ushort codeSensor;
            public ushort valueSensor;
            public ushort isСorrupted;
            public SensorData(ushort code, ushort val, ushort corrupt)
            {
                codeSensor = code;
                valueSensor = val;
                isСorrupted = corrupt;
            }
        }
        private static ushort[] GetSensors()
        {
            ushort[] dataSensors = { 0x28DB, 0x423A, 0x6A92, 0x28AF, 0x42FA, 0x28FF, 0x6AFB, 0x42CD };
            return dataSensors;
        }
        private static SensorData[] GetParse(ushort[] dataSensors)
        {
            SensorData[] resultParse = new SensorData[dataSensors.Length];
            uint firstMask = 0x1;
            uint secondMask = 0x1FFE;
            for (int i = 0; i < dataSensors.Length; i++)
            {
                int counter = 0;
                int dataResult = dataSensors[i];
                while (dataResult > 0)
                {
                    dataResult = dataResult >> 1;
                    counter++;
                }
                int amountOfBits = counter - 1;
                int cod = dataSensors[i] >> 13;
                uint controlBit = dataSensors[i] & firstMask;
                uint val = (dataSensors[i] & secondMask) >> 1;
                if ((amountOfBits % 2 == 0 && controlBit == 0) || (amountOfBits % 2 != 0 && controlBit == 1))
                {
                    resultParse[i] = new SensorData(Convert.ToUInt16(cod), Convert.ToUInt16(val), Convert.ToUInt16(controlBit));
                }
                else
                {
                    Console.WriteLine("Данные {0} со счетчика {1} повреждены", dataSensors[i], cod);
                }
            }
            return resultParse;
        }
        private static double[] GetAverageBySensor(SensorData[] resultParse)
        {
            int counterFirstSensor = 0;
            int counterSecondSensor = 0;
            int counterThirdSensor = 0;
            int sumFirstSensor = 0;
            int sumSecondSensor = 0;
            int sumThirdSensor = 0;
            for (int i = 0; i < resultParse.Length; i++)
            {
                switch (resultParse[i].codeSensor)
                {
                    case 1:
                        counterFirstSensor++;
                        sumFirstSensor += resultParse[i].valueSensor;
                        break;
                    case 2:
                        counterSecondSensor++;
                        sumSecondSensor += resultParse[i].valueSensor;
                        break;
                    case 3:
                        counterThirdSensor++;
                        sumThirdSensor += resultParse[i].valueSensor;
                        break;
                    default:
                        break;
                }
            }
            double[] AverageBySensor = { (sumFirstSensor / counterFirstSensor), (sumSecondSensor / counterSecondSensor), (sumThirdSensor / counterThirdSensor) };
            return AverageBySensor;
        }
        public static void WriteResults()
        {
            var rawData = GetSensors();
            var parsData = GetParse(rawData);
            var average = GetAverageBySensor(parsData);
            foreach (var data in parsData)
            {
                Console.WriteLine("Счетчик {0}: {1}", data.codeSensor, data.valueSensor);
            }
            for (int i = 0; i < average.Length; i++)
            {
                Console.WriteLine("Среднее значение по счетчику {0}: {1}", i + 1, average[i]);
            }
        }
    }
}
