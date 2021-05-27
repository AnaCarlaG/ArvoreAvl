using System;

namespace ArvoreAVL
{
    class Program
    {
        static void Main(string[] args)
        {
            Arvore arv = new Arvore();

            arv.Inserir(8, 8);
            arv.Inserir(4, 4);
            arv.Inserir(12, 12);
            arv.Inserir(2, 2);
            arv.Inserir(3, 3);
            arv.Inserir(6, 6);
            //arv.Inserir(5, 5);
            //arv.Inserir(7, 7);
            //arv.Inserir(10, 10);
            //arv.Inserir(9, 9);
            //arv.Inserir(11, 11);
            //arv.Inserir(14, 14);
            //arv.Inserir(13, 13);
            //arv.Inserir(1, 1);
            //arv.Inserir(15, 15);

            arv.print(2, 2);

            var consulta = arv.Consultar(8);
            Console.WriteLine(consulta.filhoDireito.dados);
            Console.WriteLine(consulta.filhoEsquerdo.dados);

            //Console.WriteLine(arv.Consultar(6).dados);

        }
    }
}
