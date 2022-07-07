using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp7;



namespace ConsoleApp4
{
    internal class Class1
    {
        static void Main(string[] args)
        {
            var client = new S7Client();
            int result = client.ConnectTo("192.168.0.1", 0, 1);
            if (result == 0)
            {
                Console.WriteLine("Connected to 192.168.0.1");
            }
            else
            {
                Console.WriteLine(client.ErrorText(result));
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Read DB1");
            byte[] db1Buffer = new byte[18];
            result = client.DBRead(1, 0, 18, db1Buffer);
            if (result != 0)
            {
                Console.WriteLine("Error:" + client.ErrorText(result));

            }

            bool db1dbw0 = S7.GetBitAt(db1Buffer, 0, 0);
            Console.WriteLine("DB1.DBDW0.0:" + db1dbw0);

            bool dbdbw1 = S7.GetBitAt(db1Buffer, 0, 1);
            Console.WriteLine("DB1.DBW0.1:" + dbdbw1);

            int db1dbw2 = S7.GetIntAt(db1Buffer, 2);
            Console.WriteLine("DB1.DBW2 : " + db1dbw2);

            double db1dbd4 = S7.GetRealAt(db1Buffer, 4);
            Console.WriteLine("DB1.DBD4:" + db1dbd4);

            double db1dbd8 = S7.GetDIntAt(db1Buffer, 8);
            Console.WriteLine("DB1.DBD8:" + db1dbd8);

            double db1dbd12 = S7.GetDWordAt(db1Buffer, 12);
            Console.WriteLine("DB1.DBD12:" + db1dbd12);

            double db1dbd16 = S7.GetWordAt(db1Buffer, 16);
            Console.WriteLine("DB1.DBD16:" + db1dbd16);

            bool db1dbw1 = S7.GetBitAt(db1Buffer, 0, 0);
            Console.WriteLine("DB1.DBDW0.0:" + db1dbw1);


        }
    }
}

