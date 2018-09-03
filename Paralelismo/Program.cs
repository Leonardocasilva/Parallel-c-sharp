using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Paralelismo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Temos a chamada de dois metodos em nossa main
             * um deles não utiliza o paralelismo, enviamos
             * enviamos como parametro, apenas a quantidade
             * de Downloads que queremos que ele faca e ele
             * fara isso utilizando apenas uma Thread
             * 
             * Na Segunda chamada, já utilizamos o parelelismo
             * para efetuar o mesmo processo, porém ele recebe
             * como parametro, a quantidade de thread a ser usada
             * no processo e quantidade de Downloads a ser executado
             * 
             * Lembrando que, os Download são ficticios e usam o Sleep
             * para simular o tempo de download de um arquivo pequeno
             * 
             * O resultado apresentado no Console, é qual Download foi
             * efetuado e por qual Thread ele foi processado.
             * 
             * Antes de executar, não se esqueça de comentar um dos metodos para
             * fazer a comparação entre os processamentos.
             */

            // Metodo sem paralelismo
            GetDownload(100);

            // Metodo com paralelismo
            GetDownloadParallel(10, 100);

            Console.ReadKey();
        }

        static void GetDownloadParallel(int threads, int downloads)
        {
            List<string> urls = new List<string>();

            for (int i = 0; i < downloads; i++)
            {
                urls.Add(i.ToString() + ".jpg");
            }

            ParallelOptions op = new ParallelOptions();

            op.MaxDegreeOfParallelism = threads;

            Parallel.ForEach(urls, url =>{
                DownloadFile(url);
            });
        }

        static void GetDownload(int downloads)
        {
            List<string> urls = new List<string>();

            for (int i = 0; i < downloads; i++)
            {
                urls.Add(i.ToString() + ".jpg");
            }

            foreach(var url in urls)
            {
                DownloadFile(url);
            }
        }

        static void DownloadFile(string url)
        {
            Thread.Sleep(5000);
            Console.WriteLine("Download Done: {0} ThreadID: {1}", url, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
