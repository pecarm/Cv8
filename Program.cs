using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cv8
{
    class Program
    {
        static void Main(string[] args)
        {
            ArchivTeplot archiv = new ArchivTeplot();
            
            //using full local address of the directory, you will need to change it for it to work properly
            archiv.Load("C:\\Users\\marti\\Desktop\\DOCUMENTS\\3. Ročník Bc\\Letní semestr\\Objektově orientované programování\\Cv8\\Archive1.txt");
            
            archiv.TiskTeplot();
            Console.WriteLine("");

            archiv.TiskPrumernychRocnichTeplot();
            Console.WriteLine("");

            archiv.TiskPrumernychMesicnichTeplot();
            Console.WriteLine("\n");

            archiv.Kalibrace(-0.1);
            archiv.TiskTeplot();
            Console.WriteLine("");

            archiv.Save("C:\\Users\\marti\\Desktop\\DOCUMENTS\\3. Ročník Bc\\Letní semestr\\Objektově orientované programování\\Cv8\\Folder\\Archive2.txt");
        }
    }
}
