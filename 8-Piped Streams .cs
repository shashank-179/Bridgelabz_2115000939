/*Piped Streams - Inter-Thread Communication 
📌 Problem Statement: Implement a C# program where one thread writes data into a PipeStream and another thread reads data from it. 
Requirements: Use two threads for reading and writing. Synchronize properly to prevent data loss. Handle IOException.
*/
using System;
using System.IO.Pipes;
using System.Threading;

class PipeStream
{
   public static void WriteToPipe(AnonymousPipeServerStream pipe)
   {
       try
       {
           using (StreamWriter writer = new StreamWriter(pipe))
           {
               for (int i = 1; i <= 5; i++)
               {
                   writer.WriteLine("Message " + i);
                   Console.WriteLine("Written: Message " + i);
                   Thread.Sleep(500);
               }
           }
       }
       catch (Exception ex)
       {
           Console.WriteLine("Write Error: " + ex.Message);
       }
   }

   public static void ReadFromPipe(AnonymousPipeClientStream pipe)
   {
       try
       {
           using (StreamReader reader = new StreamReader(pipe))
           {
               string message;
               while ((message = reader.ReadLine()) != null)
               {
                   Console.WriteLine("Read: " + message);
               }
           }
       }
       catch (Exception ex)
       {
           Console.WriteLine("Read Error: " + ex.Message);
       }
   }

   public static void Main(string[] args)
   {
       using (var pipeServer = new AnonymousPipeServerStream(PipeDirection.Out))
       using (var pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.ClientSafePipeHandle))
       {
           Thread writerThread = new Thread(() => WriteToPipe(pipeServer));
           Thread readerThread = new Thread(() => ReadFromPipe(pipeClient));

           writerThread.Start();
           readerThread.Start();

           writerThread.Join();
           readerThread.Join();
       }
   }
}

