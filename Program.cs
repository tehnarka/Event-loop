using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Event_loop
{
   public class EventLoop
    {
        public static ManualResetEventSlim _messageEvent = new ManualResetEventSlim(false);
        public static Queue<int> _messageQueue = new Queue<int>();
        public void Start()
        {
            var t = new Thread(PumpMessages);
            t.Start();
            while (true)
            {
                var message = WaitMessage();
                Console.WriteLine("Recieved message:" + message);
            }
        }

        public String Start(String data)
        {
            var t = new Thread(new ParameterizedThreadStart(PumpMessagesParam));
            t.Start(data);
            var result = "";
            for(var i = 0; i < data.Count(); ++i)
            {
                var message = WaitMessage();
                result += "Recieved message:" + message + '\n';
                Console.WriteLine("Recieved message:" + message);
            }
            return result;
        }


        public static int WaitMessage()
        {
            _messageEvent.Wait();
            var message = _messageQueue.Dequeue();
            _messageEvent.Reset();

            return message;
        }
        public static void PumpMessages()
        {
            while (true)
            {
                var value = Console.ReadLine();
                var intValue = int.Parse(value);
                _messageQueue.Enqueue(intValue);
                _messageEvent.Set();
            }
        }
        public static void PumpMessagesParam(object obj)
        {
            var data = obj.ToString();
            for(var i = 0; i < data.Count(); ++i)
            {
                var value = int.Parse(data[i].ToString());
                _messageQueue.Enqueue(value);
                _messageEvent.Set();
                Thread.Sleep(500);
            }
        }
    }
    public class Program
    {
        static public void Main()
        {
            var eventloop = new EventLoop();
            var res = eventloop.Start("123");
            Console.WriteLine(res);
            //var eventloop = new EventLoop();
            //eventloop.Start();
        }
    }
}
