using System;

namespace ArvoreAVL
{
    class Program
    {
        static void Main(string[] args)
        {
            //20, 15, 25, 12, 17, 24, 30, 10, 14, 13
            Arvore arv = new Arvore();

            arv.Inserir(20, 20);
            arv.Inserir(15, 15);
            arv.Inserir(25, 25);
            arv.Inserir(12, 12);
            arv.Inserir(17, 17);
            arv.Inserir(24, 24);
            arv.Inserir(30, 30);
            arv.Inserir(10, 10);
            arv.Inserir(14, 14);
            arv.Inserir(13, 13);
            

            arv.print(2, 2);

        }
    }
}
